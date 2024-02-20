using Services.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.DAL.Implementations
{
    internal sealed class LanguageRepository
    {
        #region singleton
        private readonly static LanguageRepository _instance = new LanguageRepository();

        public static LanguageRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LanguageRepository()
        {

        }
        #endregion

        private string basepath = ConfigurationManager.AppSettings["LenguagePath"];

        public string Find (string word)
        {
            using (var sr = new StreamReader(basepath + "." + Thread.CurrentThread.CurrentCulture.Name))
            {
               while (!sr.EndOfStream)
                {
                   string[] line = sr.ReadLine().Split('=');

                   if (line[0] == word)
                    
                   {
                      if (String.IsNullOrEmpty(line[1]))
                            
                          return line[0];

                       return line[1];
                    }
                }
            }

            throw new WordNotFoundException();
        }
        public void WriteNewWord (string word, string value)
        {


        }

        public Dictionary<string, string> FindAll()
        {
            return null;
        }
        public List <string> GetCurrentCultures()
        {
            return new List<string>();
        }
    }

}
