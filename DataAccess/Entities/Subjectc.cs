using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Subjectc : BaseEntity
    {
        [Key]
        public int SubjectcID { get; set; }
        public int TermID { get; set; }
        public string SubjectcName { get; set; }
        public DateTime SubjectcDate { get; set; }
    }
}
