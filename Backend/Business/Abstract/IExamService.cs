using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExamService
    {
        IResult Add(Exam exam);
        IResult Update(Exam exam);
        IResult Delete(int Examid);
        IDataResult<List<Exam>> GetAll();
        IDataResult<List<Question>> GetQuestionByExamId(int examId);
        IDataResult<List<Option>> GetOptionsByExamId(int optionId);
        IDataResult<Exam> GetById(int examId);

    }
}