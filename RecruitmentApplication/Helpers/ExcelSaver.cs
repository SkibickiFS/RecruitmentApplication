using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using OfficeOpenXml;

namespace RecruitmentApplication.Helpers
{
    public class ExcelSaver
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void SaveAnswersToExcel(List<Answer> answers, string candidateName)
        {
            try
            {
                string filePath = $"{candidateName}_Answers.xlsx";
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Answers");
                    worksheet.Cells[1, 1].Value = "Question";
                    worksheet.Cells[1, 2].Value = "Answer";

                    for (int i = 0; i < answers.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = answers[i].QuestionText;
                        worksheet.Cells[i + 2, 2].Value = answers[i].AnswerText;
                    }

                    package.Save();
                    Logger.Info("Answers saved to Excel file: {0}", filePath);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error saving answers to Excel file: {0}", candidateName);
                throw;
            }
        }
    }
}
