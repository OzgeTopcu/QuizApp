using Core.DataAccess.EntityFramework;

using DataAccess.Abstract;

using Entities.Concrete;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework

{

    public class QuestionDal : EfEntityRepositoryBase<Question, QuizAppContext>, IQuestionDal

    {

        public List<Option> GetOptionById(int questionId)

        {

            using (var context = new QuizAppContext())

            {

                return context.Options.Where(q => q.QuestionId == questionId).ToList();

            }

        }

    }

}

