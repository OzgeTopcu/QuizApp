using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Question : IEntitiy
    {
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public string Text { get; set; }
        public Exam Exam { get; set; }
        public ICollection<Option> Options { get; set; }


    }
}