using Microsoft.AspNetCore.Mvc;
using SparkPlug.Models.Dtos.Response;

namespace SparkPlug.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public override OkObjectResult Ok(object value)
        {
            var response = new Response
            {
                Data = value,
                Success = true,
                Message = "Successfully retrived data"
            };

            return base.Ok(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public new OkObjectResult Ok()
        {
            var response = new Response
            {
                Success = true,
                Message = "Operation was successful"
            };

            return base.Ok(response);
        }

    }
}
