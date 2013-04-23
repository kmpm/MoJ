using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace MoJ.UI
{
    public partial class JoyButton : UserControl
    {

        private bool _state;

        private bool _isRaised = false;
        private bool disableSave=true;

        public JoyButton()
        {
            InitializeComponent();
            _mode.Items.AddRange(Enum.GetNames(typeof(JoyButtonMode)));
            _rising.Items.AddRange(Enum.GetNames(typeof(Mouse.MouseEventFlags)));
            _falling.Items.AddRange(Enum.GetNames(typeof(Mouse.MouseEventFlags)));
        }

        public string Caption
        {
            get { return nameLabel.Text; }
            set 
            { 
                nameLabel.Text = value;
                disableSave = true;
                _mode.Text = Get("mode");
                _rising.Text = Get("rising");
                _falling.Text = Get("falling");
                disableSave = false;
            }
        }

        private void Set(string name, string value)
        {
            name = nameLabel.Text + "_" + name;
            Config.Set(name, value);
        }

        private string Get(string name)
        {
            name = nameLabel.Text + "_" + name;
            return Config.Get(name);
        }

        public JoyButtonMode Mode
        {
            get
            {
                return (JoyButtonMode)Enum.Parse(typeof(JoyButtonMode), _mode.Text);
            }
        }

        public Mouse.MouseEventFlags Rising
        {
            get
            {
                return (Mouse.MouseEventFlags)Enum.Parse(typeof(Mouse.MouseEventFlags), _rising.Text);
            }
        }

        public Mouse.MouseEventFlags Falling
        {
            get
            {
                return (Mouse.MouseEventFlags)Enum.Parse(typeof(Mouse.MouseEventFlags), _falling.Text);
            }
        }

        public bool State
        {
            get
            {
                return _state;
            }
            set
            {
                if (value != _state)
                {                    
                    OnStateChange(value);
                    _state = value;
                }
                
            }
        }

        protected void OnStateChange(bool state)
        {
            if (state)
            {
                pictureBox1.BackColor = Color.Green;

                if (Mode == JoyButtonMode.Toggle)
                {
                    Toggle();
                }
                else
                {
                    DoRising();
                }
            }
            else
            {
                if (_isRaised)
                {
                    pictureBox1.BackColor = Color.LightYellow;
                }
                else
                {
                    pictureBox1.BackColor = Color.Gray;
                }

                if (Mode != JoyButtonMode.Toggle)
                {
                    DoFalling();
                }
            }
        }

        private void DoRising()
        {
            if (Rising == Mouse.MouseEventFlags.NONE) return;
            Mouse.MouseEvent(Rising);
        }
        
        private void DoFalling()
        {
            if (Falling == Mouse.MouseEventFlags.NONE) return;
            Mouse.MouseEvent(Falling);
        }

        private void Toggle()
        {
            _isRaised = !_isRaised;
            if (_isRaised)
            {
                DoRising();
            }
            else
            {
                DoFalling();
            }
        }

        private void Combo_TextUpdate(object sender, EventArgs e)
        {
            if (disableSave) return;
            Set("mode", _mode.Text);
            Set("rising", _rising.Text);
            Set("falling", _falling.Text);
            
            Config.Save();
        }
    }
}
