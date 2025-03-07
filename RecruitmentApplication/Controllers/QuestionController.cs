using RecruitmentApplication.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using NLog;

namespace RecruitmentApplication.Controllers
{
    public class QuestionController : IQuestionController
    {
        private readonly IGenericRepository<Question> _questionRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public QuestionController(IGenericRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<Question> GetQuestions()
        {
            try
            {
                var questions = _questionRepository.GetAll();
                Logger.Info("Retrieved {0} questions", questions.Count);
                return questions;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error getting questions");
                throw;
            }
        }

        public void AddQuestion(Question question)
        {
            try
            {
                _questionRepository.Add(question);
                Logger.Info("Question added: {0}", question.Text);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error adding question");
                throw;
            }
        }

        public void EditQuestion(Question question)
        {
            try
            {
                _questionRepository.Update(question);
                Logger.Info("Question updated: {0}", question.Text);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error updating question");
                throw;
            }
        }

        public void DeleteQuestion(Question question)
        {
            try
            {
                _questionRepository.Delete(question);
                Logger.Info("Question deleted: {0}", question.Text);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error deleting question");
                throw;
            }
        }
    }
}
