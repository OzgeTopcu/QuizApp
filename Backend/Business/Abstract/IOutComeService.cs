using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOutComeService
    {
        IResult Add(OutCome outCome);
        IResult Update(OutCome outCome);
        IDataResult<List<OutCome>> GetAll();
        IDataResult<OutCome> GetById(int id);
        IDataResult<OutCome> GetByUserId(int userId);
        IDataResult<OutCome> GetByExamId(int examId);
    }
}