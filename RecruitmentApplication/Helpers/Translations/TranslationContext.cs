using RecruitmentApplication.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruitmentApplication.Helpers
{
    public class TranslationContext
    {
        public const string Polish = "PL";
        public const string English = "EN";

        private ITranslationStrategy _strategy;

        private TranslationContext(ITranslationStrategy strategy)
        {
            _strategy = strategy;
        }

        public static TranslationContext Create(string language)
        {
            switch (language)
            {
                case Polish:
                    return new TranslationContext(new PolishTranslationStrategy());
                case English:
                    return new TranslationContext(new EnglishTranslationStrategy());
                default:
                    return new TranslationContext(new PolishTranslationStrategy());
            }
        }

        public void SetFlag(Button flagButton)
        {
            if (flagButton == null)
            {
                return;
            }
            if (Settings.Language == Polish)
            {
                flagButton.Image = Resources.Flag_UK;
            }
            else
            {
                flagButton.Image = Resources.Flag_PL;
            }
        }

        public string GetTranslation(string key)
        {
            return _strategy.GetString(key);
        }
    }
}
