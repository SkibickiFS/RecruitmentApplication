using RecruitmentApplication.Properties;
using System.Globalization;

namespace RecruitmentApplication.Helpers
{
    public class PolishTranslationStrategy : ITranslationStrategy
    {
        public string GetString(string key)
        {
            return Strings.ResourceManager.GetString(key, new CultureInfo(TranslationContext.Polish));
        }
    }
}
