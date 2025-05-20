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
    public class ExamDal : EfEntityRepositoryBase<Exam, QuizAppContext>, IExamDal
    {
        public List<Option> GetOptionByExamId(int questionId)
        {
            using (var context = new QuizAppContext())
            {
                return context.Options.Where(q => q.QuestionId == questionId).ToList();
            }

        }
        public List<Question> GetQuestionByExamId(int examId)
        {
            using (var context = new QuizAppContext())
            {
                return context.Questions.Where(q => q.ExamId == examId).ToList();
            }
        }
    }
}