using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        IOptionDal _optionDal;
        public QuestionManager(IQuestionDal questionDal, IOptionDal optionDal)
        {
            _questionDal = questionDal;
            _optionDal = optionDal;
        }

        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(int questionId)
        {
            var user = _questionDal.Get(u => u.QuestionId == questionId);
            if (user != null)
            {
                _questionDal.Delete(user);
                return new SuccessResult("Question Deleted");
            }
            return
            new
            ErrorResult("Question not found.");
        }

        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(), Messages.EntityListed);
        }

        public IDataResult<Question> GetByExamId(int examId)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(q => q.ExamId == examId));
        }

        public IDataResult<Question> GetById(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(q => q.QuestionId == id));
        }

        public IDataResult<List<Option>> GetOptionById(int questionId)
        {
            var result = _questionDal.GetOptionById(questionId);
            if (result == null)
            {
                return new ErrorDataResult<List<Option>>(null, "not found");
            }
            return new SuccessDataResult<List<Option>>(result, "succesfuly");
        }

        public IResult Update(Question question)
        {
            if (question.QuestionId > 0)
            {
                _questionDal.Update(question);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdatedError);
        }
    }
}