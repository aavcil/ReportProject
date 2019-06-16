using System;

namespace ReportLibrary.Input.Models
{
    public class StopInput
    {
        public StopReason StopReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public enum StopReason
    {
        Break,
        Setup,
        Trouble,
        ArGe
    }
}
