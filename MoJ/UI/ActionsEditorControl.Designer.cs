namespace MoJ.UI
{
    partial class ActionsEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionsEditorControl));
            this.actionNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.actionSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.actionGridView = new System.Windows.Forms.DataGridView();
            this.methodColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.actionNavigator)).BeginInit();
            this.actionNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // actionNavigator
            // 
            this.actionNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.actionNavigator.BindingSource = this.actionSource;
            this.actionNavigator.CountItem = this.bindingNavigatorCountItem;
            this.actionNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.actionNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.actionNavigator.Location = new System.Drawing.Point(0, 0);
            this.actionNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.actionNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.actionNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.actionNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.actionNavigator.Name = "actionNavigator";
            this.actionNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.actionNavigator.Size = new System.Drawing.Size(372, 27);
            this.actionNavigator.TabIndex = 0;
            this.actionNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // actionSource
            // 
            this.actionSource.DataSource = typeof(MoJ.Action);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // actionGridView
            // 
            this.actionGridView.AutoGenerateColumns = false;
            this.actionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.methodColumn,
            this.dataColumn,
            this.delayColumn});
            this.actionGridView.DataSource = this.actionSource;
            this.actionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionGridView.Location = new System.Drawing.Point(0, 27);
            this.actionGridView.Name = "actionGridView";
            this.actionGridView.RowTemplate.Height = 24;
            this.actionGridView.Size = new System.Drawing.Size(372, 165);
            this.actionGridView.TabIndex = 1;
            this.actionGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.actionGridView_CellEndEdit);
            this.actionGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.actionGridView_CellValueNeeded);
            this.actionGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.actionGridView_DataError);
            // 
            // methodColumn
            // 
            this.methodColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.methodColumn.DataPropertyName = "Method";
            this.methodColumn.DisplayStyleForCurrentCellOnly = true;
            this.methodColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.methodColumn.HeaderText = "Method";
            this.methodColumn.MinimumWidth = 150;
            this.methodColumn.Name = "methodColumn";
            this.methodColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.methodColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.methodColumn.Width = 150;
            // 
            // dataColumn
            // 
            this.dataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataColumn.DataPropertyName = "Data";
            this.dataColumn.HeaderText = "Data";
            this.dataColumn.Name = "dataColumn";
            this.dataColumn.Width = 63;
            // 
            // delayColumn
            // 
            this.delayColumn.DataPropertyName = "Delay";
            this.delayColumn.HeaderText = "Delay";
            this.delayColumn.Name = "delayColumn";
            // 
            // ActionsEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionGridView);
            this.Controls.Add(this.actionNavigator);
            this.MinimumSize = new System.Drawing.Size(372, 192);
            this.Name = "ActionsEditorControl";
            this.Size = new System.Drawing.Size(372, 192);
            ((System.ComponentModel.ISupportInitialize)(this.actionNavigator)).EndInit();
            this.actionNavigator.ResumeLayout(false);
            this.actionNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource actionSource;
        private System.Windows.Forms.BindingNavigator actionNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView actionGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn methodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delayColumn;
    }
}
