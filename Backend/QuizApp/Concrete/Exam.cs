using Core.Entities;

using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete

{

    public class Exam : IEntitiy

    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public ICollection<Question> Questions { get; set; }



    }

}

