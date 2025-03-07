using RecruitmentApplication.Controllers;
using RecruitmentApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using RecruitmentApplication.Models;

namespace RecruitmentApplication.UserInterface
{
    public partial class CandidateForm : Form
    {
        private readonly IQuestionController _questionController;
        private readonly IAnswerController _answerController;
        private readonly IPermissionService _permissionService;
        private User _currentUser;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public CandidateForm(IQuestionController questionController, IAnswerController answerController, IPermissionService permissionService, User currentUser)
        {
            _questionController = questionController;
            _answerController = answerController;
            _permissionService = permissionService;
            _currentUser = currentUser;
            InitializeComponent();
        }

        public void LoadQuestions()
        {
            try
            {
                if (!_permissionService.HasPermission(_currentUser, "ViewQuestions"))
                {
                    MessageBox.Show("You do not have permission to view questions.");
                    Logger.Warn("User {0} attempted to view questions without permission.", _currentUser.Username);
                    return;
                }

                var questions = _questionController.GetQuestions();
                // Wyświetlanie pytań w interfejsie użytkownika
                Logger.Info("Loaded {0} questions.", questions.Count);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error loading questions.");
                MessageBox.Show("An error occurred while loading questions.");
            }
        }

        public void SubmitAnswers(List<Answer> answers)
        {
            try
            {
                if (!_permissionService.HasPermission(_currentUser, "SubmitAnswers"))
                {
                    MessageBox.Show("You do not have permission to submit answers.");
                    Logger.Warn("User {0} attempted to submit answers without permission.", _currentUser.Username);
                    return;
                }

                if (answers == null || answers.Count == 0)
                {
                    MessageBox.Show("No answers to submit.");
                    Logger.Warn("Attempted to submit empty answers.");
                    return;
                }

                _answerController.SaveAnswers(answers, "CandidateAnswers.xlsx");
                MessageBox.Show("Answers saved successfully.");
                Logger.Info("Submitted {0} answers.", answers.Count);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error submitting answers.");
                MessageBox.Show("An error occurred while submitting answers.");
            }
        }
    }
}
