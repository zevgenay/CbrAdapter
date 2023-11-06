using CbrAdapter.Models;
using CbrService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace CbrAdapter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class DailyInfoController : ControllerBase
    {
        private readonly ILogger<DailyInfoController> _logger;

        public DailyInfoController(ILogger<DailyInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetKeyRate")]
        public async Task<IActionResult> GetKeyRate()
        {
            var client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12);

            await client.OpenAsync();

            var keyRateResponse = await client.KeyRateXMLAsync(new KeyRateXMLRequest
            {
                fromDate = DateTime.Now.AddDays(-100),
                ToDate = DateTime.Now
            });

            await client.CloseAsync();

            var xml = new XmlDocument();
            var root = xml.CreateElement("root");
            root.InnerXml = keyRateResponse.KeyRateXMLResult.InnerXml;
            xml.AppendChild(root);

            var response = Deserialize<Models.KeyRateResponse>(xml);

            return Ok(response);
        }

        private T Deserialize<T>(XmlDocument document)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(new XmlNodeReader(document));
        }
    }
}