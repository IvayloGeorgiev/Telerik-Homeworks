using BulgarianDay.Client.BulgarianDayServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDay.Client
{
    class MainEntry
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DateServiceClient client = new DateServiceClient();
            Console.WriteLine(client.GetDay(DateTime.Now));

            client.Close();
        }
    }
}
