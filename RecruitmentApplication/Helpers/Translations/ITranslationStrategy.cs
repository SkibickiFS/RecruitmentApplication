using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentApplication.Helpers
{
    public interface ITranslationStrategy
    {
        string GetString(string key);
    }
}
