using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary.Output.Models
{
    public class Report
    {
        public Report(List<WorkOrderOutput> workOrders)
        {
            WorkOrders = workOrders;
            TotalBreak = workOrders.Sum(x => x.Break);
            TotalArGe = workOrders.Sum(x => x.ArGe);
            TotalTrouble = workOrders.Sum(x => x.Trouble);
            TotalSetup = workOrders.Sum(x => x.Setup);
        }

        public List<WorkOrderOutput> WorkOrders { get; }

        public int TotalBreak { get; }
        public int TotalSetup { get; }
        public int TotalTrouble { get; set; }
        public int TotalArGe { get; set; }
    }
}
