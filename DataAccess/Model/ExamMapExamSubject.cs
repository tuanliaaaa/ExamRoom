using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ExamMapExamSubject
    {
        public string ExamName { get; set; }
        public string ExamSubjectName { get; set; }
    }
    public class ExamMapExamSubjects
    {
        public string ExamName { get; set; }
        public List<ExamSubjectModel> ExamSubjectName { get; set; }
    }
}
