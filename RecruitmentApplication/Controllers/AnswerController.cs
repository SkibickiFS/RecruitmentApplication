using System.Collections.Generic;
using RecruitmentApplication.Helpers;

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
