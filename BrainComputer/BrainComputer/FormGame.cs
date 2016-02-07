using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

namespace BrainComputer
{
    public partial class FormGame : Form
    {
        #region Fields
        private bool statisticsAreBeeingOpened = false;
        private int numberOfNumbersFirst;
        private int numberOfNumbersSecond;
        private int[] numberOfSigns;

        private string[] signs = { "+", "-", "x", "/" };

        private List<int> signsList;

        private int theFirstNumber;
        private int theSecondNumber;
        private string theSign;
        private double theResult;
        private List<int> theResultList;
        private List<int> givenResultList;
        private double theGivenResult;
        #endregion Fields

        #region Properties
        public FormMainMenu Parent { get; set; }
        public List<Results> ResultsList { get; set; }
        public int UserId { get; set; }
        public int CurrentSign { get; set; }
        public Stopwatch Sw { get; set; }
        #endregion Properties

        #region Constructors
        public FormGame(int numberOfNumbersFirst, int numberOfNumbersSecond, int[] numberOfSigns, int userId)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.ResultsList = new List<Results>();
            this.UserId = userId;

            this.FormClosing += Computer_FormClosing;

            this.numberOfNumbersFirst = numberOfNumbersFirst;
            this.numberOfNumbersSecond = numberOfNumbersSecond;
            this.numberOfSigns = numberOfSigns;

            // It passes in this list the signs that can be used
            // Example: for "+" there must be in the list a number 0. for "-" 1 ,, "x" - 2 ,, "/" - 3
            CompleteSignsList();

            GiveNewEcuation();
            CalculateTheResult();

            this.ActiveControl = tbxResult;
        }
        #endregion Constructors

        #region Private Methods

        private void GiveNewEcuation()
        {
            SetTheSign();
            SetTheTwoNumbers();
            StartWatch();
        }

        private void StartWatch()
        {
            this.Sw = new Stopwatch();
            this.Sw.Start();
        }

        private void StopWatch()
        {
            this.Sw.Stop();
        }

        private void TheGivenResultIsFalse()
        {
            StopWatch();
            SaveTheResultsInResultsList(false);
            ChangeTbxSeconds();

            TrueOrFalseResult tofr = new TrueOrFalseResult(string.Format("!! {0} !!", theResult.ToString()));
            tofr.Location = new Point(700, 200);
            tofr.Show();

            tbxCorectResult.Text = theResult.ToString();
            tbxCorectResult.Visible = true;
            lblYouWrote.Text = string.Format("You wrote: {0}", tbxResult.Text);
            lblYouWrote.Visible = true;

            this.Refresh();

            MakeBadSound();

            tofr.Close();

            tbxCorectResult.Visible = false;
            lblYouWrote.Visible = false;

            GiveNewEcuation();
            CalculateTheResult();
            tbxResult.Text = "";
        }

        private void TheGivenResultIsCorect()
        {
            StopWatch();
            SaveTheResultsInResultsList(true);
            ChangeTbxSeconds();

            TrueOrFalseResult trueOrFalseResultForm = new TrueOrFalseResult("Corect!");
            trueOrFalseResultForm.Location = new Point(700, 200);
            trueOrFalseResultForm.Show();

            MakeGoodSound();

            trueOrFalseResultForm.Close();

            GiveNewEcuation();
            tbxResult.Text = "";
            CalculateTheResult();
        }

        private void SaveTheResultsInResultsList(bool correct)
        {
            double seconds = Math.Round((double)this.Sw.ElapsedMilliseconds / 1000, 2);

            Results currentResult = new Results();
            currentResult.UserId = this.UserId;
            currentResult.Date = DateTime.Now;
            currentResult.Operation = this.CurrentSign;
            currentResult.FirstNumber = this.theFirstNumber;
            currentResult.SecondNumber = this.theSecondNumber;
            currentResult.Result = (decimal)this.theResult;
            currentResult.Succeeded = correct;
            currentResult.Time = (float)seconds;

            this.ResultsList.Add(currentResult);
        }

        private void ChangeTbxSeconds()
        {
            tbxSeconds.Text = string.Format("{0} seconds", Math.Round((double)this.Sw.ElapsedMilliseconds / 1000, 2).ToString());
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            if (btnEndGame.Text == "End Game")
            {
                EndGame();
            }
            else
            {
                NewGame();
            }
        }

        private void EndGame()
        {
            btnEndGame.Text = "Restart";
            this.Sw.Stop();
            tbxResult.Enabled = false;
            btnStatistics.Enabled = true;
            tbxOne.Text = "";
            tbxTwo.Text = "";
            tbxSeconds.Text = "";
            tbxResult.Text = "";
            tbxEqual.Text = "";
            tbxSign.Text = "";

            try
            {
                using (BrainGameDBEntities3 context = new BrainGameDBEntities3())
                {
                    foreach (Results item in this.ResultsList)
                    {
                        context.Results.Add(item);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("We are sorry, but there was a problem saving your results in the database");
            }

            this.ResultsList = new List<Results>();
        }

        private void NewGame()
        {
            btnEndGame.Text = "End Game";
            tbxResult.Enabled = true;
            btnStatistics.Enabled = false;
            this.ActiveControl = tbxResult;
            GiveNewEcuation();
            CalculateTheResult();
            this.Sw = new Stopwatch();
            this.Sw.Start();
        }

        private void Computer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnEndGame.Text == "End Game")
            {
                EndGame();
            }
            if (!this.statisticsAreBeeingOpened)
            {
                this.Parent.Show();
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion Private Methods
    }
}
