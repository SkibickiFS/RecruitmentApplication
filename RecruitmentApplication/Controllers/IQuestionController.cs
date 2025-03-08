using RecruitmentApplication.Models;
using System.Collections.Generic;

namespace RecruitmentApplication.Controllers
{
    public interface IQuestionController
    {
        List<Question> GetQuestions();
        void AddQuestion(Question question);
        void EditQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
