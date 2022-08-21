using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ExamRoom :BaseEntity
    {
        public int ExamRoomID{ get; set; }
        public string ExamRoomName{ get; set; }
        public int ExamSubjectID{ get; set; }
        public DateTime ExamStartTime { get; set; }
        public DateTime ExamEndTime { get; set; }
    }
}
