using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.Nat;
using PortForwarder.Properties;
using Timer = System.Timers.Timer;

namespace PortForwarder {
	public partial class Form1 : Form {
		private class NatDeviceEntry {
			public INatDevice Device { get; }

			public string DisplayName {
				get {
					if (Device == null) return null;
					string endpoint = Device.DeviceEndpoint.ToString();
					switch (Device.NatProtocol) {
						case NatProtocol.Upnp: return endpoint + " (UPnP)";
						case NatProtocol.Pmp:  return endpoint + " (PMP)";
						default:               return endpoint;
					}
				}
			}

			public NatDeviceEntry(INatDevice device) {
				Device = device;
			}

			public override bool Equals(object obj) {
				return obj is NatDeviceEntry entry && entry.Device == Device;
			}

			public override int GetHashCode() {
				return Device != null ? Device.GetHashCode() : 0;
			}
		}

		// Scan duration in milliseconds.
		private const int NatScanDuration = 3000;
		// Description of created port mappings.
		private const string DefaultDescription = "UPnP Port Forwarder Rule";

		private INatDevice natDevice;
		private int lifetime;
		private int refreshInterval;
		private readonly Timer refreshTimer;

		private readonly Mapping[] referenceMappings = new Mapping[2];
		private readonly Mapping[] activeMappings = new Mapping[2];

		private bool initialScan;

		private readonly BindingList<NatDeviceEntry> natDeviceEntries = new BindingList<NatDeviceEntry>();

		public Form1() {
			InitializeComponent();

			// Ports
			portsLinkedCheck.CheckedChanged += (sender, args) => privatePortBox.Value = publicPortBox.Value;
			publicPortBox.ValueChanged += OnPortBoxValueChanged;
			if (portsLinkedCheck.Checked)
				privatePortBox.Enabled = false;

			createMappingButton.Enabled = false;
			removeMappingButton.Enabled = false;
			settingsGroup.Enabled = false;

			protocolBox.SelectedIndex = 0;
			natDevicesList.DisplayMember = nameof(NatDeviceEntry.DisplayName);
			natDevicesList.ValueMember = nameof(NatDeviceEntry.Device);
			natDevicesList.DataSource = natDeviceEntries;

			// Refresh timer
			refreshTimer = new Timer();
			refreshTimer.Elapsed += async (sender, args) => {
				// Refresh port mapping.
				await ApplyPortMappings(true);
			};
		}

		#region Event handlers

		private async void Form1_OnLoad(object sender, EventArgs e) {
			LoadSettings();
			
			NatUtility.DeviceFound += NatUtilityOnDeviceFound;
			NatUtility.DeviceLost += NatUtilityOnDeviceLost;

			// Initial NAT device scan.
			initialScan = true;
			await ScanNatDevices(NatScanDuration);
			initialScan = false;

			if (natDeviceEntries.Count == 0) {
				ShowMessage("No supported NAT device detected!", MessageBoxIcon.Exclamation);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			SaveSettings();

			if (natDevice != null) {
				// Execute synchronously to ensure that it completes.
				// Run on another thread to avoid locking up the program forever. (synchronization context deadlock?)
				Task.Run(RemovePortMappings).Wait(3000);
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			NatUtility.DeviceFound -= NatUtilityOnDeviceFound;
			NatUtility.DeviceLost -= NatUtilityOnDeviceLost;
		}

		private void NatUtilityOnDeviceFound(object sender, DeviceEventArgs e) {
			Debug.WriteLine("Nat device found: {0}", e.Device);
			// Invoke on UI thread.
			Invoke(new Action(() => {
				//natDevicesList.Items.Add(new NatDeviceEntry(e.Device));
				NatDeviceEntry entry = new NatDeviceEntry(e.Device);
				natDeviceEntries.Add(entry);

				// Auto select first device.
				if (natDevice == null && natDevicesList.Items.Count == 1) {
					//natDevicesList.SelectedIndex = 0;
					natDevicesList.SelectedIndex = 0;
					NatDevicesList_SelectedIndexChanged(null, null); // REEE
					Debug.Assert(natDevicesList.SelectedItem == entry);
					Debug.Assert(natDevice == entry.Device);

				}
				else if (initialScan && natDevice != null && natDevice.NatProtocol == NatProtocol.Pmp &&
					e.Device.DeviceEndpoint.Address.Equals(natDevice.DeviceEndpoint.Address) &&
					e.Device.NatProtocol == NatProtocol.Upnp) {
					// Prefer UPnP over PMP.
					natDevicesList.SelectedItem = entry;
				}
			}));
		}

		private void NatUtilityOnDeviceLost(object sender, DeviceEventArgs e) {
			Debug.WriteLine("Nat device lost: {0}", e.Device);
			// Invoke on UI thread.
			//Invoke(new Action(() => natDevicesList.Items.Remove(new NatDeviceEntry(e.Device))));
			Invoke(new Action(() => natDeviceEntries.Remove(new NatDeviceEntry(e.Device))));
		}

		private void OnPortBoxValueChanged(object sender, EventArgs e) {
			if (portsLinkedCheck.Checked) {
				// Update linked port numbers.
				decimal value = ((NumericUpDown)sender).Value;
				publicPortBox.Value = value;
				privatePortBox.Value = value;
			}
		}

		private async void NatDevicesList_SelectedIndexChanged(object sender, EventArgs e) {
			await SetNatDevice(natDevicesList.SelectedValue as INatDevice);
		}

		private async void ScanButton_Click(object sender, EventArgs e) {
			await ScanNatDevices(NatScanDuration);
		}

		private async void CreateMappingButton_Click(object sender, EventArgs e) {
			await CreateMappingsWithUI();
		}

		private async void RemoveMappingButton_Click(object sender, EventArgs e) {
			await RemoveMappingsWithUI();
		}

		private void PortsLinkedCheck_CheckedChanged(object sender, EventArgs e) {
			privatePortBox.Enabled = !portsLinkedCheck.Checked;
		}

		private void ExternalIpInfo_Click(object sender, EventArgs e) {
			Clipboard.SetText(externalIpInfo.Text);
		}

		private void ResetSettingsButton_Click(object sender, EventArgs e) {
			ResetSettings();
		}

		#endregion

		// Nat device

		private async Task ScanNatDevices(int scanDuration) {
			// Enable nat device discovery for a while.
			scanButton.Enabled = false;
			scanButton.Text = "Scanning...";
			NatUtility.StartDiscovery();
			await Task.Delay(scanDuration);
			NatUtility.StopDiscovery();
			scanButton.Text = "Scan";
			scanButton.Enabled = true;
		}

		private async Task SetNatDevice(INatDevice device) {
			if (natDevice == device) return;

			// Remove mappings from old device before switching.
			if (natDevice != null)
				await RemoveMappingsWithUI();

			bool hasDevice = device != null;

			if (hasDevice) {
				targetGatewayInfo.Text = device.DeviceEndpoint.ToString();
				
				IPAddress externalIp = null;
				try {
					externalIp = await device.GetExternalIPAsync();
				}
				catch (Exception e) {
					Debug.WriteLine("Failed to get external ip: {0}", e);
				}
				
				externalIpInfo.Text = externalIp != null ? externalIp.ToString() : "Unknown";
			}
			else {
				targetGatewayInfo.Text = "";
				externalIpInfo.Text = "Unknown";
			}

			natDevice = device;

			settingsGroup.Enabled = hasDevice;
			createMappingButton.Enabled = hasDevice;
			removeMappingButton.Enabled = false;
		}

		// Mappings

		private void SetupReferenceMappings() {
			// Get options from UI.
			string protocolString = protocolBox.Text;
			int privatePort = (int)privatePortBox.Value;
			int publicPort = (int)publicPortBox.Value;
			lifetime = (int)lifetimeBox.Value;
			refreshInterval = (int)refreshIntervalBox.Value;

			if (protocolString == "TCP/UDP") {
				// Both TCP and UDP
				referenceMappings[0] = new Mapping(Protocol.Tcp, privatePort, publicPort, lifetime, DefaultDescription);
				referenceMappings[1] = new Mapping(Protocol.Udp, privatePort, publicPort, lifetime, DefaultDescription);
			}
			else {
				// Either TCP or UDP
				Protocol protocol = Protocol.Tcp;
				if (protocolString == "UDP") {
					protocol = Protocol.Udp;
				}
				else if (protocolString != "TCP") {
					Debug.Assert(false, "Bad protocol value", "Got: {0}", protocolString);
					protocolString = "TCP";
				}

				referenceMappings[0] = new Mapping(protocol, privatePort, publicPort, lifetime, DefaultDescription);
				referenceMappings[1] = null;
			}

			protocolInfo.Text = protocolString;
			portInfo.Text = $"{publicPort}/{privatePort}";
			lifetimeInfo.Text = lifetime.ToString();
			refreshIntervalInfo.Text = refreshInterval.ToString();
		}

		private async Task ApplyPortMappings(bool refresh = false) {
			if (natDevice == null) return;

			if (!refresh) {
				// Remove the old mappings.
				await RemovePortMappings();

				// Setup the new mappings.
				SetupReferenceMappings();
			}

			// Create the mappings.
			for (int i = 0; i < 2; i++) {
				Mapping mapping = referenceMappings[i];
				if (mapping == null) break;
				
				// Create mapping.
				Mapping result;
				try {
					result = await natDevice.CreatePortMapAsync(referenceMappings[i]); 
				}
				catch (Exception e) {
					Debug.WriteLine("Failed to create port mapping: {0}", e);
					ShowMessage("Failed to create port mapping", e.Message, MessageBoxIcon.Error);
					await RemoveMappingsWithUI();
					return;
				}

				// Check mapping.
				if (mapping.Equals(result))
					activeMappings[i] = result;
				else {
					// Something went wrong, revert.
					Debug.WriteLine("Created mapping not equal\n  expected: {0}\n  actual: {1}", mapping, result);
					ShowMessage("Failed to create port mapping", "The port mapping that was created by the NAT device differs from the requested one.", MessageBoxIcon.Error);
					await RemoveMappingsWithUI();
					return;
				}
			}

			if (!refresh) {
				// Start refresh timer if needed.
				if (lifetime > 0 && refreshInterval > 0) {
					refreshTimer.Interval = (double)refreshInterval * 1000;
					refreshTimer.Start();
				}

				mappedInfo.Text = "Yes";
			}
		}

		private async Task RemovePortMappings() {
			refreshTimer.Stop();

			if (natDevice == null) return;

			// Remove all mappings.
			for (int i = 0; i < 2; i++) {
				Mapping mapping = activeMappings[i];
				if (mapping == null) continue;
				
				// Delete mapping.
				Mapping result;
				try {
					result = await natDevice.DeletePortMapAsync(mapping);
				}
				catch (Exception e) {
					Debug.WriteLine("Failed to delete port mapping: {0}", e);
					ShowMessageNoBlock("Failed to remove port mapping", e.Message, MessageBoxIcon.Error);
					continue;
				}
				finally {
					activeMappings[i] = null;
				}

				// Check mapping.
				if (!mapping.Equals(result))
					Debug.WriteLine("Deleted mapping not equal\n  expected: {0}\n  actual: {1}", mapping, result);
			}
		}


		private async Task CreateMappingsWithUI() {
			// TODO: Validate settings
			settingsGroup.Enabled = false;
			natDevicesGroup.Enabled = false;
			createMappingButton.Enabled = false;
			removeMappingButton.Enabled = false;

			await ApplyPortMappings();

			settingsGroup.Enabled = true;
			natDevicesGroup.Enabled = true;
			createMappingButton.Enabled = true;
			removeMappingButton.Enabled = true;
		}

		private async Task RemoveMappingsWithUI() {
			natDevicesGroup.Enabled = false;
			createMappingButton.Enabled = false;
			removeMappingButton.Enabled = false;

			await RemovePortMappings();

			natDevicesGroup.Enabled = true;
			createMappingButton.Enabled = true;

			mappedInfo.Text = "No";
			protocolInfo.Text = "";
			portInfo.Text = "";
			lifetimeInfo.Text = "";
			refreshIntervalInfo.Text = "";
		}


		private void LoadSettings() {
			Settings s = Settings.Default;
			lifetimeBox.Value = s.Lifetime;
			refreshIntervalBox.Value = s.RefreshInterval;
			protocolBox.Text = s.Protocol;
			publicPortBox.Value = s.PublicPort;
			privatePortBox.Value = s.PrivatePort;
			portsLinkedCheck.Checked = s.PortsLinked;
		}

		private void SaveSettings() {
			Settings s = Settings.Default;
			s.Lifetime = (int)lifetimeBox.Value;
			s.RefreshInterval = (int)refreshIntervalBox.Value;
			s.Protocol = protocolBox.Text;
			s.PublicPort = (int)publicPortBox.Value;
			s.PrivatePort = (int)privatePortBox.Value;
			s.PortsLinked = portsLinkedCheck.Checked;
			s.Save();
		}

		private void ResetSettings() {
			Settings.Default.Reset();
			LoadSettings();
		}


		private static void ShowMessage(string message, MessageBoxIcon icon = MessageBoxIcon.Information) {
			MessageBox.Show(message, "", MessageBoxButtons.OK, icon);
		}

		private static void ShowMessage(string caption, string message, MessageBoxIcon icon = MessageBoxIcon.Information) {
			MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
		}

		private static void ShowMessageNoBlock(string message, MessageBoxIcon icon = MessageBoxIcon.Information) {
			Task.Run(() => ShowMessage(message, icon));
		}

		private static void ShowMessageNoBlock(string caption, string message, MessageBoxIcon icon = MessageBoxIcon.Information) {
			Task.Run(() => ShowMessage(caption, message, icon));
		}
	}
}