using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BrainComputer
{
    public partial class Statistics : Form
    {
        #region Fields
        private int Id;
        private const int numberOfDigits = 4;
        private EngineStatistics engine;
        private List<string> seriesNames;
        private List<string> xChartValuesForFirstChart;
        private List<string> xChartValuesForSecondChart;
        private List<string> titlesForFirstPie;
        private List<string> titlesForSecondPie;
        private List<string> titlesForSecondChart;
        #endregion Fields

        #region Properties
        public FormMainMenu Parent { get; set; }
        public FormGame SecondParent { get; set; }
        #endregion Properties

        #region Constructors
        public Statistics(int id)
        {
            InitializeComponent();
            this.Id = id;

            engine = new EngineStatistics(this.Id);

            CompleteSeriesNamesList();
            CompleteXChartValuesListForFirstChart();
            CompleteTitlesForFirstPie();
            CompleteXChartValuesListForSecondChart();
            CompleteTitlesForSecondPie();
            CompleteTitlesForSecondChart();

            CompleteComboboxes();
            cbxOperations.SelectedIndex = 0;
            cbxNumberOfDigits.SelectedIndex = 0;
            CreateTheCheckBoxesEvents();
        }
        #endregion Constructors

        #region Private Methods
        // It turns on or off the corresponding serie from "graphOne" chart in "groupBoxOne"
        private void ChechBoxesTwo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int serieIndex = checkBox.TabIndex - 1;
            bool isChecked = checkBox.Checked;
            int index = -1;

            foreach (Series item in graphTwo.Series)
            {
                index++;
                if (index == serieIndex)
                {
                    if (isChecked)
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                    }
                    break;
                }
            }
        }

        // It turns on or off the corresponding serie from "graphTwo" chart in "groupBoxTwo"
        private void ChechBoxesOne_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int serieIndex = checkBox.TabIndex - 1;
            bool isChecked = checkBox.Checked;
            int index = -1;

            foreach (Series item in graphOne.Series)
            {
                index++;
                if (index == serieIndex)
                {
                    if (isChecked)
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                    }
                    break;
                }
            }

        }

        private void cbxOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModifyChartAndPieOne();
            ModifyGraphOne();
        }

        private void ModifyGraphOne()
        {
            graphOne.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            int index = -1;

            foreach (Series item in this.graphOne.Series)
            {
                item.Points.Clear();
                index++;

                List<DateTime> xValues = engine.DailyRateOperator[index].Dates;
                List<int> yValues = engine.DailyRateOperator[index].Rates;

                for (int i = 0; i < xValues.Count; i++)
                {
                    item.Points.AddXY(xValues[i], yValues[i]);
                }
            }
        }

        private void ChangeFirstPie(List<string> xValues, List<int> yValues)
        {
            foreach (Title item in chrtPieOne.Titles)
            {
                item.Text = this.titlesForFirstPie[cbxOperations.SelectedIndex];
            }
            foreach (Series item in chrtPieOne.Series)
            {
                item.Points.Clear();
                for (int i = 0; i < xValues.Count - 1; i++)
                {
                    item.Points.AddXY(xValues[i + 1], yValues[i]);
                }
            }
        }

        private void ModifyChartAndPieOne()
        {
            List<int> yValuesForChrtProcent = new List<int>();
            List<int> yValuesForPieNumber = new List<int>();

            // Initializing the lists with the Y Values for the chart and for the pie
            yValuesForChrtProcent = CopyTheIntList(this.engine.DoubleListRate[cbxOperations.SelectedIndex]);
            yValuesForPieNumber = CopyTheIntList(this.engine.DoubleListSum[cbxOperations.SelectedIndex]);
            yValuesForPieNumber.RemoveAt(0);
            lblPieTotalOne.Text = string.Format("Total = {0}", this.engine.DoubleListSum[cbxOperations.SelectedIndex][0].ToString());

            ChangeChartProcentOne(this.xChartValuesForFirstChart, yValuesForChrtProcent);
            ChangeFirstPie(this.xChartValuesForFirstChart, yValuesForPieNumber);
        }

        private List<int> CopyTheIntList(List<int> list)
        {
            List<int> newList = new List<int>();
            foreach (int item in list)
            {
                newList.Add(item);
            }
            return newList;
        }

        private List<string> CopyTheStringList(List<string> list)
        {
            List<string> newList = new List<string>();
            foreach (string item in list)
            {
                newList.Add(item);
            }
            return newList;
        }
        
        private void ChangeChartProcentOne(List<string> xValues, List<int> yValues)
        {
            Title currentTitle = chrtProcentOne.Titles[0];
            currentTitle.Text = this.seriesNames[cbxOperations.SelectedIndex];

            // Seting the Rating chart
            Series rating = chrtProcentOne.Series[0];  // [0] = [Rating (%)]
            rating.Points.Clear();
            for (int i = 0; i < xValues.Count; i++)
            {
                rating.Points.AddXY(xValues[i], (int)yValues[i]);
            }

            // Seting the Time chart
            Series time = chrtProcentOne.Series[1];
            time.Points.Clear();

            List<float> secondYValues = new List<float>();
            for (int i = 0; i <= numberOfDigits; i++)
            {
                float theValue = (float)(Math.Round(engine.TimeMatrix[i, cbxOperations.SelectedIndex]*100)/100);
                secondYValues.Add(theValue);
            }

            float scale = yValues.Max() / secondYValues.Max() / 2F;

            for (int i = 0; i < xValues.Count; i++)
            {
                time.Points.AddXY(xValues[i], secondYValues[i]*scale);
                time.Points[i].Label = secondYValues[i].ToString();
            }

        }

        private void cbxNumberOfDigits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeChartProcentTwo(this.xChartValuesForSecondChart, this.engine.DoubleListRate[cbxNumberOfDigits.SelectedIndex]);

            List<string> xChartForPie = CopyTheStringList(this.xChartValuesForSecondChart);
            List<int> yChartForPie = CopyTheIntList(this.engine.DoubleListSum[cbxNumberOfDigits.SelectedIndex]);

            lblPieTotalTwo.Text = string.Format("Total = {0}", yChartForPie[0]);

            xChartForPie.RemoveAt(0);
            yChartForPie.RemoveAt(0);
            ChangeSecondPie(xChartForPie, yChartForPie);

            ModifyGraphTwo();
        }

        private void ModifyGraphTwo()
        {
            graphTwo.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            int index = -1;

            foreach (Series item in this.graphTwo.Series)
            {
                item.Points.Clear();
                index++;

                List<DateTime> xValues = engine.DailyRateDigit[index].Dates;
                List<int> yValues = engine.DailyRateDigit[index].Rates;

                for (int i = 0; i < xValues.Count; i++)
                {
                    item.Points.AddXY(xValues[i], yValues[i]);
                }
            }
        }

        private void ChangeSecondPie(List<string> xValues, List<int> yValues)
        {
            foreach (Title item in chrtPieTwo.Titles)
            {
                item.Text = this.titlesForSecondPie[cbxNumberOfDigits.SelectedIndex];
            }
            foreach (Series item in chrtPieTwo.Series)
            {
                item.Points.Clear();
                for (int i = 0; i < 4; i++)
                {
                    item.Points.AddXY(xValues[i], yValues[i]);
                }
            }
        }

        private void ChangeChartProcentTwo(List<string> xValues, List<int> yValues)
        {
            Title currentTitle = chrtProcentTwo.Titles[0];
            currentTitle.Text = this.titlesForSecondChart[cbxNumberOfDigits.SelectedIndex];

            // Seting the Rating chart
            Series rating = chrtProcentTwo.Series[0]; // [0] = [Rating (%)]
            rating.Points.Clear();
            for (int i = 0; i < 5; i++)
            {
                rating.Points.AddXY(xValues[i], yValues[i]);
            }

            // Seting the Time chart
            Series time = chrtProcentTwo.Series[1];
            time.Points.Clear();

            List<float> secondYValues = new List<float>();
            for (int i = 0; i <= 4; i++)
            {
                float theValue = (float)(Math.Round(engine.TimeMatrix[cbxNumberOfDigits.SelectedIndex, i] * 100) / 100);
                secondYValues.Add(theValue);
            }

            float scale = yValues.Max() / secondYValues.Max() / 2F;

            for (int i = 0; i < xValues.Count; i++)
            {
                time.Points.AddXY(xValues[i], secondYValues[i] * scale);
                time.Points[i].Label = secondYValues[i].ToString();
            }
        }
        #endregion Private Methods

        #region Protected Override Methods
        protected override void OnClosed(EventArgs e)
        {
            this.Parent.Show();
            base.OnClosed(e);
        }
        #endregion Protected Override Methods
    }
}
