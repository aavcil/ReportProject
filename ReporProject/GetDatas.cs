    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using ReportLibrary;
using ReportLibrary.Input.Models;
using ReportLibrary.Output.Models;

namespace ReportProject
{
   public class GetData
    {
        public List<WorkOrderInput> works()
        {
            List<WorkOrderInput> workOrders = new List<WorkOrderInput>();

            string filePath = @".\Data\workList.xlsx";

            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;

            int counter = 0;


            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
            {

                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {

                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }


            while (excelReader.Read())
            {
                counter++;
                if (counter > 1)
                {
                    int work = (int)excelReader.GetDouble(0);
                    string startDate = excelReader.GetString(1);
                    string endDate = excelReader.GetString(2);
                    var addWork = new WorkOrderInput()
                    {
                        EndDate = DateTime.Parse(endDate),
                        StartDate = DateTime.Parse(startDate),
                        WorkOrder = work
                    };
                    workOrders.Add(addWork);
                }
            }

            excelReader.Close();
            return workOrders;

        }

        public List<StopInput> stops()
        {
            List<StopInput> stops = new List<StopInput>();

            string filePath = @".\Data\stopList.xlsx";

            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            int counter = 0;


            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
            {

                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {

                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }


            while (excelReader.Read())
            {
                counter++;
                if (counter > 1)
                {
                    StopReason reason;
                    switch (excelReader.GetString(0))
                    {
                        case "Mola":
                            reason = StopReason.Break;
                            break;
                        case "Arıza":
                            reason = StopReason.Trouble;
                            break;
                        case "Setup":
                            reason = StopReason.Setup;
                            break;
                        case "Arge":
                            reason = StopReason.ArGe;
                            break;
                        default:
                            reason = StopReason.Break;
                            break;

                    }
                    string startDate = excelReader.GetString(1);
                    string endDate = excelReader.GetString(2);
                    var stopAdd = new StopInput()
                    {
                        StopReason = reason,
                        StartDate = DateTime.Parse(startDate),
                        EndDate = DateTime.Parse(endDate)
                    };
                    stops.Add(stopAdd);

                }
            }

            excelReader.Close();
            return stops;
        }


        public Report report()
        {
            return ReportHelper.CreateReport(works(), stops());
        }

    }
}
