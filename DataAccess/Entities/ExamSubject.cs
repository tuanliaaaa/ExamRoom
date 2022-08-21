using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ExamSubject : BaseEntity
    {
        [Key]
        public int ExamSubjectID{ get; set; }
        public string ExamSubjectName{ get; set; }
        public int ExamID{ get; set; }
        public DateTime DayExam{ get; set; }
    }
}
