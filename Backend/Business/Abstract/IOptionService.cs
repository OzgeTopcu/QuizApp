using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOptionService
    {
        IResult Add(Option option);
        IResult Update(Option option);
        IResult Delete(int optionId);
        IDataResult<List<Option>> GetAll();
        IDataResult<Option> GetById(int id);
        IDataResult<List<Option>> GetByQuestionId(int questionId);

    }
}