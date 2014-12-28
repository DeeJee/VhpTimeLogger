using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VhpTimeLogger.Diversen
{
    public class DatabaseNotAvailableException:Exception
    {
        public DatabaseNotAvailableException(string message, Exception ex):base(message, ex)
        {            
        }        
    }
}
