using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Exeptions
{
    internal class WordNotFoundException : Exception
    {
        public WordNotFoundException(string message): base(message)
        {
            
        }
        public WordNotFoundException(): base("Palabra no encontrada")
        {

        }
    }
}
