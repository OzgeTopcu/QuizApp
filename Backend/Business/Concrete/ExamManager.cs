using Business.Abstract;

using Business.Constants;

using Business.ValidationRules.FluentValidation;

using Core.Aspects.Autofac.Validation;

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

    public class ExamManager : IExamService

    {

        IExamDal _examDal;

        IQuestionDal _questionDal;

        IOptionDal _optionDal;


        public ExamManager(IExamDal examDal, IOptionDal optionDal, IQuestionDal questionDal)

        {

            _examDal = examDal;

            _questionDal = questionDal;

            _optionDal = optionDal;

        }

        public IResult Add(Exam exam)

        {

            _examDal.Add(exam);

            return new SuccessResult(Messages.EntityAdded);

        }

        public IResult Update(Exam exam)

        {

            _examDal.Update(exam);

            return new SuccessResult(Messages.EntityUpdated);

        }

        public IResult Delete(int Examid)

        {

            var user = _examDal.Get(u => u.ExamId == Examid);

            if (user != null)

            {

                _examDal.Delete(user);

                return new SuccessResult(Messages.EntityDeleted);

            }

            return new ErrorResult("Exam not found.");

        }

        public IDataResult<List<Exam>> GetAll()

        {

            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(), (Messages.EntityListed));

        }

        public IDataResult<Exam> GetById(int examId)

        {

            return new SuccessDataResult<Exam>(_examDal.Get(e => e.ExamId == examId), (Messages.EntityListed));

        }

        public IDataResult<List<Question>> GetQuestionByExamId(int examId)

        {

            var result = _examDal.GetQuestionByExamId(examId);

            if (result == null)

            {

                return new ErrorDataResult<List<Question>>(null, "not found");

            }

            return new SuccessDataResult<List<Question>>(result, "succesfuly");

        }


        public IDataResult<List<Option>> GetOptionsByExamId(int examId)

        {

            var result = _examDal.GetOptionByExamId(examId);

            if (result == null)

            {

                return new ErrorDataResult<List<Option>>(null, "not found");

            }

            return new SuccessDataResult<List<Option>>(result, "succesfuly");

        }

    }

}
