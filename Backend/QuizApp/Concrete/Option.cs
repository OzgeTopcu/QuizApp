using Core.Entities;

using System;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Concrete

{
    public class Option : IEntitiy

    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }

    }

}

