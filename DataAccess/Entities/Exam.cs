using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Exam : BaseEntity
    {
        [Key]
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public DateTime StartExamDay { get; set; }
        public DateTime EndExamDay { get; set; }
    }
}
