using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoJ.UI
{
    public partial class MainForm : Form
    {
        IO.Joy Joy;
        public MainForm()
        {
            InitializeComponent();

            Joy = new IO.Joy(this);
            Joy.DeviceFound += new DeviceFoundEventHandler(Joy_DeviceFound);
            Joy.JoystickStateChanged += new JoystickStateEventHandler(Joy_JoystickStateChanged);

        }

        void Joy_JoystickStateChanged(object sender, SharpDX.DirectInput.JoystickState s)
        {
            bool[] buttons = s.Buttons;
            for (int i = 0; i < buttonPanel.Controls.Count; i++)
            {
                var b = (JoyButton)buttonPanel.Controls[i];
                b.State = buttons[i];
            }
        }

        void Joy_DeviceFound(object sender, DeviceFoundArguments e)
        {
            switch (e.DeviceType)
            {
                case MoJ.IO.Joy.DeviceType.Button:
                    AddButton(e.Instance.Name);
                    break;

            }
        }

        private JoyButton AddButton(string name)
        {
            JoyButton b = new JoyButton();
            b.Name = name;
            b.Caption = name;
            buttonPanel.Controls.Add(b);
            return b;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string oldstick = Config.Get("joystick");
            try
            {

                Joy.GetSticks();
                foreach (string name in Joy.sticks.Keys)
                {
                    joystickName.Items.Add(name);
                    if (name == oldstick)
                    {
                        joystickName.SelectedItem = name;
                    }
                   
                }  

            }
            catch (JoystickNotFoundException ex)
            {
#if DEMO
                AddButton("Demo 1");
                AddButton("Demo 2");
                AddButton("Demo 3");
                AddButton("Demo 4");
#else

                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void StartPolling()
        {
            Config.Set("joystick", joystickName.Text);
            Config.Save();
            Joy.ConnectDevice(joystickName.Text);
            timer1.Interval = 1000 / 12;
            timer1.Start();
        }

        private void StopPolling()
        {
            timer1.Stop();
            Joy.ReleaseDevice();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Joy.PollData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Joy.ReleaseDevice();
            Joy.Dispose();
        }

        private void joystickName_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopPolling();
            StartPolling();
        }
    }
}
