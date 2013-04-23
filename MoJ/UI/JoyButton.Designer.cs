namespace MoJ.UI
{
    partial class JoyButton
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this._mode = new System.Windows.Forms.ComboBox();
            this._rising = new System.Windows.Forms.ComboBox();
            this._falling = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 17);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(22, 6);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(65, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "[nameLabel]";
            // 
            // _mode
            // 
            this._mode.FormattingEnabled = true;
            this._mode.Location = new System.Drawing.Point(123, 4);
            this._mode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._mode.Name = "_mode";
            this._mode.Size = new System.Drawing.Size(92, 21);
            this._mode.TabIndex = 2;
            this._mode.Text = "Trigger";
            this._mode.TextUpdate += new System.EventHandler(this.Combo_TextUpdate);
            this._mode.TextChanged += new System.EventHandler(this.Combo_TextUpdate);
            // 
            // _rising
            // 
            this._rising.FormattingEnabled = true;
            this._rising.Location = new System.Drawing.Point(258, 3);
            this._rising.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._rising.Name = "_rising";
            this._rising.Size = new System.Drawing.Size(92, 21);
            this._rising.TabIndex = 3;
            this._rising.Text = "NONE";
            this._rising.TextUpdate += new System.EventHandler(this.Combo_TextUpdate);
            this._rising.TextChanged += new System.EventHandler(this.Combo_TextUpdate);
            // 
            // _falling
            // 
            this._falling.FormattingEnabled = true;
            this._falling.Location = new System.Drawing.Point(375, 3);
            this._falling.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._falling.Name = "_falling";
            this._falling.Size = new System.Drawing.Size(92, 21);
            this._falling.TabIndex = 4;
            this._falling.Text = "NONE";
            this._falling.TextUpdate += new System.EventHandler(this.Combo_TextUpdate);
            this._falling.TextChanged += new System.EventHandler(this.Combo_TextUpdate);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(236, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 16);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(355, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 16);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // JoyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._falling);
            this.Controls.Add(this._rising);
            this.Controls.Add(this._mode);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(472, 28);
            this.MinimumSize = new System.Drawing.Size(472, 28);
            this.Name = "JoyButton";
            this.Size = new System.Drawing.Size(472, 28);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox _mode;
        private System.Windows.Forms.ComboBox _rising;
        private System.Windows.Forms.ComboBox _falling;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
