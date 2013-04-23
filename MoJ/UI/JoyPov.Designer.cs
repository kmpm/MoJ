namespace MoJ.UI
{
    partial class JoyPov
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
            this.heading = new System.Windows.Forms.Label();
            this.caption = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // heading
            // 
            this.heading.AutoSize = true;
            this.heading.Location = new System.Drawing.Point(3, 27);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(73, 17);
            this.heading.TabIndex = 0;
            this.heading.Text = "NEUTRAL";
            this.heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // caption
            // 
            this.caption.AutoSize = true;
            this.caption.Location = new System.Drawing.Point(3, 0);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(54, 17);
            this.caption.TabIndex = 1;
            this.caption.Text = "caption";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.caption);
            this.panel1.Controls.Add(this.heading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 67);
            this.panel1.TabIndex = 2;
            // 
            // JoyPov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(137, 67);
            this.Name = "JoyPov";
            this.Size = new System.Drawing.Size(137, 67);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Label caption;
        private System.Windows.Forms.Panel panel1;
    }
}
