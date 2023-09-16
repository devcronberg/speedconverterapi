using Microsoft.AspNetCore.Mvc;

namespace SpeedConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeedConverterController : ControllerBase
    {
        // GET api/speedconverter?mph=60
        [HttpGet]
        public ActionResult<SpeedResponse> ConvertSpeedToKmt(double mph)
        {
            double kmt = ConvertMphToKmt(mph);
            return Ok(new SpeedResponse { Mph = mph, Kmt = kmt });
        }

        // POST api/speedconverter
        [HttpPost]
        public ActionResult<SpeedResponse> ConvertSpeedToKmt([FromBody] SpeedRequest request)
        {
            double kmt = ConvertMphToKmt(request.Mph);
            return Ok(new SpeedResponse { Mph = request.Mph, Kmt = kmt });
        }

        private double ConvertMphToKmt(double mph)
        {
            return mph * 1.60934;
        }
    }

    public class SpeedRequest
    {
        public double Mph { get; set; }
    }

    public class SpeedResponse
    {
        public double Mph { get; set; }
        public double Kmt { get; set; }
        public DateTime ServerTime { get; set; }

        public SpeedResponse()
        {
            ServerTime = DateTime.Now;
        }
    }
}
