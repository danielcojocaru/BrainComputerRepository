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
    public partial class FormMainMenu : Form
    {
        #region Properties

        public SignIn Parent { get; set; }
        public int UserId { get; set; }

        #endregion Properties

        #region Fields
        private int[] selectedSignsIndexes = { 1, 1, 1, 1 };
        #endregion Fields

        #region Constructors
        public FormMainMenu(int userId)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.UserId = userId;

            CompleteComboBoxesAndInitializeSelectedIndex();

            this.FormClosing += Form1_FormClosing;
        }
        #endregion Constructors

        #region Private Methods

        private void CompleteComboBoxesAndInitializeSelectedIndex()
        {
            for (int i = 1; i < 5; i++)
            {
                cbxOne.Items.Add(i);
                cbxTwo.Items.Add(i);
            }

            cbxOne.SelectedIndex = 0;
            cbxTwo.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenGame();
        }

        private void OpenGame()
        {
            FormGame nc = new FormGame((int)cbxOne.SelectedItem, (int)cbxTwo.SelectedItem, selectedSignsIndexes, this.UserId);
            nc.Parent = this;
            this.Hide();
            nc.ShowDialog();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            AlterTheSelectedSignsIndexesVector(sender);
        }

        private void AlterTheSelectedSignsIndexesVector(object sender)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            int currentTabIndex = currentCheckBox.TabIndex;

            if (currentCheckBox.Checked)
            {
                selectedSignsIndexes[currentTabIndex] = 1;
            }
            else
            {
                selectedSignsIndexes[currentTabIndex] = 0;
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics(this.UserId);
            statistics.Parent = this;
            this.Hide();
            statistics.Show();
        }

        #endregion Private Methods
    }
}
