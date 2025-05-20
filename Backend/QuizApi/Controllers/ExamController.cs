using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _examService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{examId}")]
        public IActionResult GetById(int examId)
        {
            var result = _examService.GetById(examId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] Exam exam)
        {
            var result = _examService.Add(exam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{examId}")]
        public IActionResult Delete(int id)
        {
            var result = _examService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{examId}")]
        public IActionResult Update([FromBody] Exam exam)
        {
            var result = _examService.Update(exam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{examId}/Questions")]
        public IActionResult GetQuestionsByExamId(int examId)
        {
            var result = _examService.GetQuestionByExamId(examId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("Questions/Options/{examId}")]
        public IActionResult GetOptionsByExamId(int examId)
        {
            var result = _examService.GetOptionsByExamId(examId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
    }
}