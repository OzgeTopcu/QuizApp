using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OutCome : IEntitiy
    {
        public int OutComeId { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public float Score { get; set; }
        public float SuccessRate { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}