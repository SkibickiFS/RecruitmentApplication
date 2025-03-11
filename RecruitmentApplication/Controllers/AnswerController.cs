using System.Collections.Generic;
using RecruitmentApplication.Helpers;
using RecruitmentApplication.Models;

namespace RecruitmentApplication.Controllers
{
    public class AnswerController : IAnswerController
    {
        private readonly ExcelSaver _excelSaver;

        public AnswerController(ExcelSaver excelSaver)
        {
            _excelSaver = excelSaver;
        }

        public void SaveAnswers(List<Answer> answers, string filePath)
        {
            _excelSaver.SaveAnswersToExcel(answers, filePath);
        }
    }
}
