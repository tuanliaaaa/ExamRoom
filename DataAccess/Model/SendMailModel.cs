using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class SendMailModel
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
