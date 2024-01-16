using CbrAdapter.Database.Repositories;
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
        private readonly IKeyRateRepository _keyRateRepository;
        private readonly ILogger<DailyInfoController> _logger;

        public DailyInfoController(
            IKeyRateRepository keyRateRepository,
            ILogger<DailyInfoController> logger)
        {
            _keyRateRepository = keyRateRepository;
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

            if (response != null)
            {

                response.KeyRates = response.KeyRates?.OrderBy(item => item.Date).ToList();

                return Ok(response);
            }

            return Ok();
        }

        [HttpPost("CreateKeyRate")]
        public async Task<IActionResult> CreateKeyRate()
        {
            var client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12);

            await client.OpenAsync();

            var keyRateResponse = await client.KeyRateXMLAsync(new KeyRateXMLRequest
            {
                fromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now
            });

            await client.CloseAsync();

            var xml = new XmlDocument();
            var root = xml.CreateElement("root");
            root.InnerXml = keyRateResponse.KeyRateXMLResult.InnerXml;
            xml.AppendChild(root);

            var response = Deserialize<Models.KeyRateResponse>(xml);

            if (response != null)
            {
                await _keyRateRepository.Create(new Database.Models.KeyRate
                {
                    Value = response.KeyRates[0].Rate,
                    Date = DateTime.SpecifyKind(response.KeyRates[0].Date, DateTimeKind.Utc)
                });

                return Ok(response);
            }

            return Ok();
        }


        private T? Deserialize<T>(XmlDocument document)
        {
            return (T?)new XmlSerializer(typeof(T?)).Deserialize(new XmlNodeReader(document));
        }
    }
}