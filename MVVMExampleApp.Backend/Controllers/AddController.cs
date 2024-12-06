using Microsoft.AspNetCore.Mvc;
using MVVMExampleApp.Backend.Models;
using MVVMExampleApp.Backend.Services;

namespace MVVMExampleApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddController : Controller
    {
        private readonly IAddService _addService;
        public AddController(IAddService addService)
        {
            _addService = addService;
        }

        [HttpPost]
        public async Task<ActionResult<AddResponse>> AddNumbers([FromBody] AddRequest request)
        {
            //check if model is valid 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //fake delay 
            await Task.Delay(3000);

            var result = _addService.Add(request.FirstInteger, request.SecondInteger);
            return Ok(new AddResponse { Result = result });
        }
    }
}
