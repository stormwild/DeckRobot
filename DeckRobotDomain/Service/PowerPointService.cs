using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DeckRobotDomain.Model;
using Spire.Presentation;

namespace DeckRobotDomain.Service
{
    public class PowerPointService : IPowerPointService
    {
        public PowerPointService()
        {
        }

        public IEnumerable<object> GetFonts()
        {
            throw new NotImplementedException();
        }

        public void UpdateFont(FileStream fileStream, string filePath, string fontFamily)
        {
            Presentation presentation = new Presentation();
            presentation.LoadFromStream(fileStream, FileFormat.Pptx2013);

            var slides = presentation.Slides;
            foreach (ISlide slide in slides)
            {
                ShapeCollection shapes = slide.Shapes;
                for (int i = 0; i < shapes.Count; i++)
                {
                    if(shapes[i] is IAutoShape) {
                        var shape = shapes[i] as IAutoShape;
                        if (shape.IsTextBox || shape.TextFrame != null)
                        {
                            TextRange textRange = shape.TextFrame.TextRange;
                            textRange.LatinFont = new TextFont(fontFamily);
                        }
                    }
                }
            }

            presentation.SaveToFile(fileStream, FileFormat.Pptx2013);
        }


        // public IWorkbook GenerateReport(Report report, ProcessQCReportParam param, DateTime currentDateTime, IEnumerable<ProcessQCReport> data)
        // {
        //     IWorkbook workbook;
        //     workbook = new XSSFWorkbook();

        //     ISheet excelSheet = workbook.CreateSheet(report.Name);

        //     int rowIndex = 0;
        //     IRow row = excelSheet.CreateRow(rowIndex += 2);

        //     // Report Type Name
        //     row.CreateCell(0).SetCellValue(report.Name);
        //     row.CreateCell(1).SetCellValue(report.Id);

        //     row = excelSheet.CreateRow(rowIndex += 2);
        //     row.CreateCell(11).SetCellValue("REPORT: MI011");

        //     // Report Meta
        //     row = excelSheet.CreateRow(rowIndex += 1);
        //     row.CreateCell(0).SetCellValue("Transaction Date From:");
        //     row.CreateCell(1).SetCellValue("" + $"{param.FromDate:yyyy/MM/dd HH:mm:ss}");

        //     row = excelSheet.CreateRow(rowIndex += 1);
        //     row.CreateCell(0).SetCellValue("Transaction Date To:");
        //     row.CreateCell(1).SetCellValue("" + $"{param.ToDate:yyyy/MM/dd HH:mm:ss}");

        //     row = excelSheet.CreateRow(rowIndex += 1);
        //     row.CreateCell(0).SetCellValue("Report Generation Date:");
        //     row.CreateCell(1).SetCellValue("" + $"{currentDateTime:yyyy/MM/dd HH:mm:ss}");

        //     // Report Data Header 
        //     row = excelSheet.CreateRow(rowIndex += 2);
        //     row.CreateCell(0).SetCellValue("Service Team");
        //     row.CreateCell(1).SetCellValue("ERID");
        //     row.CreateCell(2).SetCellValue("Form ID");
        //     row.CreateCell(3).SetCellValue("Case No.");
        //     row.CreateCell(4).SetCellValue("User ID");
        //     row.CreateCell(5).SetCellValue("Queue");
        //     row.CreateCell(6).SetCellValue("Transaction Date");

        //     // Freezes the rows from the top until the column headers
        //     // excelSheet.CreateFreezePane(0, rowIndex + 1);

        //     // Report Data
        //     rowIndex++;
        //     foreach (var d in data)
        //     {
        //         row = excelSheet.CreateRow(rowIndex);

        //         row.CreateCell(0).SetCellValue(d.ServiceTeam);
        //         row.CreateCell(1).SetCellValue(d.ErId);
        //         row.CreateCell(2).SetCellValue(d.FormId);
        //         row.CreateCell(3).SetCellValue(d.CaseId);
        //         row.CreateCell(4).SetCellValue(d.UserId);
        //         row.CreateCell(5).SetCellValue(d.Queue);
        //         row.CreateCell(6).SetCellValue("" + $"{d.TransactionDate:yyyy/MM/dd HH:mm:ss}");

        //         rowIndex++;
        //     }

        //     // Close
        //     row = excelSheet.CreateRow(rowIndex += 1);
        //     row.CreateCell(0).SetCellValue("RESTRICTED");

        //     // AutoSize Columns
        //     excelSheet.AutoSizeColumn(0);
        //     excelSheet.AutoSizeColumn(1);
        //     excelSheet.AutoSizeColumn(2);
        //     excelSheet.AutoSizeColumn(3);
        //     excelSheet.AutoSizeColumn(4);
        //     excelSheet.AutoSizeColumn(5);
        //     excelSheet.AutoSizeColumn(6);

        //     return workbook;
        // }


        // public ReportDownload Download(ProcessQCReportParam param)
        // {
        //     var startDate = DateTime.Now.Date;
        //     var currentDateTime = DateTime.Now;
        //     var report = new Report { Id = "MI011", Name = "Process QC Report" };

        //     var data = GetProcessQCReport(param);

        //     var workbook = GenerateReport(report, param, currentDateTime, data);

        //     var fileName = Path.GetTempFileName(); // The system tmp path, max of 65k tmp files

        //     using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        //     {
        //         workbook.Write(fs);
        //     }

        //     var ms = new MemoryStream();

        //     // Deletes the temp file after stream is closed
        //     using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 4096, options: FileOptions.DeleteOnClose))
        //     {
        //         fs.CopyTo(ms);
        //     }

        //     ms.Position = 0;

        //     //var fn = report.Id + "." + report.GeneratedDate.ToString("yyyy-MM-dd.HH-mm-ss") + ".xlsx";
        //     var fn = $"{report.Id}.{currentDateTime:yyyy-MM-dd.HH-mm-ss}.xlsx";
        //     return new ReportDownload
        //     {
        //         ReportStream = ms,
        //         Filename = fn
        //     };
        // }


        // public async Task<PowerPointFileUploadResponse> UploadPowerPointFile(IFormFile file)
        // {
        //     var filePath = Path.GetTempFileName();

        //     using (var stream = new FileStream(filePath, FileMode.Create))
        //     {
        //         await file.CopyToAsync(stream);
        //     }

        //     return new PowerPointFileUploadResponse { Count = 1, FileSize = file.Length, FilePath = filePath };
        // }
    }
}

