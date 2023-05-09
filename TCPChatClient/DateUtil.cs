using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPChatClient
{
    internal class DateUtil
    {
        public static string GetTime()
        {
            return "\r\n" + DateTime.Now.ToString() + "\r\n";
        }
    }
}
