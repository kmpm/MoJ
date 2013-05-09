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
    public partial class TasksEditorControl : UserControl
    {
        TaskCollection _tasks;
        public TasksEditorControl()
        {
            InitializeComponent();
        }

        public TaskCollection Tasks
        {
            get { return _tasks; }
            set {
                _tasks = value;
                taskSource.DataSource = _tasks;
            }
        }

        private void taskSource_CurrentChanged(object sender, EventArgs e)
        {
            taskControl1.Actions = ((Task)taskSource.Current).Actions;
        }
    }
}
