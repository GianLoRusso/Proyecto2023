using Services.DAL.Factory;
using Services.DAL.Implementations;
using Services.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{
    internal static class LanguageBLL
    {
        public static string Translate(string word)
        {
            try
            {
                return ServiceFactory.LanguageRepository.Find(word);
            }
            catch (WordNotFoundException)
            {
                ServiceFactory.LanguageRepository.WriteNewWord(word, String.Empty);
                return word;
            }
        }
    }
}
