using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OutComeManager : IOutComeService
    {
        IOutComeDal _outComeDal;

        public OutComeManager(IOutComeDal outComeDal)
        {
            _outComeDal = outComeDal;
        }
        public IResult Add(OutCome outCome)
        {
            _outComeDal.Add(outCome);
            return new SuccessResult(Messages.EntityAdded);
        }


        public IDataResult<List<OutCome>> GetAll()
        {
            return new SuccessDataResult<List<OutCome>>(_outComeDal.GetAll(), Messages.EntityListed);
        }

        public IDataResult<OutCome> GetByExamId(int examId)
        {
            return new SuccessDataResult<OutCome>(_outComeDal.Get(q => q.ExamId == examId));
        }

        public IDataResult<OutCome> GetById(int id)
        {
            return new SuccessDataResult<OutCome>(_outComeDal.Get(q => q.OutComeId == id));
        }

        public IDataResult<OutCome> GetByUserId(int userId)
        {
            return new SuccessDataResult<OutCome>(_outComeDal.Get(q => q.UserId == userId));
        }

        public IResult Update(OutCome outCome)
        {
            {
                if (outCome.OutComeId > 0)
                {
                    _outComeDal.Update(outCome);
                    return new SuccessResult(Messages.EntityUpdated);
                }
                return new ErrorResult(Messages.EntityUpdatedError);
            }
        }
    }
}