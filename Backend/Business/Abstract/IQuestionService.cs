using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        IResult Add(Question question);
        IResult Update(Question question);
        IResult Delete(int questionId);
        IDataResult<List<Question>> GetAll();
        IDataResult<Question> GetById(int id);
        IDataResult<List<Option>> GetOptionById(int questionId);
        IDataResult<Question> GetByExamId(int examId);
    }
}