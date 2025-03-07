using System.Collections.Generic;

namespace RecruitmentApplication.Controllers
{
    public interface IAnswerController
    {
        void SaveAnswers(List<Answer> answers, string filePath);
    }
}
