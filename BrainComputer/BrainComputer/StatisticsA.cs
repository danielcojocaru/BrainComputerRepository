using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainComputer
{
    public partial class Statistics
    {
        private void CompleteTitlesForSecondChart()
        {
            this.titlesForSecondChart = new List<string>();
            this.titlesForSecondChart.Add("Your rating overall");
            this.titlesForSecondChart.Add("Your rating at ecuations with numbers with 1 digit");
            this.titlesForSecondChart.Add("Your rating at ecuations with numbers with 2 digits");
            this.titlesForSecondChart.Add("Your rating at ecuations with numbers with 3 digits");
            this.titlesForSecondChart.Add("Your rating at ecuations with numbers with 4 digits");
        }

        private void CreateTheCheckBoxesEvents()
        {
            chbOverallOne.CheckedChanged += ChechBoxesOne_CheckedChanged;
            chbPlus.CheckedChanged += ChechBoxesOne_CheckedChanged;
            chbMinus.CheckedChanged += ChechBoxesOne_CheckedChanged;
            chbMultiply.CheckedChanged += ChechBoxesOne_CheckedChanged;
            chbDivide.CheckedChanged += ChechBoxesOne_CheckedChanged;

            chbOverallTwo.CheckedChanged += ChechBoxesTwo_CheckedChanged;
            chbOneDigit.CheckedChanged += ChechBoxesTwo_CheckedChanged;
            chbTwoDigits.CheckedChanged += ChechBoxesTwo_CheckedChanged;
            chbThreeDigits.CheckedChanged += ChechBoxesTwo_CheckedChanged;
            chbFourDigits.CheckedChanged += ChechBoxesTwo_CheckedChanged;
        }

        private void CompleteTitlesForSecondPie()
        {
            this.titlesForSecondPie = new List<string>();
            this.titlesForSecondPie.Add("Number of operations done overall");
            this.titlesForSecondPie.Add("Number of operations done using number with 1 digit");
            this.titlesForSecondPie.Add("Number of operations done using number with 2 digits");
            this.titlesForSecondPie.Add("Number of operations done using number with 3 digits");
            this.titlesForSecondPie.Add("Number of operations done using number with 4 digits");
        }

        private void CompleteXChartValuesListForSecondChart()
        {
            this.xChartValuesForSecondChart = new List<string>();

            this.xChartValuesForSecondChart.Add("All");
            this.xChartValuesForSecondChart.Add("Plus");
            this.xChartValuesForSecondChart.Add("Minus");
            this.xChartValuesForSecondChart.Add("Multiply");
            this.xChartValuesForSecondChart.Add("Divide");
        }

        private void CompleteTitlesForFirstPie()
        {
            this.titlesForFirstPie = new List<string>();
            this.titlesForFirstPie.Add("Number of operations done overall");
            this.titlesForFirstPie.Add("Number of operations done with the operator \"Plus\"");
            this.titlesForFirstPie.Add("Number of operations done with the operator \"Minus\"");
            this.titlesForFirstPie.Add("Number of operations done with the operator \"Multiply\"");
            this.titlesForFirstPie.Add("Number of operations done with the operator \"Divide\"");
        }

        private void CompleteXChartValuesListForFirstChart()
        {
            this.xChartValuesForFirstChart = new List<string>();
            string s = "";
            xChartValuesForFirstChart.Add("Overall");
            for (int i = 1; i <= numberOfDigits; i++)
            {
                xChartValuesForFirstChart.Add(string.Format("{0} digit{1}", i.ToString(), s));
                s = "s";
            }

        }

        private void CompleteSeriesNamesList()
        {
            this.seriesNames = new List<string>();
            this.seriesNames.Add("Your rating overall");
            this.seriesNames.Add("Your rating with the \"Plus\" operator");
            this.seriesNames.Add("Your rating with the \"Minus\" operator");
            this.seriesNames.Add("Your rating with the \"Multiply\" operator");
            this.seriesNames.Add("Your rating with the \"Divide\" operator");
        }

        private void CompleteComboboxes()
        {
            cbxOperations.Items.Add("All Operations");
            cbxOperations.Items.Add("Plus Operations");
            cbxOperations.Items.Add("Minus Operations");
            cbxOperations.Items.Add("Multiply Operations");
            cbxOperations.Items.Add("Divide Operations");

            string s = "";
            cbxNumberOfDigits.Items.Add("Overall");
            for (int i = 1; i <= numberOfDigits; i++)
            {
                cbxNumberOfDigits.Items.Add(string.Format("{0} digit{1}", i.ToString(), s));
                s = "s";
            }

        }
    }
}
