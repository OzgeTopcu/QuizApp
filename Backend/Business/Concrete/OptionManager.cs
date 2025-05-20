using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OptionManager : IOptionService
    {
        IOptionDal _optionDal;

        public OptionManager(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }

        public IResult Add(Option option)
        {
            _optionDal.Add(option);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(int optionId)
        {
            var user = _optionDal.Get(u => u.OptionId == optionId);
            if (user != null)
            {
                _optionDal.Delete(user);
                return new SuccessResult(Messages.EntityDeleted);
            }
            return
            new
            ErrorResult("Option not found.");
        }


        public IDataResult<List<Option>> GetAll()
        {
            return new SuccessDataResult<List<Option>>(_optionDal.GetAll(), Messages.EntityListed);
        }

        public IResult Update(Option option)
        {
            if (option.OptionId > 0)
            {
                _optionDal.Update(option);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdatedError);
        }

        public IDataResult<Option> GetById(int id)
        {
            return new SuccessDataResult<Option>(_optionDal.Get(q => q.OptionId == id), (Messages.EntityListed));
        }

        public IDataResult<List<Option>> GetByQuestionId(int questionId)
        {
            var result = _optionDal.GetAll(a => a.QuestionId == questionId);
            return new SuccessDataResult<List<Option>>(result, "Successfully");
        }
    }
}
