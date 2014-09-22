using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace BulgarianDay
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DateService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DateService.svc or DateService.svc.cs at the Solution Explorer and start debugging.
    public class DateService : IDateService
    {        
        public string GetDay(DateTime date)
        {
            string result = date.ToString("dddd", new CultureInfo("bg-BG"));
            return result;
        }
    }
}
