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

namespace BrainComputer
{
    public partial class FormGame : Form
    {
        #region Private Methods

        private void SetTheTwoNumbers()
        {
            Random ran = new Random();

            int maximumNumber = 9;

            for (int i = 0; i < this.numberOfNumbersFirst - 1; i++)
            {
                maximumNumber = maximumNumber * 10 + 9;
            }

            this.theFirstNumber = ran.Next(0, maximumNumber);
            tbxOne.Text = this.theFirstNumber.ToString();

            // for divide, it gives two divisible numbers at "else"
            if (this.theSign != "/")
            {
                maximumNumber = 9;

                for (int i = 0; i < this.numberOfNumbersSecond - 1; i++)
                {
                    maximumNumber = maximumNumber * 10 + 9;
                }

                this.theSecondNumber = ran.Next(0, maximumNumber);
                tbxTwo.Text = this.theSecondNumber.ToString();
            }
            else
            {
                this.theSecondNumber = GetDivisibleNumberOf(this.theFirstNumber);
                tbxTwo.Text = this.theSecondNumber.ToString();
            }
        }

        private void CompleteSignsList()
        {
            signsList = new List<int>();
            for (int i = 0; i < numberOfSigns.Length; i++)
            {
                if (numberOfSigns[i] != 0)
                {
                    signsList.Add(i);
                }
            }
        }

        private void SetTheSign()
        {
            Random ran = new Random();
            int index = ran.Next(0, signsList.Count);
            int signIndex = signsList[index];
            theSign = signs[signIndex];
            tbxSign.Text = theSign;

            //int index = 1;
            //int signIndex = signsList[1];
            //theSign = signs[1];
            //tbxSign.Text = theSign;
        }

        private int GetDivisibleNumberOf(int number)
        {
            List<int> myList = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    myList.Add(i);
                }
            }

            Random ran = new Random();
            int index = ran.Next(1, myList.Count - 1);

            return myList[index];
        }

        private void tbxResult_TextChanged(object sender, EventArgs e)
        {
            while (true)
            {
                // It checks if he wrote something or not
                bool heHasNotWrittenAnythingYet = tbxResult.Text == "" || tbxResult.Text == "-";
                if (heHasNotWrittenAnythingYet)
                {
                    break;
                }

                // It checks if he wrote a number or a letter
                this.theGivenResult = 0;
                bool itIsANumber = double.TryParse(tbxResult.Text, out theGivenResult);

                if (!itIsANumber)
                {
                    MessageBox.Show("That is not a number honey!");
                    RemoveTheWrittenLetter();
                    break;
                }

                // It checks if the answear is correct
                if (this.theResult == this.theGivenResult)
                {
                    TheGivenResultIsCorect();
                    break;
                }

                if (!TheFirstWrittenDigitsAreCorrect())
                {
                    TheGivenResultIsFalse();
                    break;
                }
                break;
            }
        }

        private void RemoveTheWrittenLetter()
        {
            tbxResult.Text = tbxResult.Text.Remove(tbxResult.Text.Length - 1);
            tbxResult.SelectionStart = tbxResult.Text.Length; // sets the cursor at the end of the text
        }

        private bool TheFirstWrittenDigitsAreCorrect()
        {
            this.givenResultList = new List<int>();
            this.givenResultList = NumberAsList(this.theGivenResult);

            int i = 0;
            foreach (int item in givenResultList)
            {
                if (theResultList.Count <= i)
                {
                    return false;
                }
                else if (item != theResultList[i]) // Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private void MakeGoodSound()
        {
            if (chbSounds.Checked)
            {
                int a = 900;
                int b = 150; // 150

                Console.Beep(a, b);
                Console.Beep(a, b);
                Console.Beep(a, b);
            }
            else
            {
                Thread.Sleep(900); // 900
            }

        }

        private void MakeBadSound()
        {
            if (chbSounds.Checked)
            {
                Console.Beep(550, 900); // 900
            }
            else
            {
                Thread.Sleep(900); // 900
            }

        }

        private void CalculateTheResult()
        {
            switch (this.theSign)
            {
                case "+":
                    this.theResult = this.theFirstNumber + this.theSecondNumber;
                    this.CurrentSign = 1;
                    break;
                case "-":
                    this.theResult = this.theFirstNumber - this.theSecondNumber;
                    this.CurrentSign = 2;
                    break;
                case "x":
                    this.theResult = this.theFirstNumber * this.theSecondNumber;
                    this.CurrentSign = 3;
                    break;
                default:
                    this.theResult = this.theFirstNumber / this.theSecondNumber;
                    this.CurrentSign = 4;
                    break;
            }


            this.theResultList = NumberAsList(this.theResult);

            if (theResult < 0)
            {
                tbxResult.Text = "-";
                tbxResult.SelectionStart = tbxResult.Text.Length;
            }
        }

        private List<int> NumberAsList(double number)
        {
            double reverseResult = 0;
            List<int> theReturnedList = new List<int>();

            if (number == 0)
            {
                theReturnedList.Add(0);
            }
            else
            {
                while (number != 0)
                {
                    reverseResult = reverseResult * 10 + number % 10;
                    number = (long)number / 10;
                }

                while (reverseResult != 0)
                {
                    theReturnedList.Add((int)(reverseResult % 10));
                    reverseResult = (long)reverseResult / 10;
                }
            }
            return theReturnedList;
        }

        #endregion Private Methods
    }
}
