using nudge.Utilities;

namespace nudge
{
    public partial class SettingsForm : Form
    {
        private CancellationTokenSource _cts;

        private double _inactivityThresholdSeconds = 30; // Default inactivity threshold in seconds

        private bool _moveMouse = true;

        private bool _keyStroke = true;

        private string _keyToPress = "F13";

        private readonly List<string> _recentActivity = [];

        /// <summary>
        /// Initializes the settings form.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Force the form to be hidden on startup.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            this.Visible = false; // Hide the form on startup
            base.OnShown(e);
        }

        /// <summary>
        /// Starts Nudge using the configured settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load the settings from the configuration file.
            _inactivityThresholdSeconds = Properties.Settings.Default.InactivityThresholdSeconds;
            _moveMouse = Properties.Settings.Default.MoveMouse;
            _keyStroke = Properties.Settings.Default.KeyStroke;
            _keyToPress = Properties.Settings.Default.KeyToPress;

            // We have to display the settings on the form.
            IntervalInputTextBox.Text = TimeSpan.FromSeconds(_inactivityThresholdSeconds).ToString(@"hh\:mm\:ss");
            MouseJiggleEnableCheckBox.Checked = _moveMouse;
            KeyboardInputEnableCheckBox.Checked = _keyStroke;
            KeyboardInputKeyCodeInput.Text = _keyToPress;

            MonitorUserInactivity();
        }

        /// <summary>
        /// Async method which monitors user activity.
        /// </summary>
        private async void MonitorUserInactivity()
        {
            TimeSpan inactivityThreshold = TimeSpan.FromSeconds(_inactivityThresholdSeconds);

            try
            {
                await ActivityHelper.MonitorInactivityAsync(inactivityThreshold, OnInactivityDetected, _cts.Token);
            }
            catch (TaskCanceledException)
            {
                // Task was canceled; do nothing.
            }
        }

        /// <summary>
        /// Performs the configured action upon inactivity detection.
        /// </summary>
        private void OnInactivityDetected()
        {
            // Move the mouse.
            // This will move just slightly to the right.
            if (_moveMouse)
            {
                _ = Task.Run(async () =>
                {
                    int msDelay = 100;

                    InputHelper.MoveMouse(10, 0);

                    await Task.Delay(msDelay);

                    InputHelper.MoveMouse(-10, 0);

                    await Task.Delay(msDelay);

                    InputHelper.MoveMouse(10, 0);

                    await Task.Delay(msDelay);

                    InputHelper.MoveMouse(-10, 0);

                    LogActivity($"{DateTime.Now:g}: Jiggled mouse.");
                });
            }

            // Hit F13 (non destructive key stroke)
            // This should be configurable as well...
            if (_keyStroke)
            {
                // Get the keycode.
                Keys keycode = (Keys)Enum.Parse(typeof(Keys), _keyToPress);

                _ = Task.Run(() =>
                {
                    InputHelper.KeyPress((ushort)keycode);

                    LogActivity($"{DateTime.Now:g}: Pressed {_keyToPress}.");
                });
            }
        }

        /// <summary>
        /// Opens the settings form when the notify icon is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        /// <summary>
        /// Hides the form when it is minimized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            if (WindowState is FormWindowState.Minimized)
            {
                Hide();
            }
        }

        /// <summary>
        /// Hides the form when the close button is clicked.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            Hide();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Exits the application when the exit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            _cts.Cancel();
            Application.Exit();
        }

        /// <summary>
        /// Mouse jiggle setting updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseJiggleEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _moveMouse = MouseJiggleEnableCheckBox.Checked;

            // Save in settings.
            Properties.Settings.Default.MoveMouse = _moveMouse;

            LogActivity($"{DateTime.Now:g}: {(_moveMouse ? "Enabled" : "Disabled")} Mouse Jiggle.");

            SaveSettings();
        }

        /// <summary>
        /// Keyboard input setting updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardInputEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _keyStroke = KeyboardInputEnableCheckBox.Checked;

            // Save in settings.
            Properties.Settings.Default.KeyStroke = _keyStroke;

            LogActivity($"{DateTime.Now:g}: {(_keyStroke ? "Enabled" : "Disabled")} Key Strokes.");

            SaveSettings();
        }

        /// <summary>
        /// Keyboard keycode setting updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardInputKeyCodeInput_TextChanged(object sender, EventArgs e)
        {
            bool valid = false;

            try
            {
                // Validate the key.
                if (Enum.TryParse(typeof(Keys), KeyboardInputKeyCodeInput.Text, true, out object? keysEnum) && keysEnum is Keys keyCode)
                {
                    _keyToPress = KeyboardInputKeyCodeInput.Text;

                    // Save in settings.
                    Properties.Settings.Default.KeyToPress = _keyToPress;

                    LogActivity($"{DateTime.Now:g}: Changed KeyToPress to {_keyToPress}.");

                    SaveSettings();

                    valid = true;
                }
            }
            catch (Exception)
            {
                // Do nothing for now.
            }

            // If the input is invalid, we'll simply change the border of the input indicate that.
            KeyboardInputKeyCodeInput.ForeColor = valid ? SystemColors.WindowText : Color.IndianRed;
        }

        private void IntervalInputTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Validate.
        }

        /// <summary>
        /// Interval timespan has been updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (TimeSpan.TryParse(IntervalInputTextBox.Text, out TimeSpan timeSpan))
            {
                _inactivityThresholdSeconds = timeSpan.TotalSeconds;

                // Save in settings.
                Properties.Settings.Default.InactivityThresholdSeconds = _inactivityThresholdSeconds;

                LogActivity($"{DateTime.Now:g}: Changed InactivityIntervalSeconds to {_inactivityThresholdSeconds}.");

                SaveSettings();

                _cts.Cancel();

                _cts = new CancellationTokenSource();

                MonitorUserInactivity();
            }
            else
            {
                // Display a pop up that it's invalid.
                MessageBox.Show($"The specified interval is not a valid timespan.", "Invalid TimeSpan", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Save the user's settings.
        /// </summary>
        private static void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Adds a message to the recent activity collection.
        /// </summary>
        /// <param name="message"></param>
        private void LogActivity(string message)
        {
            _recentActivity.Add(message);

            // If there are 10k entries, we'll start removing from the beginning.
            if (_recentActivity.Count > 10000)
            {
                _recentActivity.RemoveAt(0);
            }
        }

        /// <summary>
        /// Opens the logs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecentActivityButton_Click(object sender, EventArgs e) => ShowLogsForm(_recentActivity);

        /// <summary>
        /// Creates the logs form on the fly.
        /// This is non blocking.
        /// </summary>
        /// <param name="items"></param>
        private void ShowLogsForm(List<string> items)
        {
            Form scrollableForm = new()
            {
                Text = "Recent Activity",
                ClientSize = new Size(400, 300)
            };

            TextBox textBox = new()
            {
                Multiline = true,
                ReadOnly = true,
                Enabled = false,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Lines = [.. items]
            };

            scrollableForm.Controls.Add(textBox);

            scrollableForm.Show();
        }

        /// <summary>
        /// Show the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => NotifyIcon_MouseDoubleClick(sender, null!);

        /// <summary>
        /// Shutdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e) => ExitToolStripMenuItem_Click(sender, e);
    }
}
