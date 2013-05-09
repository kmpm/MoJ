// Copyright (C) 2013 Peter Magnusson
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

       

       

        private void Set(string name, string value)
        {
            name = nameLabel.Text + "_" + name;
            Current.Config.Set(name, value);
        }

        private string Get(string name)
        {
            name = nameLabel.Text + "_" + name;
            return Current.Config.Get(name);
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
                    return JoyButtonMode.Trigger;
                }
            }
        }

        public Task Rising
        {
            get
            {
                if (_rising.Text == string.Empty) return null;
                return (from t in Current.Config.Tasks 
                        where t.Name == _rising.Text 
                        select t).SingleOrDefault();
            }
        }

        public Task Falling
        {
            get
            {
                if (_falling.Text == string.Empty) return null;
                return (from t in Current.Config.Tasks
                        where t.Name == _falling.Text
                        select t).SingleOrDefault();
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
                    pictureBox1.BackColor = Color.Red;
                }
                else
                {
                    pictureBox1.BackColor = SystemColors.Control;
                }

                if (Mode != JoyButtonMode.Toggle)
                {
                    DoFalling();
                }
            }
        }

        private void DoRising()
        {
            var t = Rising;
            if (t == null) return;
            MoJ.Executor.RunThreaded(t);                       
        }
        
        private void DoFalling()
        {
            var t = Falling;
            if (t == null) return;          
            MoJ.Executor.RunThreaded(t);
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

            Current.Config.Save();

            if (((ComboBox)sender).Name == "_mode")
            {
                CheckMode();
            }
        }

        private void CheckMode()
        {          
            _rising.Items.Clear();
            _falling.Items.Clear();

            var keys = from t in Current.Config.Tasks
                       select t.Name;
          
            _rising.Items.AddRange(keys.ToArray());
            _falling.Items.AddRange(keys.ToArray());      
        }
    }
}
