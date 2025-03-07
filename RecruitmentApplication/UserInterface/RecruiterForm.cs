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
    public partial class RecruiterForm : Form
    {
        private readonly IQuestionController _questionController;
        private readonly IPermissionService _permissionService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public RecruiterForm(IQuestionController questionController, IPermissionService permissionService)
        {
            _questionController = questionController;
            _permissionService = permissionService;
            InitializeComponent();
        }

        public void LoadQuestions(User currentUser)
        {
            try
            {

                if (!_permissionService.HasPermission(currentUser, "ViewQuestions"))
                {
                    MessageBox.Show("You do not have permission to view questions.");
                    Logger.Warn("User {0} attempted to view questions without permission.", currentUser.Username);
                    return;
                }

                var questions = _questionController.GetQuestions();
              
                Logger.Info("Loaded {0} questions.", questions.Count);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error loading questions.");
                MessageBox.Show("An error occurred while loading questions.");
            }
        }

    }
}
