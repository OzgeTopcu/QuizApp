using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutComeController : ControllerBase
    {
        private readonly IOutComeService _outComeService;

        public OutComeController(IOutComeService outComeService)
        {
            _outComeService = outComeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _outComeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _outComeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _outComeService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("quiz/{examId}")]
        public IActionResult GetByExamId(int examId)
        {
            var result = _outComeService.GetByExamId(examId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OutCome outCome)
        {
            var result = _outComeService.Add(outCome);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] OutCome outCome)
        {
            var result = _outComeService.Update(outCome);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }

}