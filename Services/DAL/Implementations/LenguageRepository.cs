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
    internal class LenguageRepository
    {
        #region singleton
        private readonly static LenguageRepository _instance = new LenguageRepository();

        public static LenguageRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LenguageRepository()
        {

        }
        #endregion

        private string basepath = ConfigurationManager.AppSettings["LenguagePath"];

        public string Find(string word)
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

            //throw new WordNotFoundException();
        }
        public void WriteNewWord (string word, string value)
        {


        }

        public Dictionary<string, string> FindAll()
        {
            return null;
        }
    }

}
