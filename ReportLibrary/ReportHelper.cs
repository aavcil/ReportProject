using ReportLibrary.Input.Models;
using ReportLibrary.Output.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary
{
    public static class ReportHelper
    {
        public static Report CreateReport(List<WorkOrderInput> workOrders, List<StopInput> stops)
        {
            var workOrdersOutput = new List<WorkOrderOutput>();
            foreach (var workOrder in workOrders)
            {
                var workOrderOutput = new WorkOrderOutput();
                foreach (var stop in stops)
                {
                    int time;
                    if (stop.StartDate >= workOrder.StartDate && stop.EndDate <= workOrder.EndDate)
                    {
                         time = (int)(stop.EndDate - stop.StartDate).TotalMinutes;
                    }
                    else if (workOrder.StartDate>stop.StartDate && workOrder.EndDate<stop.EndDate)
                    {
                        time = (int)(workOrder.EndDate - workOrder.StartDate).TotalMinutes;

                    }
                    else if (workOrder.EndDate>stop.StartDate && workOrder.EndDate< stop.EndDate)
                    {
                        time = (int) (workOrder.EndDate - stop.StartDate).TotalMinutes;
                    }
                    else if (stop.StartDate<workOrder.StartDate && stop.EndDate> workOrder.StartDate)

                    {
                        time = (int)(stop.EndDate - workOrder.StartDate).TotalMinutes;
                    }
                    else
                    {
                        time = 0;
                    }
                    switch (stop.StopReason)
                    {
                        case StopReason.Break:
                            workOrderOutput.Break += time;
                            break;
                        case StopReason.Setup:
                            workOrderOutput.Setup += time;
                            break;
                        case StopReason.Trouble:
                            workOrderOutput.Trouble += time;
                            break;
                        case StopReason.ArGe:
                            workOrderOutput.ArGe += time;

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                workOrderOutput.Total = workOrderOutput.ArGe + workOrderOutput.Trouble + workOrderOutput.Break +
                                        workOrderOutput.Setup;
                workOrderOutput.work = workOrder.WorkOrder;
                workOrdersOutput.Add(workOrderOutput);
            }

            return new Report(workOrdersOutput);
        }
    }
}
