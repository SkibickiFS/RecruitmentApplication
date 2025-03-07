using System;
using System.Diagnostics;
using System.Windows.Forms;
using RecruitmentApplication.Models;
using RecruitmentApplication.Services;
using RecruitmentApplication.Controllers;
using RecruitmentApplication.Helpers;
using NLog;
using System.Linq;



namespace RecruitmentApplication.UserInterface
{
    public partial class MainForm : Form
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPermissionService _permissionService;
        private readonly IQuestionController _questionController;
        private readonly IAnswerController _answerController;
        private readonly LoginForm _loginForm;
        private TranslationContext _translationContext;
        private User _currentUser;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string LinkedinUrl = "https://www.linkedin.com/in/marcin-skibicki/";

        public MainForm(IAuthenticationService authenticationService, IPermissionService permissionService,
                        IQuestionController questionController, IAnswerController answerController,
                        LoginForm loginForm, User currentUser)
        {
            _authenticationService = authenticationService;
            _permissionService = permissionService;
            _questionController = questionController;
            _answerController = answerController;
            _loginForm = loginForm;
            _currentUser = currentUser;

            InitializeComponent();
            UpdateLanguage();
        }

        #region Displaying Forms

        private void ShowLoginFormInPanel()
        {
            try
            {
                _loginForm.TopLevel = false;
                _loginForm.Dock = DockStyle.Fill;
                panel1.Controls.Add(_loginForm);
                _loginForm.Show();

                _loginForm.CancelButtonClicked += (s, args) =>
                {
                    panel1.Visible = false;
                };

                panel1.Visible = true;

                Logger.Info("Login form displayed in panel.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error displaying login form in panel.");
                MessageBox.Show("An error occurred while displaying the login form in panel.");
            }
        }

        #endregion

        #region Translation

        private void UpdateLanguage()
        {
            _translationContext = TranslationContext.Create(Helpers.Settings.Language);
            _translationContext.SetFlag(FlagButton1);
            LanguageHelper.UpdateLanguage(_translationContext, this.Controls);

        }

        #endregion

        #region Event Handlers

        private void FlagButton1_Click(object sender, EventArgs e)
        {
            if (Helpers.Settings.Language == TranslationContext.Polish)
            {
                Helpers.Settings.Language = TranslationContext.English;
            }
            else
            {
                Helpers.Settings.Language = TranslationContext.Polish;
            }

            UpdateLanguage();
        }

        private void linkedinLink_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(LinkedinUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_translationContext.GetTranslation("ErrorLinkText1")}: {ex.Message}",
                    _translationContext.GetTranslation("ErrorHead"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginButton1_Click(object sender, EventArgs e)
        {
            ShowLoginFormInPanel();
        }

        private void InstButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PdfHelper.OpenPdfFromResources("RecruitmentApplication.Resources.Documents.Instruction.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PdfHelper.OpenPdfFromResources("RecruitmentApplication.Resources.Documents.Documentation.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}