namespace MoJ.UI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.joystickName = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageTasks = new System.Windows.Forms.TabPage();
            this.tasksEditorControl1 = new MoJ.UI.TasksEditorControl();
            this.tabControl1.SuspendLayout();
            this.tabPageTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Joystick:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // joystickName
            // 
            this.joystickName.FormattingEnabled = true;
            this.joystickName.Location = new System.Drawing.Point(72, 14);
            this.joystickName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.joystickName.Name = "joystickName";
            this.joystickName.Size = new System.Drawing.Size(175, 24);
            this.joystickName.TabIndex = 2;
            this.joystickName.SelectedIndexChanged += new System.EventHandler(this.joystickName_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageTasks);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 73);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 492);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Location = new System.Drawing.Point(4, 25);
            this.tabPageMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMain.Size = new System.Drawing.Size(808, 463);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "General";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageTasks
            // 
            this.tabPageTasks.Controls.Add(this.tasksEditorControl1);
            this.tabPageTasks.Location = new System.Drawing.Point(4, 25);
            this.tabPageTasks.Name = "tabPageTasks";
            this.tabPageTasks.Size = new System.Drawing.Size(808, 463);
            this.tabPageTasks.TabIndex = 1;
            this.tabPageTasks.Text = "Tasks";
            this.tabPageTasks.UseVisualStyleBackColor = true;
            this.tabPageTasks.Leave += new System.EventHandler(this.tabPageTasks_Leave);
            // 
            // tasksEditorControl1
            // 
            this.tasksEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.tasksEditorControl1.Name = "tasksEditorControl1";
            this.tasksEditorControl1.Size = new System.Drawing.Size(808, 463);
            this.tasksEditorControl1.TabIndex = 0;
            this.tasksEditorControl1.Tasks = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.joystickName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MoJ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox joystickName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageTasks;
        private TasksEditorControl tasksEditorControl1;

    }
}