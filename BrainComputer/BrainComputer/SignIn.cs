using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainComputer
{
    public partial class SignIn : Form
    {
        #region Constructors
        public SignIn()
        {
            InitializeComponent();
            this.HeWantsToCreateANewAccount = false;

            this.KeyPreview = true;
            this.KeyDown += SignIn_KeyDown;
        }
        #endregion Constructors

        #region Properties
        public bool HeWantsToCreateANewAccount { get; set; }
        #endregion Properties

        #region Private void Methods

        #region Textboxes Control

        private void SignIn_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    CheckWhatHeWantsToDo();
                    break;
            }
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            tbxUsername.ForeColor = Color.Black;

            if (tbxPassword.Text == "")
            {
                tbxPassword.Text = "Password";
                tbxPassword.ForeColor = SystemColors.InactiveCaption;
            }

            if (tbxPassword.Text.Length > 5 && tbxUsername.Text.Length > 5 &&
                tbxPassword.Text != "Password" && tbxUsername.Text != "Username")
            {
                btnSignIn.Enabled = true;
            }
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            tbxPassword.ForeColor = Color.Black;
            tbxPassword.PasswordChar = '*';

            if (tbxUsername.Text == "")
            {
                tbxUsername.Text = "Username";
                tbxUsername.ForeColor = SystemColors.InactiveCaption;
            }

            if (tbxPassword.Text.Length > 5 && tbxUsername.Text.Length > 5 &&
                tbxPassword.Text != "Password" && tbxUsername.Text != "Username")
            {
                btnSignIn.Enabled = true;
            }
        }

        private void tbxUsername_MouseDown(object sender, MouseEventArgs e)
        {
            if (tbxPassword.Text == "")
            {
                tbxPassword.Text = "Password";
                tbxPassword.ForeColor = SystemColors.InactiveCaption;
                tbxPassword.PasswordChar = '\0';
            }

            if (tbxUsername.Text == "Username")
            {
                tbxUsername.Text = "";
                tbxUsername.ForeColor = Color.Black;
            }

            if (this.HeWantsToCreateANewAccount)
            {
                lblInfos.Text = "Please use at least 6 characters.";
                lblInfos.Visible = true;
                this.Height = 180;
            }
        }

        private void tbxPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (tbxUsername.Text == "")
            {
                tbxUsername.Text = "Username";
                tbxUsername.ForeColor = SystemColors.InactiveCaption;
            }

            if (tbxPassword.Text == "Password")
            {
                tbxPassword.Text = "";
                tbxPassword.ForeColor = Color.Black;
                tbxPassword.PasswordChar = '*';
            }

            if (this.HeWantsToCreateANewAccount)
            {
                lblInfos.Text = "Please use at least 6 characters.";
                lblInfos.Visible = true;
            }
        }

        #endregion Textboxes Control

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            CheckWhatHeWantsToDo();
        }

        private void CheckWhatHeWantsToDo()
        {
            if (this.HeWantsToCreateANewAccount)
            {
                CreateNewAccount();
            }
            else
            {
                ExecuteSignIn();
            }
        }

        private void ExecuteSignIn()
        {
            bool heEnteredTheUsernameAndThePassword =
                tbxUsername.Text != "Username" && tbxUsername.Text != "" &&
                tbxPassword.Text != "Password" && tbxPassword.Text != "";

            if (!heEnteredTheUsernameAndThePassword)
            {
                MessageBox.Show("Please enter your Username and your Password.", "Sign in");
            }
            else
            {
                using (BrainGameDBEntities3 context = new BrainGameDBEntities3())
                {
                    List<Users> users = context.Users.ToList();

                    if (users.Count == 0)
                    {
                        MessageBox.Show("You have no account. Please create a new account.");
                    }
                    else
                    {
                        bool userFound = false;
                        foreach (Users item in users)
                        {
                            if (item.Username == tbxUsername.Text)
                            {
                                userFound = true;
                                if (item.Password == tbxPassword.Text)
                                {
                                    OpenGame(item.Id);
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("The password that you entered does not match the username.");
                                    break;
                                }
                            }
                        }
                        if (!userFound)
                        {
                            MessageBox.Show("Sorry, but Brain Computer doesn't recognise your email.");
                        }
                    }
                }
            }
        }

        private void CreateNewAccount()
        {
            using (BrainGameDBEntities3 context = new BrainGameDBEntities3())
            {
                bool usernameIsUnique = true;
                CheckIfTheUsernameIsUnique(context, out usernameIsUnique);

                try
                {
                    if (usernameIsUnique)
                    {
                        Users currentUser = new Users();
                        currentUser.Username = tbxUsername.Text;
                        currentUser.Password = tbxPassword.Text;

                        context.Users.Add(currentUser);
                        context.SaveChanges();
                        MessageBox.Show("Your account has been successfully created.");
                        OpenGame(currentUser.Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem creating your account. Please try again later.\n{0}", ex.Message);
                }

            }
        }

        private void CheckIfTheUsernameIsUnique(BrainGameDBEntities3 context, out bool usernameIsUnique)
        {
            usernameIsUnique = true;
            List<Users> users = context.Users.ToList();

            foreach (Users item in users)
            {
                if (item.Username == tbxUsername.Text)
                {
                    MessageBox.Show("The username that you've chosen already exists.\nPlease try another one.");
                    usernameIsUnique = false;
                    break;
                }
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            this.HeWantsToCreateANewAccount = true;
            this.Height = 150;
            btnCreateAccount.Visible = false;
            btnSignIn.Text = "Create Account";
            btnSignIn.Enabled = false;
        }

        private void OpenGame(int id)
        {
            FormMainMenu form1 = new FormMainMenu(id);
            form1.Parent = this;
            this.Hide();
            this.tbxUsername.Text = "Username";
            this.tbxUsername.ForeColor = SystemColors.InactiveCaption;
            this.tbxPassword.Text = "Password";
            this.tbxPassword.ForeColor = SystemColors.InactiveCaption;
            this.tbxPassword.PasswordChar = '\0';
            this.btnSignIn.Text = "Sign in";
            this.btnCreateAccount.Visible = true;
            this.Height = 206;

            form1.Show();
        }

        private void btnDemoAccount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The account with the username = \"aaaaaa\" and with the password = \"aaaaaa\" will be oppened from the database.\nYou can also connect to this game manually, using this account.\nPlease make sure that you have already created the database by using the Sql query given in the file \"BrainGameDB.sql\".");

            try
            {
                int id = 1;
                using (BrainGameDBEntities3 context = new BrainGameDBEntities3())
                {
                    var selected = context.Users
                        .Where(x => x.Username == "aaaaaa")
                        .Select(x => x.Id).ToList();

                    foreach (int item in selected)
                    {
                        id = item;
                    }
                }
                OpenGame(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem opening the game. Please make sure that you have already created the database by using the Sql querry from the file \"BrainGameDB.sql\".\n{0}", ex.Message);
            }
        }
        #endregion Private void Methods
    }
}
