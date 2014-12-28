using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VhpDataLogic
{
    public class DatabaseNotAvailableException:Exception
    {
        public DatabaseNotAvailableException(string message, Exception ex):base(message, ex)
        {            
        }        
    }
}
