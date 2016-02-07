using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainComputer
{
    public enum StatisticsType
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        All
    }

    class EngineStatistics
    {
        #region Fields

        private int userId;
        private const int numberOfDigits = 4;

        #endregion Fields

        #region Properties
        // PlusSum[1] coresponds to the operations with numbers > 10 - similar to the next ones
        // PlusSum[0] coresponds to all the operations
        public List<int> PlusSum { get; set; }
        public List<int> PlusRateCorrect { get; set; }
        public List<int> MinusSum { get; set; }
        public List<int> MinusRateCorrect { get; set; }
        public List<int> MultiplySum { get; set; }
        public List<int> MultiplyRateCorrect { get; set; }
        public List<int> DivideSum { get; set; }
        public List<int> DivideRateCorrect { get; set; }
        public List<int> AllOperationsSum { get; set; }
        public List<int> AllOperationsRateCorrect { get; set; }

        public List<List<int>> SumLists { get; set; }
        public List<List<int>> CorrectRateLists { get; set; }

        public List<List<int>> DoubleListSum { get; set; }
        public List<List<int>> DoubleListRate { get; set; }

        public List<DailyRate> DailyRateOperator { get; set; }
        public List<DailyRate> DailyRateDigit { get; set; }

        public float[,] TimeMatrix { get; set; }   // x.Axis = number of digits => 0, 1, 2, 3, 4 (0 is the TOTAL, 1 is for 1 digit)
                                                   // y.Axis = operator index => 0, 1, 2, 3, 4 (0 is the TOTAL, 1 is for PLUS)
        #endregion Properties

        #region Constructors
        public EngineStatistics(int personId)
        {
            this.userId = personId;
            InitializeLists();

            using (BrainGameDBEntities3 context = new BrainGameDBEntities3())
            {
                CompleteTheFirstTenLists(context);
                CompleteTheDoubleLists();
                CreateTheDailyRateLists(context);
                CompleteTheTimeMatrix(context);
            }
        }
        #endregion Constructors

        #region PrivateMethods
        private void CompleteTheTimeMatrix(BrainGameDBEntities3 context)
        {
            this.TimeMatrix = new float[numberOfDigits + 1, 5];  // 5 = 4 operators + the TOTAL
            int[,] numberOfEcuations = new int[numberOfDigits + 1, 5];

            var selected =
                from results in context.Results
                where results.Succeeded == true
                where results.UserId == this.userId
                select new
                {
                    FirstNumber = results.FirstNumber,
                    SecondNumber = results.SecondNumber,
                    Operation = results.Operation,
                    Time = results.Time
                };

            foreach (var item in selected)
            {
                int maxNumber = Math.Max((int)item.FirstNumber, (int)item.SecondNumber);
                int digits = maxNumber.ToString().Length;
                int operatorId = item.Operation;

                this.TimeMatrix[digits, operatorId] += (float)item.Time;
                numberOfEcuations[digits, operatorId]++;
            }

            for (int i = 1; i <= numberOfDigits; i++)  // digits
            {
                float currentTimeSum = 0;
                int currentNumberOfItemsSum = 0;

                for (int j = 1; j <= 4; j++)   // operators
                {
                    currentTimeSum += this.TimeMatrix[i, j];
                    currentNumberOfItemsSum += numberOfEcuations[i, j];
                }

                this.TimeMatrix[i, 0] = currentTimeSum;
                numberOfEcuations[i, 0] = currentNumberOfItemsSum;
            }


            for (int i = 0; i <= 4; i++)  // operators
            {
                float currentTimeSum = 0;
                int currentNumberOfItemsSum = 0;

                for (int j = 1; j <= numberOfDigits; j++)  // digits
                {
                    currentTimeSum += this.TimeMatrix[j, i];
                    currentNumberOfItemsSum += numberOfEcuations[j, i];
                }

                this.TimeMatrix[0, i] = currentTimeSum;
                numberOfEcuations[0, i] = currentNumberOfItemsSum;
            }

            for (int i = 0; i <= numberOfDigits; i++)  // digits
            {
                for (int j = 0; j <= 4; j++)   // operators
                {
                    if (numberOfEcuations[i,j] != 0)
                    {
                        this.TimeMatrix[i, j] = this.TimeMatrix[i, j] / numberOfEcuations[i, j];
                    }
                }

            }
        }

        private void CreateTheDailyRateLists(BrainGameDBEntities3 context)
        {
            AsignTheDailyRatesAtIndexZero(context);
            CreateTheDatesAndTheRatesAtOperator(context);
            CreateTheDatesAndTheRatesAtDigit(context);
            CompleteTheDayDifferenceBetweenDates();
        }

        private void CompleteTheDayDifferenceBetweenDates()
        {
            foreach (DailyRate currentDailyRate in this.DailyRateOperator)
            {
                List<int> days = new List<int>();

                bool zeroAdded = false;
                for (int i = 0; i < currentDailyRate.Dates.Count; i++)
                {
                    if (!zeroAdded)
                    {
                        days.Add(0);
                        zeroAdded = true;
                    }
                    else
                    {
                        days.Add((int)(currentDailyRate.Dates[i] - currentDailyRate.Dates[i - 1]).TotalDays);
                    }
                }
                currentDailyRate.DaysDifference = days;
            }

            foreach (DailyRate currentDailyRate in this.DailyRateDigit)
            {
                List<int> days = new List<int>();

                bool zeroAdded = false;
                for (int i = 0; i < currentDailyRate.Dates.Count; i++)
                {
                    if (!zeroAdded)
                    {
                        days.Add(0);
                        zeroAdded = true;
                    }
                    else
                    {
                        days.Add((int)(currentDailyRate.Dates[i] - currentDailyRate.Dates[i - 1]).TotalDays);
                    }
                }
                currentDailyRate.DaysDifference = days;
            }
        }

        private void AsignTheDailyRatesAtIndexZero(BrainGameDBEntities3 context)
        {
            this.DailyRateDigit = new List<DailyRate>();
            this.DailyRateOperator = new List<DailyRate>();

            var select =
                from results in context.Results
                where results.UserId == this.userId
                select results.Date;

            List<DateTime> currentDateTimeList = select.ToList();
            currentDateTimeList = currentDateTimeList.Distinct().ToList();
            currentDateTimeList = currentDateTimeList.OrderBy(x => x.Date).ToList();

            List<int> currentRateList = new List<int>();
            foreach (DateTime currentDay in currentDateTimeList)
            {
                var selectTwo =
                    from results in context.Results
                    where results.Date == currentDay
                    where results.UserId == this.userId
                    select results.Succeeded;

                int currentRate = GetTheRate(selectTwo.ToList());
                currentRateList.Add(currentRate);
            }
            this.DailyRateDigit.Add(new DailyRate() { Dates = currentDateTimeList, Rates = currentRateList });
            this.DailyRateOperator.Add(new DailyRate() { Dates = currentDateTimeList, Rates = currentRateList });
        }

        private void CreateTheDatesAndTheRatesAtDigit(BrainGameDBEntities3 context)
        {
            for (int i = 1; i <= numberOfDigits; i++) // 4 signs >> + , - , x , /
            {
                var selectDirect =
                    from results in context.Results
                    where results.UserId == this.userId
                    select new
                    {
                        FirstNumber = results.FirstNumber,
                        SecondNumber = results.SecondNumber,
                        Date = results.Date
                    };

                var selected =
                    from results in selectDirect.AsEnumerable()
                    where NumberOfDigitsEqualsWith(Math.Max((int)results.FirstNumber, (int)results.SecondNumber), i)
                    select results.Date;

                List<DateTime> currentDateTimeList = selected.ToList();
                currentDateTimeList = currentDateTimeList.Distinct().ToList();
                currentDateTimeList = currentDateTimeList.OrderBy(x => x.Date).ToList();

                List<int> currentRateList = new List<int>();
                foreach (DateTime currentDay in currentDateTimeList)
                {
                    var selectedTwoDirect =
                        from results in context.Results
                        where results.Date == currentDay
                        where results.UserId == this.userId
                        select new
                        {
                            FirstNumber = results.FirstNumber,
                            SecondNumber = results.SecondNumber,
                            Succeeded = results.Succeeded
                        };
                        

                    var selectedTwo =
                        from results in selectedTwoDirect.AsEnumerable()
                        where NumberOfDigitsEqualsWith(Math.Max((int)results.FirstNumber, (int)results.SecondNumber), i)
                        select results.Succeeded;

                    List<bool> currentBoolList = new List<bool>();
                    foreach (bool currentBool in selectedTwo)
                    {
                        currentBoolList.Add(currentBool);
                    }
                    int currentRate = GetTheRate(currentBoolList);
                    currentRateList.Add(currentRate);
                }
                DailyRate currentDailyRateDigit = new DailyRate();
                currentDailyRateDigit.Dates = currentDateTimeList;
                currentDailyRateDigit.Rates = currentRateList;

                this.DailyRateDigit.Add(currentDailyRateDigit);
            }
        }

        private void CreateTheDatesAndTheRatesAtOperator(BrainGameDBEntities3 context)
        {
            for (int i = 1; i <= 4; i++) // 4 signs >> + , - , x , /
            {
                var selected =
                    from results in context.Results
                    where results.Operation == i
                    where results.UserId == this.userId
                    select results.Date;


                List<DateTime> currentDateTimeList = selected.ToList();
                currentDateTimeList = currentDateTimeList.Distinct().ToList();
                currentDateTimeList = currentDateTimeList.OrderBy(x => x.Date).ToList();


                List<int> currentRateList = new List<int>();
                foreach (DateTime currentDay in currentDateTimeList)
                {
                    var selectedTwo =
                        from results in context.Results
                        where results.Operation == i
                        where results.Date == currentDay
                        where results.UserId == this.userId
                        select results.Succeeded;

                    List<bool> currentBoolList = new List<bool>();
                    foreach (bool currentBool in selectedTwo)
                    {
                        currentBoolList.Add(currentBool);
                    }
                    int currentRate = GetTheRate(currentBoolList);
                    currentRateList.Add(currentRate);
                }
                DailyRate currentDailyRateOperator = new DailyRate();
                currentDailyRateOperator.Dates = currentDateTimeList;
                currentDailyRateOperator.Rates = currentRateList;

                this.DailyRateOperator.Add(currentDailyRateOperator);
            }
        }

        private bool NumberOfDigitsEqualsWith(int number, int digits)
        {
            if (number.ToString().Length == digits)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetTheRate(List<bool> currentBoolList)
        {
            int correct = 0;
            int incorrect = 0;
            foreach (bool item in currentBoolList)
            {
                if (item)
                {
                    correct++;
                }
                else
                {
                    incorrect++;
                }
            }
            return Procent(correct, incorrect);
        }

        private void EliminateDuplicatesAndSortDateTimeList(List<DateTime> list)
        {
            list = list.Distinct().ToList();
            list = list.OrderBy(x => x.Date).ToList();
        }

        private void CompleteTheDoubleLists()
        {
            this.DoubleListSum = new List<List<int>>();
            this.DoubleListRate = new List<List<int>>();

            for (int i = 0; i < numberOfDigits + 1; i++)
            {
                this.DoubleListSum.Add(new List<int>() { this.AllOperationsSum[i], this.PlusSum[i], this.MinusSum[i],
                    this.MultiplySum[i], this.DivideSum[i] });

                this.DoubleListRate.Add(new List<int>() {this.AllOperationsRateCorrect[i], this.PlusRateCorrect[i],
                    this.MinusRateCorrect[i], this.MultiplyRateCorrect[i], this.DivideRateCorrect[i] });
            }
            
        }
        
        private void CompleteTheFirstTenLists(BrainGameDBEntities3 context)
        {
            // selected contains all the results of the user with the diven Id
            var selected =
                from results in context.Results
                where results.UserId == this.userId
                select new
                {
                    FirstNumber = results.FirstNumber,
                    SecondNumber = results.SecondNumber,
                    Operation = results.Operation,
                    Succeeded = results.Succeeded,
                    Time = results.Time
                };

            // creating these vectors that will help completing the Lists
            int[] plusCorect = new int[numberOfDigits + 1];
            int[] plusFalse = new int[numberOfDigits + 1];
            int[] minusCorect = new int[numberOfDigits + 1];
            int[] minusFalse = new int[numberOfDigits + 1];
            int[] multiplyCorect = new int[numberOfDigits + 1];
            int[] multiplyFalse = new int[numberOfDigits + 1];
            int[] divideCorect = new int[numberOfDigits + 1];
            int[] divideFalse = new int[numberOfDigits + 1];

            // completing the vectors
            foreach (var item in selected)
            {
                int max = Math.Max((int)item.FirstNumber, (int)item.SecondNumber);
                int digits = max.ToString().Length;

                var operation = item.Operation;

                switch ((int)item.Operation)
                {
                    case 1:
                        if (item.Succeeded)
                            plusCorect[digits]++;
                        else
                            plusFalse[digits]++;
                        break;
                    case 2:
                        if (item.Succeeded)
                            minusCorect[digits]++;
                        else
                            minusFalse[digits]++;
                        break;
                    case 3:
                        if (item.Succeeded)
                            multiplyCorect[digits]++;
                        else
                            multiplyFalse[digits]++;
                        break;
                    case 4:
                        if (item.Succeeded)
                            divideCorect[digits]++;
                        else
                            divideFalse[digits]++;
                        break;
                }
            }
            int plusAllCorect = 0;
            int minusAllCorect = 0;
            int multiplyAllCorect = 0;
            int divideAllCorect = 0;

            // completing the Lists
            for (int i = 1; i <= numberOfDigits; i++)
            {
                this.PlusSum.Add(plusCorect[i] + plusFalse[i]);
                this.MinusSum.Add(minusCorect[i] + minusFalse[i]);
                this.MultiplySum.Add(multiplyCorect[i] + multiplyFalse[i]);
                this.DivideSum.Add(divideCorect[i] + divideFalse[i]);
                this.AllOperationsSum.Add(this.PlusSum[i] + this.MinusSum[i] + this.MultiplySum[i] + this.DivideSum[i]);

                if (plusCorect[i] + plusFalse[i] != 0)
                {
                    this.PlusRateCorrect.Add(Procent(plusCorect[i], plusFalse[i]));
                }
                else
                {
                    this.PlusRateCorrect.Add(0);
                }

                if (minusCorect[i] + minusFalse[i] != 0)
                {
                    this.MinusRateCorrect.Add(Procent(minusCorect[i], minusFalse[i]));
                }
                else
                {
                    this.MinusRateCorrect.Add(0);
                }

                if (multiplyCorect[i] + multiplyFalse[i] != 0)
                {
                    this.MultiplyRateCorrect.Add(Procent(multiplyCorect[i], multiplyFalse[i]));
                }
                else
                {
                    this.MultiplyRateCorrect.Add(0);
                }

                if (divideCorect[i] + divideFalse[i] != 0)
                {
                    this.DivideRateCorrect.Add(Procent(divideCorect[i], divideFalse[i]));
                }
                else
                {
                    this.DivideRateCorrect.Add(0);
                }

                if (this.AllOperationsSum[i] != 0)
                {
                    this.AllOperationsRateCorrect.Add((int)Math.Round(100 * (double)(plusCorect[i] + minusCorect[i] + multiplyCorect[i] + divideCorect[i]) / (double)this.AllOperationsSum[i]));
                }
                else
                {
                    this.AllOperationsRateCorrect.Add(0);
                }

                this.PlusSum[0] += this.PlusSum[i];
                this.MinusSum[0] += this.MinusSum[i];
                this.MultiplySum[0] += this.MultiplySum[i];
                this.DivideSum[0] += this.DivideSum[i];
                this.AllOperationsSum[0] += this.AllOperationsSum[i];


                plusAllCorect += plusCorect[i];
                minusAllCorect += minusCorect[i];
                multiplyAllCorect += multiplyCorect[i];
                divideAllCorect += divideCorect[i];
            }

            if (this.PlusSum[0] != 0)
            {
                this.PlusRateCorrect[0] = Procent(plusAllCorect, this.PlusSum[0] - plusAllCorect);
            }

            if (this.MinusSum[0] != 0)
            {
                this.MinusRateCorrect[0] = Procent(minusAllCorect, this.MinusSum[0] - minusAllCorect);
            }

            if (this.MultiplySum[0] != 0)
            {
                this.MultiplyRateCorrect[0] = Procent(multiplyAllCorect, this.MultiplySum[0] - multiplyAllCorect);
            }

            if (this.DivideSum[0] != 0)
            {
                this.DivideRateCorrect[0] = Procent(divideAllCorect, this.DivideSum[0] - divideAllCorect);
            }

            if (this.AllOperationsSum[0] != 0)
            {
                this.AllOperationsRateCorrect[0] = (int)Math.Round(100 * (double)(plusAllCorect + minusAllCorect + multiplyAllCorect + divideAllCorect) / (double)this.AllOperationsSum[0]);
            }



        }

        private int Procent(int correct, int incorrect)
        {
            int procent = (int)Math.Round(100 * (double)correct / (double)(correct + incorrect));
            return procent;
        }

        private void InitializeLists()
        {
            this.PlusSum = new List<int>();
            this.PlusRateCorrect = new List<int>();
            this.MinusSum = new List<int>();
            this.MinusRateCorrect = new List<int>();
            this.MultiplySum = new List<int>();
            this.MultiplyRateCorrect = new List<int>();
            this.DivideSum = new List<int>();
            this.DivideRateCorrect = new List<int>();
            this.AllOperationsSum = new List<int>();
            this.AllOperationsRateCorrect = new List<int>();

            this.PlusSum.Add(0);
            this.PlusRateCorrect.Add(0);
            this.MinusSum.Add(0);
            this.MinusRateCorrect.Add(0);
            this.MultiplySum.Add(0);
            this.MultiplyRateCorrect.Add(0);
            this.DivideSum.Add(0);
            this.DivideRateCorrect.Add(0);
            this.AllOperationsSum.Add(0);
            this.AllOperationsRateCorrect.Add(0);
        }
        #endregion PrivateMethods
    }
}
