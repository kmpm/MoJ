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
    public partial class JoyPov : UserControl
    {
        private int _state=-10;

        public enum PovHeading
        {
            Center = -1,
            North = 0,
            NorthEast = 4500,
            East = 9000,
            SouthEast = 13500,
            South = 18000,
            SouthWest = 22500,
            West = 27000,
            NorthWest = 31500
        }


        public JoyPov()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get
            {
                return caption.Text;
            }
            set
            {
                caption.Text = value;
            }
        }

        public int State
        {
            set
            {
                if (value != _state)
                {
                    PovHeading h = PovHeading.Center;
                    if (Enum.TryParse(value.ToString(), out h))
                    {
                        heading.Text = Enum.GetName(typeof(PovHeading), h);
                    }
                    _state = value;
                }
            }
        }
    }
}
