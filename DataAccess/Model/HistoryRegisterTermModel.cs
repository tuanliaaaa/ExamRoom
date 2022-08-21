using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class HistoryRegisterTermModel
    {
        public int HistoryRegisterTermID { get; set; }
        public string HistoryRegisterTermCode { get; set; }
        public int UserID { get; set; }
        public int ExamID { get; set; }
        public DateTime RegisterDay { get; set; }
        public string Payments { get; set; }
        public string MoneyNumber { get; set; }
        public string DayPay { get; set; }
    }
    public class HistoryRegisterTermMapExamModel
    {
        public string HistoryRegisterTermCode { get; set; }
        public ExamMapExamSubjects Exam { get; set; }
        public DateTime RegisterDay { get; set; }
        public string Payments { get; set; }
        public string MoneyNumber { get; set; }
        public string DayPay { get; set; }
        public DateTime EndExamDay { get; set; }
        public DateTime StartExamDay { get; set; }
    }
}
