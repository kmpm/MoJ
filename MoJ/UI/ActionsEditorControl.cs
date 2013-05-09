// Copyright (C) 2013 Peter Magnusson
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
    public partial class ActionsEditorControl : UserControl
    {
        ActionCollection _actions;
        public ActionsEditorControl()
        {
            InitializeComponent();

            methodColumn.DataSource = Enum.GetValues(typeof(ActionMethod));
            methodColumn.ValueType = typeof(ActionMethod);
        }

        public ActionCollection Actions
        {
            get { return _actions; }
            set
            {
                _actions = value;
                actionSource.DataSource = _actions;
            }
        }

        private void actionGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("ERROR: {0}", e.Exception.Message);
        }

        private void actionGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (actionGridView.Columns[e.ColumnIndex].DataPropertyName == "Method")
            {
                Console.WriteLine("End Edit: Method");
            }
        }

        private void actionGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            Console.WriteLine("CellValue");
        }

    }
}
