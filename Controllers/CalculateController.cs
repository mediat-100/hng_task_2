using Microsoft.AspNetCore.Mvc;

namespace hng_task_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody] InputRequest inputRequest)
        {
            var operation = inputRequest.operation_type;
            int result;
            switch (operation)
            {
                case "addition":
                    result = inputRequest.x + inputRequest.y;
                    break;

                case "subtraction":
                    result = inputRequest.x - inputRequest.y;
                    break;

                case "multiplication":
                    result = inputRequest.x * inputRequest.y;
                    break;

                default:
                    result = 00;
                    break;
            }

            if (result == 00)
            {
                return BadRequest("Invalid operation");
            }

            var outputResult = new OutputRequest()
            {
                slackUsername = "Tomz",
                result = result,
                operation_type = operation
            };
            return Ok(outputResult);
        }
    }
}
