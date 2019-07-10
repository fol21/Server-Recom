using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using ServerRecom.Application.Config;
using ServerRecom.Application.Extensions;

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
        public async Task<ContentResult> CountServers()
        {             
            // Stream stream = System.IO.File.OpenRead(Path.Combine("Dataset", "Servers", "server-rack44.jpg"));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Prediction-Key", _cvConfig.PredictionKey);

            var content = new ByteArrayContent(Request.GetRawBodyBytes());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            string url = $"{_cvConfig.Endpoint}/customvision/v3.0/Prediction/{_cvConfig.ProjectId}/detect/iterations/{_cvConfig.PublishedAs}/image";
            HttpResponseMessage response = await client.PostAsync(url, content);
            var resContent = await response.Content.ReadAsStringAsync();

            return Content(resContent, "application/json");
        }

        private static Stream _GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }        
    }
}
