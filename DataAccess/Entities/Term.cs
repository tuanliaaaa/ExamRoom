using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Term : BaseEntity
    {
        [Key]
        public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime TermDateTime { get; set; }
    }
}
