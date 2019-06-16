using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary.Output.Models
{
    public class WorkOrderOutput
    {
        public int work { get; set; }
        public int Break { get; set; }
        public int Setup { get; set; }
        public int Trouble { get; set; }
        public int ArGe { get; set; }
        public int Total { get; set; }
    }
}
