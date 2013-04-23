using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoJ.UI
{
    public partial class JoySlider : UserControl
    {
        private int _state = 0;
        public JoySlider()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        public int State
        {
            set { _state = value; }
        }
    }
}
