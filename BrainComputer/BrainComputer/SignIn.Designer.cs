namespace BrainComputer
{
    partial class SignIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.lblInfos = new System.Windows.Forms.Label();
            this.btnDemoAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please sign in to play Brain Computer.";
            // 
            // tbxUsername
            // 
            this.tbxUsername.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxUsername.Location = new System.Drawing.Point(15, 25);
            this.tbxUsername.MaxLength = 30;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(212, 20);
            this.tbxUsername.TabIndex = 3;
            this.tbxUsername.Text = "Username";
            this.tbxUsername.TextChanged += new System.EventHandler(this.tbxUsername_TextChanged);
            this.tbxUsername.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxUsername_MouseDown);
            // 
            // tbxPassword
            // 
            this.tbxPassword.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxPassword.Location = new System.Drawing.Point(15, 51);
            this.tbxPassword.MaxLength = 30;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(212, 20);
            this.tbxPassword.TabIndex = 4;
            this.tbxPassword.Text = "Password";
            this.tbxPassword.TextChanged += new System.EventHandler(this.tbxPassword_TextChanged);
            this.tbxPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxPassword_MouseDown);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(15, 78);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(212, 23);
            this.btnSignIn.TabIndex = 5;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.Location = new System.Drawing.Point(15, 107);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(212, 23);
            this.btnCreateAccount.TabIndex = 6;
            this.btnCreateAccount.Text = "Create new account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // lblInfos
            // 
            this.lblInfos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfos.Location = new System.Drawing.Point(17, 107);
            this.lblInfos.Name = "lblInfos";
            this.lblInfos.Size = new System.Drawing.Size(215, 23);
            this.lblInfos.TabIndex = 7;
            this.lblInfos.Text = "Please";
            this.lblInfos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfos.Visible = false;
            // 
            // btnDemoAccount
            // 
            this.btnDemoAccount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDemoAccount.Location = new System.Drawing.Point(15, 137);
            this.btnDemoAccount.Name = "btnDemoAccount";
            this.btnDemoAccount.Size = new System.Drawing.Size(212, 23);
            this.btnDemoAccount.TabIndex = 8;
            this.btnDemoAccount.Text = "Use a Demo Account";
            this.btnDemoAccount.UseVisualStyleBackColor = true;
            this.btnDemoAccount.Click += new System.EventHandler(this.btnDemoAccount_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 167);
            this.Controls.Add(this.btnDemoAccount);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.lblInfos);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label lblInfos;
        private System.Windows.Forms.Button btnDemoAccount;
    }
}