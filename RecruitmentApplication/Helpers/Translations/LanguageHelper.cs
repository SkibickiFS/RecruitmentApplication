using System.Windows.Forms;

namespace RecruitmentApplication.Helpers
{
    public static class LanguageHelper
    {
        public static void UpdateLanguage(TranslationContext translationContext, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Label label)
                {
                    label.Text = translationContext.GetTranslation(label.Name);
                }
                else if (control is Button button)
                {
                    button.Text = translationContext.GetTranslation(button.Name);
                }
            }
        }
    }
}
