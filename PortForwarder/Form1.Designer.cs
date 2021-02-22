namespace PortForwarder {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lifetimeBox = new System.Windows.Forms.NumericUpDown();
			this.refreshIntervalBox = new System.Windows.Forms.NumericUpDown();
			this.protocolBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.publicPortBox = new System.Windows.Forms.NumericUpDown();
			this.privatePortBox = new System.Windows.Forms.NumericUpDown();
			this.portsLinkedCheck = new System.Windows.Forms.CheckBox();
			this.settingsGroup = new System.Windows.Forms.GroupBox();
			this.resetSettingsButton = new System.Windows.Forms.Button();
			this.natDevicesList = new System.Windows.Forms.ListBox();
			this.scanButton = new System.Windows.Forms.Button();
			this.createMappingButton = new System.Windows.Forms.Button();
			this.removeMappingButton = new System.Windows.Forms.Button();
			this.natDevicesGroup = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.refreshIntervalInfo = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lifetimeInfo = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.portInfo = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.protocolInfo = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.mappedInfo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.externalIpInfo = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.targetGatewayInfo = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.lifetimeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.publicPortBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.privatePortBox)).BeginInit();
			this.settingsGroup.SuspendLayout();
			this.natDevicesGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Lifetime";
			this.toolTip1.SetToolTip(this.label2, "The lifetime in seconds for the port mapping (0 is forever)");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Refresh Interval";
			this.toolTip1.SetToolTip(this.label3, "The interval in seconds at which to refresh the port mapping\'s lifetime (0 is nev" +
        "er)");
			// 
			// lifetimeBox
			// 
			this.lifetimeBox.Location = new System.Drawing.Point(94, 14);
			this.lifetimeBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.lifetimeBox.Name = "lifetimeBox";
			this.lifetimeBox.Size = new System.Drawing.Size(120, 20);
			this.lifetimeBox.TabIndex = 4;
			this.lifetimeBox.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// refreshIntervalBox
			// 
			this.refreshIntervalBox.Location = new System.Drawing.Point(94, 40);
			this.refreshIntervalBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.refreshIntervalBox.Name = "refreshIntervalBox";
			this.refreshIntervalBox.Size = new System.Drawing.Size(120, 20);
			this.refreshIntervalBox.TabIndex = 5;
			this.refreshIntervalBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// protocolBox
			// 
			this.protocolBox.FormattingEnabled = true;
			this.protocolBox.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "TCP/UDP"});
			this.protocolBox.Location = new System.Drawing.Point(94, 66);
			this.protocolBox.Name = "protocolBox";
			this.protocolBox.Size = new System.Drawing.Size(120, 21);
			this.protocolBox.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Protocol";
			this.toolTip1.SetToolTip(this.label4, "The type of traffic the port mapping should allow");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Public Port";
			this.toolTip1.SetToolTip(this.label5, "The public port for the mapping");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Private Port";
			this.toolTip1.SetToolTip(this.label6, "The private port for the mapping");
			// 
			// publicPortBox
			// 
			this.publicPortBox.Location = new System.Drawing.Point(94, 93);
			this.publicPortBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.publicPortBox.Name = "publicPortBox";
			this.publicPortBox.Size = new System.Drawing.Size(120, 20);
			this.publicPortBox.TabIndex = 10;
			this.publicPortBox.Value = new decimal(new int[] {
            4444,
            0,
            0,
            0});
			// 
			// privatePortBox
			// 
			this.privatePortBox.Location = new System.Drawing.Point(94, 119);
			this.privatePortBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.privatePortBox.Name = "privatePortBox";
			this.privatePortBox.Size = new System.Drawing.Size(120, 20);
			this.privatePortBox.TabIndex = 11;
			this.privatePortBox.Value = new decimal(new int[] {
            4444,
            0,
            0,
            0});
			// 
			// portsLinkedCheck
			// 
			this.portsLinkedCheck.AutoSize = true;
			this.portsLinkedCheck.Checked = true;
			this.portsLinkedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.portsLinkedCheck.Location = new System.Drawing.Point(220, 94);
			this.portsLinkedCheck.Name = "portsLinkedCheck";
			this.portsLinkedCheck.Size = new System.Drawing.Size(58, 17);
			this.portsLinkedCheck.TabIndex = 12;
			this.portsLinkedCheck.Text = "Linked";
			this.toolTip1.SetToolTip(this.portsLinkedCheck, "Use the same public/private ports");
			this.portsLinkedCheck.UseVisualStyleBackColor = true;
			this.portsLinkedCheck.CheckedChanged += new System.EventHandler(this.PortsLinkedCheck_CheckedChanged);
			// 
			// settingsGroup
			// 
			this.settingsGroup.Controls.Add(this.resetSettingsButton);
			this.settingsGroup.Controls.Add(this.label2);
			this.settingsGroup.Controls.Add(this.lifetimeBox);
			this.settingsGroup.Controls.Add(this.label3);
			this.settingsGroup.Controls.Add(this.refreshIntervalBox);
			this.settingsGroup.Controls.Add(this.label4);
			this.settingsGroup.Controls.Add(this.protocolBox);
			this.settingsGroup.Controls.Add(this.label5);
			this.settingsGroup.Controls.Add(this.publicPortBox);
			this.settingsGroup.Controls.Add(this.portsLinkedCheck);
			this.settingsGroup.Controls.Add(this.label6);
			this.settingsGroup.Controls.Add(this.privatePortBox);
			this.settingsGroup.Location = new System.Drawing.Point(12, 140);
			this.settingsGroup.Name = "settingsGroup";
			this.settingsGroup.Size = new System.Drawing.Size(302, 149);
			this.settingsGroup.TabIndex = 13;
			this.settingsGroup.TabStop = false;
			this.settingsGroup.Text = "Options";
			// 
			// resetSettingsButton
			// 
			this.resetSettingsButton.Location = new System.Drawing.Point(238, 0);
			this.resetSettingsButton.Name = "resetSettingsButton";
			this.resetSettingsButton.Size = new System.Drawing.Size(57, 23);
			this.resetSettingsButton.TabIndex = 13;
			this.resetSettingsButton.Text = "Default";
			this.toolTip1.SetToolTip(this.resetSettingsButton, "Restore default options");
			this.resetSettingsButton.UseVisualStyleBackColor = true;
			this.resetSettingsButton.Click += new System.EventHandler(this.ResetSettingsButton_Click);
			// 
			// natDevicesList
			// 
			this.natDevicesList.FormattingEnabled = true;
			this.natDevicesList.Location = new System.Drawing.Point(6, 19);
			this.natDevicesList.Name = "natDevicesList";
			this.natDevicesList.Size = new System.Drawing.Size(208, 95);
			this.natDevicesList.TabIndex = 15;
			this.natDevicesList.SelectedIndexChanged += new System.EventHandler(this.NatDevicesList_SelectedIndexChanged);
			// 
			// scanButton
			// 
			this.scanButton.Location = new System.Drawing.Point(220, 19);
			this.scanButton.Name = "scanButton";
			this.scanButton.Size = new System.Drawing.Size(75, 23);
			this.scanButton.TabIndex = 16;
			this.scanButton.Text = "Scan";
			this.toolTip1.SetToolTip(this.scanButton, "Scan for supported NAT devices");
			this.scanButton.UseVisualStyleBackColor = true;
			this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
			// 
			// createMappingButton
			// 
			this.createMappingButton.Location = new System.Drawing.Point(51, 295);
			this.createMappingButton.Name = "createMappingButton";
			this.createMappingButton.Size = new System.Drawing.Size(105, 23);
			this.createMappingButton.TabIndex = 17;
			this.createMappingButton.Text = "Add Mapping";
			this.toolTip1.SetToolTip(this.createMappingButton, "Create the port mapping");
			this.createMappingButton.UseVisualStyleBackColor = true;
			this.createMappingButton.Click += new System.EventHandler(this.CreateMappingButton_Click);
			// 
			// removeMappingButton
			// 
			this.removeMappingButton.Location = new System.Drawing.Point(162, 295);
			this.removeMappingButton.Name = "removeMappingButton";
			this.removeMappingButton.Size = new System.Drawing.Size(105, 23);
			this.removeMappingButton.TabIndex = 18;
			this.removeMappingButton.Text = "Remove Mapping";
			this.toolTip1.SetToolTip(this.removeMappingButton, "Remove the port mapping");
			this.removeMappingButton.UseVisualStyleBackColor = true;
			this.removeMappingButton.Click += new System.EventHandler(this.RemoveMappingButton_Click);
			// 
			// natDevicesGroup
			// 
			this.natDevicesGroup.Controls.Add(this.natDevicesList);
			this.natDevicesGroup.Controls.Add(this.scanButton);
			this.natDevicesGroup.Location = new System.Drawing.Point(12, 12);
			this.natDevicesGroup.Name = "natDevicesGroup";
			this.natDevicesGroup.Size = new System.Drawing.Size(302, 122);
			this.natDevicesGroup.TabIndex = 19;
			this.natDevicesGroup.TabStop = false;
			this.natDevicesGroup.Text = "NAT/Router";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.refreshIntervalInfo);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.lifetimeInfo);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.portInfo);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.protocolInfo);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.mappedInfo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.externalIpInfo);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.targetGatewayInfo);
			this.groupBox1.Location = new System.Drawing.Point(12, 324);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(302, 145);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Info";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(6, 124);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(85, 13);
			this.label18.TabIndex = 12;
			this.label18.Text = "Refresh Interval:";
			// 
			// refreshIntervalInfo
			// 
			this.refreshIntervalInfo.AutoSize = true;
			this.refreshIntervalInfo.Location = new System.Drawing.Point(91, 124);
			this.refreshIntervalInfo.Name = "refreshIntervalInfo";
			this.refreshIntervalInfo.Size = new System.Drawing.Size(0, 13);
			this.refreshIntervalInfo.TabIndex = 13;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 106);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(46, 13);
			this.label16.TabIndex = 10;
			this.label16.Text = "Lifetime:";
			// 
			// lifetimeInfo
			// 
			this.lifetimeInfo.AutoSize = true;
			this.lifetimeInfo.Location = new System.Drawing.Point(91, 106);
			this.lifetimeInfo.Name = "lifetimeInfo";
			this.lifetimeInfo.Size = new System.Drawing.Size(0, 13);
			this.lifetimeInfo.TabIndex = 11;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 88);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 13);
			this.label14.TabIndex = 8;
			this.label14.Text = "Port (publ/priv):";
			// 
			// portInfo
			// 
			this.portInfo.AutoSize = true;
			this.portInfo.Location = new System.Drawing.Point(91, 88);
			this.portInfo.Name = "portInfo";
			this.portInfo.Size = new System.Drawing.Size(0, 13);
			this.portInfo.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Protocol:";
			// 
			// protocolInfo
			// 
			this.protocolInfo.AutoSize = true;
			this.protocolInfo.Location = new System.Drawing.Point(91, 70);
			this.protocolInfo.Name = "protocolInfo";
			this.protocolInfo.Size = new System.Drawing.Size(0, 13);
			this.protocolInfo.TabIndex = 7;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 52);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(40, 13);
			this.label13.TabIndex = 4;
			this.label13.Text = "Active:";
			// 
			// mappedInfo
			// 
			this.mappedInfo.AutoSize = true;
			this.mappedInfo.Location = new System.Drawing.Point(91, 52);
			this.mappedInfo.Name = "mappedInfo";
			this.mappedInfo.Size = new System.Drawing.Size(21, 13);
			this.mappedInfo.TabIndex = 5;
			this.mappedInfo.Text = "No";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "External IP:";
			this.toolTip1.SetToolTip(this.label1, "External/public/WAN address of the NAT/router");
			// 
			// externalIpInfo
			// 
			this.externalIpInfo.AutoSize = true;
			this.externalIpInfo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.externalIpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.externalIpInfo.Location = new System.Drawing.Point(91, 34);
			this.externalIpInfo.Name = "externalIpInfo";
			this.externalIpInfo.Size = new System.Drawing.Size(53, 13);
			this.externalIpInfo.TabIndex = 1;
			this.externalIpInfo.Text = "Unknown";
			this.toolTip1.SetToolTip(this.externalIpInfo, "Click to copy");
			this.externalIpInfo.Click += new System.EventHandler(this.ExternalIpInfo_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(73, 13);
			this.label10.TabIndex = 3;
			this.label10.Text = "NAT Address:";
			this.toolTip1.SetToolTip(this.label10, "IP address of the selected NAT/router");
			// 
			// targetGatewayInfo
			// 
			this.targetGatewayInfo.AutoSize = true;
			this.targetGatewayInfo.Location = new System.Drawing.Point(91, 16);
			this.targetGatewayInfo.Name = "targetGatewayInfo";
			this.targetGatewayInfo.Size = new System.Drawing.Size(0, 13);
			this.targetGatewayInfo.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(327, 480);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.natDevicesGroup);
			this.Controls.Add(this.settingsGroup);
			this.Controls.Add(this.createMappingButton);
			this.Controls.Add(this.removeMappingButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "UPnP Port Forwarder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_OnLoad);
			((System.ComponentModel.ISupportInitialize)(this.lifetimeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.publicPortBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.privatePortBox)).EndInit();
			this.settingsGroup.ResumeLayout(false);
			this.settingsGroup.PerformLayout();
			this.natDevicesGroup.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown lifetimeBox;
		private System.Windows.Forms.NumericUpDown refreshIntervalBox;
		private System.Windows.Forms.ComboBox protocolBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown publicPortBox;
		private System.Windows.Forms.NumericUpDown privatePortBox;
		private System.Windows.Forms.CheckBox portsLinkedCheck;
		private System.Windows.Forms.GroupBox settingsGroup;
		private System.Windows.Forms.ListBox natDevicesList;
		private System.Windows.Forms.Button scanButton;
		private System.Windows.Forms.Button createMappingButton;
		private System.Windows.Forms.Button removeMappingButton;
		private System.Windows.Forms.GroupBox natDevicesGroup;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label refreshIntervalInfo;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lifetimeInfo;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label portInfo;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label protocolInfo;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label mappedInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label externalIpInfo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label targetGatewayInfo;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button resetSettingsButton;
	}
}

