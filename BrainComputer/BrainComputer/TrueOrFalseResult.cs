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
    public partial class TrueOrFalseResult : Form
    {
        public TrueOrFalseResult(string result)
        {
            InitializeComponent();
            tbx.Text = result;


            
        }

    }
}
