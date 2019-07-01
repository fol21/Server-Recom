using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using ServerRecom.Application.Config;

namespace ServerRecom.Application.Controllers
{
    [Route("api/prediction")]
    public class PredictionController : Controller
    {
        private readonly ICustomVisionConfiguration _cvConfig;

        public PredictionController(ICustomVisionConfiguration cvConfig)
        {
            _cvConfig = cvConfig;
        }

        [HttpPost("server")]
        public JsonResult CountServers()
        {
            // var stream = new MemoryStream(imageBytes);
            Stream stream = System.IO.File.OpenRead(Path.Combine("Dataset", "Servers", "server-rack44.jpg"));
            CustomVisionPredictionClient client = new CustomVisionPredictionClient()
            {
                ApiKey = _cvConfig.PredictionKey,
                Endpoint = _cvConfig.Endpoint
            };
            var result = client.DetectImage(new System.Guid("e59a412e-256c-470b-b604-5c3960a45d93"), "machine-vision-iteration-4", stream);
            return Json(result);
        }
        
    }
}