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

        private Type optionType;

        public JoyButton()
        {
            InitializeComponent();
            _mode.Items.AddRange(Enum.GetNames(typeof(JoyButtonMode)));
            
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
                CheckMode();
                disableSave = false;
            }
        }

        private void MouseOptions()
        {
            _rising.Items.Clear();
            _falling.Items.Clear();
            optionType = typeof(IO.Inputs.MouseEventFlags);
            _rising.Items.AddRange(Enum.GetNames(optionType));
            _falling.Items.AddRange(Enum.GetNames(optionType));
        }

        private void KeyOptions()
        {
            _rising.Items.Clear();
            _falling.Items.Clear();

            optionType = typeof(IO.Inputs.KeybdEventFlags);
            _rising.Items.AddRange(Enum.GetNames(optionType));
            _falling.Items.AddRange(Enum.GetNames(optionType));
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
                JoyButtonMode m;
                if (Enum.TryParse(_mode.Text, out m))
                {
                    return m;
                }
                else
                {
                    return JoyButtonMode.TriggerMouse;
                }
            }
        }

        public object Rising
        {
            get
            {
                if (_rising.Text == string.Empty) return null;
                return Enum.Parse(optionType, _rising.Text);
            }
        }

        public object Falling
        {
            get
            {
                if (_falling.Text == string.Empty) return null;
                return Enum.Parse(optionType, _falling.Text);
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

                if (Mode == JoyButtonMode.ToggleMouse)
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
                    pictureBox1.BackColor = Color.Red;
                }
                else
                {
                    pictureBox1.BackColor = SystemColors.Control;
                }

                if (Mode != JoyButtonMode.ToggleMouse)
                {
                    DoFalling();
                }
            }
        }

        private void DoRising()
        {
            if (Rising == null) return;
            if ((int)Rising == 0) return;
            if (optionType == typeof(IO.Inputs.MouseEventFlags))
            {
                IO.Inputs.MouseEvent((IO.Inputs.MouseEventFlags)Rising);
            }
            else
            {
                IO.Inputs.KeybdEvent((IO.Inputs.KeybdEventFlags)Rising);
            }
            
        }
        
        private void DoFalling()
        {
            if (Falling == null) return;
            if ((int)Falling == 0) return;
            if (optionType == typeof(IO.Inputs.MouseEventFlags))
            {
                IO.Inputs.MouseEvent((IO.Inputs.MouseEventFlags)Falling);
            }
            else
            {
                IO.Inputs.KeybdEvent((IO.Inputs.KeybdEventFlags)Falling);
            }
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

            if (((ComboBox)sender).Name == "_mode")
            {
                CheckMode();
            }
        }

        private void CheckMode()
        {
            if (_mode.Text.Contains("Key"))
            {
                KeyOptions();
            }
            else
            {
                MouseOptions();
            }
        }
    }
}
