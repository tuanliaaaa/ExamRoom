using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class StoryRegister :BaseEntity
    {
        [Key]
        public int StoryRegisterID { get; set; }
        public int RoomExamID { get; set; }
        public int UserID { get; set; } 
        public string PaymentMethod { get; set; }
        public bool IsPayment { get; set; }
        public DateTime StoryRegisteryDay { get; set; }
    }
}
