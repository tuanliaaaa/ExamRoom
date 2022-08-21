using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class HistoryRegisterTerm :BaseEntity
    {
        [Key]
        public int HistoryRegisterTermID{ get; set; }
        public string HistoryRegisterTermCode{ get; set; }
        public int UserID{ get; set; }
        public int ExamID{ get; set; }
        public DateTime RegisterDay { get; set; }
        public string Payments { get; set; }
        public string MoneyNumber { get; set; }
        public string DayPay { get; set; }

    }
}
