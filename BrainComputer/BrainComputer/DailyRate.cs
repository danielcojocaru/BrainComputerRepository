using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainComputer
{
    public class DailyRate
    {
        public List<DateTime> Dates { get; set; }
        public List<int> Rates { get; set; }
        public List<int> DaysDifference { get; set; }
    }
}
