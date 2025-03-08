using System.Collections.Generic;
using RecruitmentApplication.Helpers;
using RecruitmentApplication.Models;

namespace RecruitmentApplication.Controllers
{
    public class AnswerController : IAnswerController
    {
        private readonly ExcelSaver _excelSaver;

        public AnswerController()
        {
            _excelSaver = new ExcelSaver();
        }

        public void SaveAnswers(List<Answer> answers, string filePath)
        {
            _excelSaver.SaveAnswersToExcel(answers, filePath);
        }
    }
}
