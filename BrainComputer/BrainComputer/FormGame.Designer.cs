namespace BrainComputer
{
    partial class FormGame
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
            this.tbxOne = new System.Windows.Forms.TextBox();
            this.tbxSign = new System.Windows.Forms.TextBox();
            this.tbxTwo = new System.Windows.Forms.TextBox();
            this.tbxEqual = new System.Windows.Forms.TextBox();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.chbSounds = new System.Windows.Forms.CheckBox();
            this.tbxCorectResult = new System.Windows.Forms.TextBox();
            this.lblYouWrote = new System.Windows.Forms.Label();
            this.btnEndGame = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.tbxSeconds = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxOne
            // 
            this.tbxOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxOne.Location = new System.Drawing.Point(12, 26);
            this.tbxOne.Name = "tbxOne";
            this.tbxOne.ReadOnly = true;
            this.tbxOne.Size = new System.Drawing.Size(143, 40);
            this.tbxOne.TabIndex = 0;
            this.tbxOne.Text = "23";
            this.tbxOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSign
            // 
            this.tbxSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tbxSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSign.Location = new System.Drawing.Point(161, 26);
            this.tbxSign.Name = "tbxSign";
            this.tbxSign.ReadOnly = true;
            this.tbxSign.Size = new System.Drawing.Size(46, 40);
            this.tbxSign.TabIndex = 1;
            this.tbxSign.Text = "+";
            this.tbxSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxTwo
            // 
            this.tbxTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTwo.Location = new System.Drawing.Point(213, 26);
            this.tbxTwo.Name = "tbxTwo";
            this.tbxTwo.ReadOnly = true;
            this.tbxTwo.Size = new System.Drawing.Size(143, 40);
            this.tbxTwo.TabIndex = 2;
            this.tbxTwo.Text = "23";
            this.tbxTwo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxEqual
            // 
            this.tbxEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tbxEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEqual.Location = new System.Drawing.Point(362, 26);
            this.tbxEqual.Name = "tbxEqual";
            this.tbxEqual.ReadOnly = true;
            this.tbxEqual.Size = new System.Drawing.Size(46, 40);
            this.tbxEqual.TabIndex = 3;
            this.tbxEqual.Text = "=";
            this.tbxEqual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxResult
            // 
            this.tbxResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxResult.Location = new System.Drawing.Point(414, 26);
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.Size = new System.Drawing.Size(143, 40);
            this.tbxResult.TabIndex = 4;
            this.tbxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxResult.TextChanged += new System.EventHandler(this.tbxResult_TextChanged);
            // 
            // chbSounds
            // 
            this.chbSounds.AutoSize = true;
            this.chbSounds.Checked = true;
            this.chbSounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSounds.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSounds.Location = new System.Drawing.Point(14, 5);
            this.chbSounds.Name = "chbSounds";
            this.chbSounds.Size = new System.Drawing.Size(66, 19);
            this.chbSounds.TabIndex = 5;
            this.chbSounds.Text = "Sounds";
            this.chbSounds.UseVisualStyleBackColor = true;
            // 
            // tbxCorectResult
            // 
            this.tbxCorectResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbxCorectResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCorectResult.Location = new System.Drawing.Point(414, 26);
            this.tbxCorectResult.Name = "tbxCorectResult";
            this.tbxCorectResult.Size = new System.Drawing.Size(143, 40);
            this.tbxCorectResult.TabIndex = 8;
            this.tbxCorectResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCorectResult.Visible = false;
            // 
            // lblYouWrote
            // 
            this.lblYouWrote.AutoSize = true;
            this.lblYouWrote.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYouWrote.Location = new System.Drawing.Point(451, 9);
            this.lblYouWrote.Name = "lblYouWrote";
            this.lblYouWrote.Size = new System.Drawing.Size(66, 15);
            this.lblYouWrote.TabIndex = 9;
            this.lblYouWrote.Text = "You wrote: ";
            this.lblYouWrote.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblYouWrote.Visible = false;
            // 
            // btnEndGame
            // 
            this.btnEndGame.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndGame.Location = new System.Drawing.Point(14, 74);
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.Size = new System.Drawing.Size(143, 23);
            this.btnEndGame.TabIndex = 10;
            this.btnEndGame.Text = "End Game";
            this.btnEndGame.UseVisualStyleBackColor = true;
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Enabled = false;
            this.btnStatistics.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(213, 74);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(143, 23);
            this.btnStatistics.TabIndex = 11;
            this.btnStatistics.Text = "Main Menu";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // tbxSeconds
            // 
            this.tbxSeconds.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSeconds.Location = new System.Drawing.Point(414, 74);
            this.tbxSeconds.Name = "tbxSeconds";
            this.tbxSeconds.ReadOnly = true;
            this.tbxSeconds.Size = new System.Drawing.Size(143, 23);
            this.tbxSeconds.TabIndex = 12;
            this.tbxSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 104);
            this.Controls.Add(this.tbxSeconds);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnEndGame);
            this.Controls.Add(this.lblYouWrote);
            this.Controls.Add(this.tbxCorectResult);
            this.Controls.Add(this.chbSounds);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.tbxEqual);
            this.Controls.Add(this.tbxTwo);
            this.Controls.Add(this.tbxSign);
            this.Controls.Add(this.tbxOne);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "So... How much ?...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxOne;
        private System.Windows.Forms.TextBox tbxSign;
        private System.Windows.Forms.TextBox tbxTwo;
        private System.Windows.Forms.TextBox tbxEqual;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.CheckBox chbSounds;
        private System.Windows.Forms.TextBox tbxCorectResult;
        private System.Windows.Forms.Label lblYouWrote;
        private System.Windows.Forms.Button btnEndGame;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.TextBox tbxSeconds;
    }
}