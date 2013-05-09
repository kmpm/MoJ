#define BUTTON
//#define SLIDER
//#define POV

// Copyright (C) 2013 Peter Magnusson

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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        FlowLayoutPanel povsPanel;
        FlowLayoutPanel sliderPanel;
        FlowLayoutPanel buttonPanel;

        public MainForm()
        {
            InitializeComponent();

            Joy = new IO.Joy(this);
            Joy.DeviceFound += new DeviceFoundEventHandler(Joy_DeviceFound);
            Joy.JoystickStateChanged += new JoystickStateEventHandler(Joy_JoystickStateChanged);
            richTextBox1.Text = Strings.General;
        }

        #region Joy Events


        void Joy_JoystickStateChanged(object sender, SharpDX.DirectInput.JoystickState state)
        {

            if (buttonPanel != null && buttonPanel.Controls.Count > 0)
            {
                for (int i = 0; i < buttonPanel.Controls.Count; i++)
                {
                    bool[] buttons = state.Buttons;
                    var b = (JoyButton)buttonPanel.Controls[i];
                    b.State = buttons[i];
                }
            }
            if (povsPanel != null && povsPanel.Controls.Count > 0)
            {
                int[] povs = state.PointOfViewControllers;
                for (int i = 0; i < povsPanel.Controls.Count; i++)
                {
                    var p = (JoyPov)povsPanel.Controls[i];
                    p.State = povs[i];
                }
            }
            if (sliderPanel != null && sliderPanel.Controls.Count > 0)
            {
                for(int i=0; i<sliderPanel.Controls.Count; i++){
                    var c = (JoySlider)sliderPanel.Controls[i];
                    c.State = state.Sliders[i];
                }
            }
        }

        void Joy_DeviceFound(object sender, DeviceFoundArguments e)
        {
            switch (e.DeviceType)
            {
#if BUTTON
                case MoJ.IO.Joy.DeviceType.Button:
                    AddButton(e.Instance.Name);
                    break;
#endif
#if POV
                case IO.Joy.DeviceType.Pov:
                    log.Debug("Pov detected");
                    AddPov(e.Instance.Name);
                    break;
#endif
#if SLIDER
                case IO.Joy.DeviceType.Slider:
                    AddSlider(e.Instance.Name);
                    break;
#endif
                default:
                    log.WarnFormat("unknown device detected '{0}'", e.Instance.Name);
                    break;
            }
        }
        #endregion

        #region Device Component Creation
#if BUTTON
        private void AddButton(string name)
        {
            if (buttonPanel == null)
            {
                buttonPanel = new FlowLayoutPanel() { Name = "Buttons", FlowDirection = FlowDirection.TopDown, WrapContents = false };
                var tp = new TabPage("Buttons");
                tabControl1.TabPages.Add(tp);
                tp.Controls.Add(buttonPanel);
                buttonPanel.Dock = DockStyle.Fill;
            }
            JoyButton b = new JoyButton();
            b.Name = name;
            b.Caption = name;
            buttonPanel.Controls.Add(b);
        }

#endif

#if SLIDER
        private void AddSlider(string name)
        {
            if (sliderPanel == null)
            {
                var tp = new TabPage("Sliders");
                tabControl1.TabPages.Add(tp);
                sliderPanel = new FlowLayoutPanel();
                sliderPanel.Name = "sliderPanel";
                tp.Controls.Add(sliderPanel);
                sliderPanel.Dock = DockStyle.Fill;
            }
            JoySlider s = new JoySlider();
            s.Caption = name;
            s.Name = name;
            sliderPanel.Controls.Add(s);
        }
#endif
#if POV
        private void AddPov(string name)
        {
            if (povsPanel == null)
            {
                povsPanel = new FlowLayoutPanel() { Name = "Povs" };
                var tp = new TabPage("Point of View");
                tabControl1.TabPages.Add(tp);
                tp.Controls.Add(povsPanel);
                povsPanel.Dock = DockStyle.Fill;
            }
            JoyPov p = new JoyPov()
            {
                Name = name,
                Caption = name
            };

            povsPanel.Controls.Add(p);
        }
#endif
        #endregion


        private void MainForm_Shown(object sender, EventArgs e)
        {
            string oldstick = Current.Config.Get("joystick");
            tasksEditorControl1.Tasks = Current.Config.Tasks;
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

                MessageBox.Show(ex.Message);
            }
        }

        private void StartPolling()
        {
            Current.Config.Set("joystick", joystickName.Text);
            Current.Config.Save();
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
            Current.Config.Save();
            Joy.ReleaseDevice();
            Joy.Dispose();
        }

        private void joystickName_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopPolling();
            StartPolling();
        }

        private void tabPageTasks_Leave(object sender, EventArgs e)
        {
            //Save config when we leave tasks.
            Current.Config.Save();
        }
    }
}
