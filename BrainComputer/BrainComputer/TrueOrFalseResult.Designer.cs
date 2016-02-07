namespace BrainComputer
{
    partial class TrueOrFalseResult
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
            this.tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx
            // 
            this.tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx.Location = new System.Drawing.Point(12, 12);
            this.tbx.Name = "tbx";
            this.tbx.ReadOnly = true;
            this.tbx.Size = new System.Drawing.Size(270, 62);
            this.tbx.TabIndex = 0;
            this.tbx.Text = "Corect !!";
            this.tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrueOrFalseResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 86);
            this.Controls.Add(this.tbx);
            this.Name = "TrueOrFalseResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TrueOrFalseResult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx;
    }
}