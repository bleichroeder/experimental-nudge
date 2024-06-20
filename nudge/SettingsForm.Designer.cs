namespace nudge
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            notifyIcon = new NotifyIcon(components);
            TrayMenuStrip = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            KeyboardSettingsGroupBox = new GroupBox();
            KeyboardInputKeyCodeLabel = new Label();
            KeyboardInputKeyCodeInput = new TextBox();
            KeyboardInputEnableCheckBox = new CheckBox();
            MouseSettingsGroupBox = new GroupBox();
            MouseJiggleEnableCheckBox = new CheckBox();
            MainSettingsGroupBox = new GroupBox();
            RecentActivityButton = new Button();
            SaveButton = new Button();
            IntervalLabel = new Label();
            IntervalInputTextBox = new MaskedTextBox();
            TrayMenuStrip.SuspendLayout();
            KeyboardSettingsGroupBox.SuspendLayout();
            MouseSettingsGroupBox.SuspendLayout();
            MainSettingsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = TrayMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Configure nudge";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // TrayMenuStrip
            // 
            TrayMenuStrip.ImageScalingSize = new Size(20, 20);
            TrayMenuStrip.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            TrayMenuStrip.Name = "TrayMenuStrip";
            TrayMenuStrip.Size = new Size(115, 52);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 24);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(114, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click_1;
            // 
            // KeyboardSettingsGroupBox
            // 
            KeyboardSettingsGroupBox.Controls.Add(KeyboardInputKeyCodeLabel);
            KeyboardSettingsGroupBox.Controls.Add(KeyboardInputKeyCodeInput);
            KeyboardSettingsGroupBox.Controls.Add(KeyboardInputEnableCheckBox);
            KeyboardSettingsGroupBox.Dock = DockStyle.Bottom;
            KeyboardSettingsGroupBox.Location = new Point(0, 238);
            KeyboardSettingsGroupBox.Name = "KeyboardSettingsGroupBox";
            KeyboardSettingsGroupBox.Size = new Size(316, 168);
            KeyboardSettingsGroupBox.TabIndex = 0;
            KeyboardSettingsGroupBox.TabStop = false;
            KeyboardSettingsGroupBox.Text = "Keyboard Settings";
            // 
            // KeyboardInputKeyCodeLabel
            // 
            KeyboardInputKeyCodeLabel.AutoSize = true;
            KeyboardInputKeyCodeLabel.Location = new Point(50, 107);
            KeyboardInputKeyCodeLabel.Name = "KeyboardInputKeyCodeLabel";
            KeyboardInputKeyCodeLabel.Size = new Size(90, 20);
            KeyboardInputKeyCodeLabel.TabIndex = 2;
            KeyboardInputKeyCodeLabel.Text = "Key To Press";
            // 
            // KeyboardInputKeyCodeInput
            // 
            KeyboardInputKeyCodeInput.Location = new Point(146, 104);
            KeyboardInputKeyCodeInput.Name = "KeyboardInputKeyCodeInput";
            KeyboardInputKeyCodeInput.Size = new Size(121, 27);
            KeyboardInputKeyCodeInput.TabIndex = 1;
            KeyboardInputKeyCodeInput.TextChanged += KeyboardInputKeyCodeInput_TextChanged;
            // 
            // KeyboardInputEnableCheckBox
            // 
            KeyboardInputEnableCheckBox.AutoSize = true;
            KeyboardInputEnableCheckBox.Location = new Point(88, 51);
            KeyboardInputEnableCheckBox.Name = "KeyboardInputEnableCheckBox";
            KeyboardInputEnableCheckBox.Size = new Size(141, 24);
            KeyboardInputEnableCheckBox.TabIndex = 0;
            KeyboardInputEnableCheckBox.Text = "Enable Key Press";
            KeyboardInputEnableCheckBox.UseVisualStyleBackColor = true;
            KeyboardInputEnableCheckBox.CheckedChanged += KeyboardInputEnableCheckBox_CheckedChanged;
            // 
            // MouseSettingsGroupBox
            // 
            MouseSettingsGroupBox.Controls.Add(MouseJiggleEnableCheckBox);
            MouseSettingsGroupBox.Dock = DockStyle.Fill;
            MouseSettingsGroupBox.Location = new Point(0, 124);
            MouseSettingsGroupBox.Name = "MouseSettingsGroupBox";
            MouseSettingsGroupBox.Size = new Size(316, 114);
            MouseSettingsGroupBox.TabIndex = 1;
            MouseSettingsGroupBox.TabStop = false;
            MouseSettingsGroupBox.Text = "Mouse Settings";
            // 
            // MouseJiggleEnableCheckBox
            // 
            MouseJiggleEnableCheckBox.AutoSize = true;
            MouseJiggleEnableCheckBox.Location = new Point(76, 55);
            MouseJiggleEnableCheckBox.Name = "MouseJiggleEnableCheckBox";
            MouseJiggleEnableCheckBox.Size = new Size(167, 24);
            MouseJiggleEnableCheckBox.TabIndex = 0;
            MouseJiggleEnableCheckBox.Text = "Enable Mouse Jiggle";
            MouseJiggleEnableCheckBox.UseVisualStyleBackColor = true;
            MouseJiggleEnableCheckBox.CheckedChanged += MouseJiggleEnableCheckBox_CheckedChanged;
            // 
            // MainSettingsGroupBox
            // 
            MainSettingsGroupBox.Controls.Add(RecentActivityButton);
            MainSettingsGroupBox.Controls.Add(SaveButton);
            MainSettingsGroupBox.Controls.Add(IntervalLabel);
            MainSettingsGroupBox.Controls.Add(IntervalInputTextBox);
            MainSettingsGroupBox.Dock = DockStyle.Top;
            MainSettingsGroupBox.Location = new Point(0, 0);
            MainSettingsGroupBox.Name = "MainSettingsGroupBox";
            MainSettingsGroupBox.Size = new Size(316, 124);
            MainSettingsGroupBox.TabIndex = 2;
            MainSettingsGroupBox.TabStop = false;
            MainSettingsGroupBox.Text = "Main Settings";
            // 
            // RecentActivityButton
            // 
            RecentActivityButton.Location = new Point(12, 79);
            RecentActivityButton.Name = "RecentActivityButton";
            RecentActivityButton.Size = new Size(292, 29);
            RecentActivityButton.TabIndex = 3;
            RecentActivityButton.Text = "Recent Activity";
            RecentActivityButton.UseVisualStyleBackColor = true;
            RecentActivityButton.Click += RecentActivityButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(219, 35);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(85, 29);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // IntervalLabel
            // 
            IntervalLabel.AutoSize = true;
            IntervalLabel.Location = new Point(12, 38);
            IntervalLabel.Name = "IntervalLabel";
            IntervalLabel.Size = new Size(74, 20);
            IntervalLabel.TabIndex = 1;
            IntervalLabel.Text = "Threshold";
            // 
            // IntervalInputTextBox
            // 
            IntervalInputTextBox.Location = new Point(92, 35);
            IntervalInputTextBox.Mask = "00:00:00";
            IntervalInputTextBox.Name = "IntervalInputTextBox";
            IntervalInputTextBox.Size = new Size(121, 27);
            IntervalInputTextBox.TabIndex = 0;
            IntervalInputTextBox.TextAlign = HorizontalAlignment.Center;
            IntervalInputTextBox.MaskInputRejected += IntervalInputTextBox_MaskInputRejected;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 406);
            Controls.Add(MouseSettingsGroupBox);
            Controls.Add(MainSettingsGroupBox);
            Controls.Add(KeyboardSettingsGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowInTaskbar = false;
            Text = "Nudge Settings";
            WindowState = FormWindowState.Minimized;
            Load += SettingsForm_Load;
            TrayMenuStrip.ResumeLayout(false);
            KeyboardSettingsGroupBox.ResumeLayout(false);
            KeyboardSettingsGroupBox.PerformLayout();
            MouseSettingsGroupBox.ResumeLayout(false);
            MouseSettingsGroupBox.PerformLayout();
            MainSettingsGroupBox.ResumeLayout(false);
            MainSettingsGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon;
        private GroupBox KeyboardSettingsGroupBox;
        private GroupBox MouseSettingsGroupBox;
        private GroupBox MainSettingsGroupBox;
        private Label IntervalLabel;
        private MaskedTextBox IntervalInputTextBox;
        private CheckBox KeyboardInputEnableCheckBox;
        private CheckBox MouseJiggleEnableCheckBox;
        private Label KeyboardInputKeyCodeLabel;
        private TextBox KeyboardInputKeyCodeInput;
        private Button SaveButton;
        private Button RecentActivityButton;
        private ContextMenuStrip TrayMenuStrip;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
