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
using RecruitmentApplication.Helpers;
using RecruitmentApplication.Controllers;

namespace RecruitmentApplication.UserInterface
{
    public partial class LoginForm : Form
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPermissionService _permissionService;
        private readonly Panel _parentPanel;
        private TranslationContext _translationContext;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public event EventHandler CancelButtonClicked;

        private readonly RecruiterForm _recruiterForm;
        private readonly CandidateForm _candidateForm;

        public LoginForm(
            IAuthenticationService authenticationService,
            IPermissionService permissionService,
            Panel parentPanel,
            RecruiterForm recruiterForm,
            CandidateForm candidateForm)
        {
            _authenticationService = authenticationService;
            _permissionService = permissionService;
            _parentPanel = parentPanel;
            _recruiterForm = recruiterForm;
            _candidateForm = candidateForm;

            InitializeComponent();
            UpdateLanguage();
        }

        public void Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Username and password cannot be empty.");
                    Logger.Warn("Attempted login with empty username or password.");
                    return;
                }

                var user = _authenticationService.Authenticate(username, password);
                if (user != null)
                {
                    if (_permissionService.HasPermission(user, "AccessRecruiterForm"))
                    {
                        _recruiterForm.LoadQuestions(user);
                        ShowFormInPanel(_recruiterForm);
                    }
                    else if (_permissionService.HasPermission(user, "AccessCandidateForm"))
                    {
                        ShowFormInPanel(_candidateForm);
                    }
                    Logger.Info("User {0} logged in successfully.", username);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    Logger.Warn("Invalid login attempt for username: {0}", username);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error during login for username: {0}", username);
                MessageBox.Show("An error occurred during login.");
            }
        }

        private void ShowFormInPanel(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            _parentPanel.Controls.Clear();
            _parentPanel.Controls.Add(form);
            form.Show();
        }

        private void UpdateLanguage()
        {
            _translationContext = TranslationContext.Create(Helpers.Settings.Language);
            LanguageHelper.UpdateLanguage(_translationContext, this.Controls);
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
           // this.Close();
        }

        private void LogInButton2_Click(object sender, EventArgs e)
        {
            string username = UsernameBox2.Text;
            string password = PasswordBox2.Text;
            Login(username, password);
        }
    }
}
