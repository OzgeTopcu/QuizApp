using Business.Abstract;

using Entities.Concrete;

using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class OptionController : ControllerBase

    {

        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)

        {

            _optionService = optionService;

        }

        [HttpGet("getall")]

        public IActionResult GetAll()

        {

            var result = _optionService.GetAll();

            if (result.Success)

            {

                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)

        {

            var result = _optionService.GetById(id);

            if (result.Success)

            {

                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpPost("add")]

        public IActionResult Add([FromBody] Option option)

        {

            var result = _optionService.Add(option);

            if (result.Success)

            {

                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)

        {

            var result = _optionService.Delete(id);

            if (result.Success)

            {

                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpPut("update")]

        public IActionResult Update([FromBody] Option option)

        {

            var result = _optionService.Update(option);

            if (result.Success)

            {

                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("Question/{questionId}")]

        public IActionResult GetByQuestionId(int questionId)

        {

            var result = _optionService.GetByQuestionId(questionId);

            if (result.Success)

            {

                return Ok(result.Data);

            }

            return BadRequest(result.Message);

        }

    }

}

