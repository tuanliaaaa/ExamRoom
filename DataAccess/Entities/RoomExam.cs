using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class RoomExam :BaseEntity
    {
        public int RoomExamID { get; set; }
        public int SubjectcID { get; set; }
        public string RoomExamName { get; set; }
    }
}
