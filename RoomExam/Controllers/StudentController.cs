using DataAccess;
using DataAccess.Entities;
using DataAccess.Migrations;
using DataAccess.Model;
using DataAccess.Repository.Interfaces;
using DataAccess.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RoomExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUser<User> _user;
        private readonly IHistoryRegisterTerm<HistoryRegisterTerm> _historyRegisterTerm;
        private readonly Context _dbContext;
        public StudentController(ILogger<AccountController> logger, IUser<User> user, IHistoryRegisterTerm<HistoryRegisterTerm> historyRegisterTerm, Context dbContext)
        {
            _logger = logger;
            _user = user;
            _historyRegisterTerm = historyRegisterTerm;
            _dbContext = dbContext;

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/Students")]
        public async Task<IActionResult> StudentList()
        {
            IEnumerable<User> students = await _user.GetUserList();
            List<UserResponse> studentsReponse = new List<UserResponse>();
            foreach (User user in students)
            {
                UserResponse studentResponse = new UserResponse()
                {
                    UserID = user.UserID,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Sex = user.Sex,
                    Username = user.Username,
                    UserType = user.UserType,
                    Image = user.Image
                };
                studentsReponse.Add(studentResponse);
            }
            return Ok(studentsReponse);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/HistoryRegisterTerm")]
        public IActionResult StudentLisst()
        {
            var QyexamAndSubject = from a in _dbContext.Exams
                                   join b in _dbContext.ExamSubjects
                                   on a.ExamID equals b.ExamID
                                   select new
                                   {
                                       ExamName = a.ExamName,
                                       ExamSubjectName = b.ExamSubjectName
                                   };
            List<ExamMapExamSubject> examMapExamSubjectList = new List<ExamMapExamSubject>();
            foreach (var exam in QyexamAndSubject)
            {
                ExamMapExamSubject examMapExamSubject = new ExamMapExamSubject()
                {
                    ExamName = exam.ExamName,
                    ExamSubjectName = exam.ExamSubjectName
                };
                examMapExamSubjectList.Add(examMapExamSubject);
            }
            List<ExamMapExamSubjects> ExamMapExamSubjectsList = new List<ExamMapExamSubjects>();
            List<ExamSubjectModel> examSubjectList = new List<ExamSubjectModel>();
            ExamSubjectModel examSubject = new ExamSubjectModel();
            ExamMapExamSubjects ExamMapExamSubjects = new ExamMapExamSubjects();
            for (int i = 0; i < examMapExamSubjectList.Count - 1; i++)
            {
                examSubject = new ExamSubjectModel()
                {
                    ExamSubjectName = examMapExamSubjectList[i].ExamSubjectName
                };

                examSubjectList.Add(examSubject);
                if (examMapExamSubjectList[i].ExamName != examMapExamSubjectList[i + 1].ExamName)
                {

                    ExamMapExamSubjects = new ExamMapExamSubjects()
                    {
                        ExamName = examMapExamSubjectList[i].ExamName,
                        ExamSubjectName = examSubjectList
                    };
                    ExamMapExamSubjectsList.Add(ExamMapExamSubjects);
                    examSubjectList = new List<ExamSubjectModel>();
                }


            }
            if (examMapExamSubjectList[examMapExamSubjectList.Count() - 1].ExamName != examMapExamSubjectList[examMapExamSubjectList.Count() - 2].ExamName)
            {
                examSubjectList = new List<ExamSubjectModel>();
            }

            examSubject = new ExamSubjectModel()
            {
                ExamSubjectName = examMapExamSubjectList[examMapExamSubjectList.Count() - 1].ExamSubjectName
            };
            examSubjectList.Add(examSubject);
            ExamMapExamSubjects = new ExamMapExamSubjects()
            {
                ExamName = examMapExamSubjectList[examMapExamSubjectList.Count() - 1].ExamName,
                ExamSubjectName = examSubjectList
            };
            ExamMapExamSubjectsList.Add(ExamMapExamSubjects);

            var historyRegisterTerms = from a in _dbContext.HistoryRegisterTerms
                                       join b in _dbContext.Exams
                                       on a.ExamID equals b.ExamID
                                       select new
                                       {
                                           HistoryRegisterTermCode = a.HistoryRegisterTermCode,
                                           ExamCode = b.ExamName,
                                           Payments = a.Payments,
                                           Daypay = a.DayPay,
                                           MoneyNumber = a.MoneyNumber,
                                           RegisterDay = a.RegisterDay,
                                           StartExamDay = b.StartExamDay,
                                           EndExamDay= b.EndExamDay 
                                       };
            List<HistoryRegisterTermMapExamModel> HistoryRegisterTermMapExamModelList = new List<HistoryRegisterTermMapExamModel>();
            ExamMapExamSubjects j =new ExamMapExamSubjects();
            foreach (var historyRegisterTerm in historyRegisterTerms)
            {
                foreach(var ExamMapExamSubject in ExamMapExamSubjectsList)
                {
                    if(ExamMapExamSubject.ExamName== historyRegisterTerm.ExamCode)
                    {
                       j= ExamMapExamSubject;
                    }
                }    
                HistoryRegisterTermMapExamModel historyRegisterTermMapExamModel = new HistoryRegisterTermMapExamModel()
                {
                    HistoryRegisterTermCode = historyRegisterTerm.HistoryRegisterTermCode,
                    Exam = j,
                    RegisterDay = historyRegisterTerm.RegisterDay,
                    Payments = historyRegisterTerm.Payments,
                    MoneyNumber = historyRegisterTerm.MoneyNumber,
                    DayPay = historyRegisterTerm.Daypay,
                    StartExamDay = historyRegisterTerm.StartExamDay,
                    EndExamDay = historyRegisterTerm.EndExamDay
                };
                HistoryRegisterTermMapExamModelList.Add(historyRegisterTermMapExamModel);
            }
            return Ok(HistoryRegisterTermMapExamModelList);
        }
    }

}
