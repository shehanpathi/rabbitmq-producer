using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ms_common_model.cards;
using ms_common_model.nonFinanceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogPublishController : ControllerBase
    {

        private readonly ILogger<LogPublishController> _logger;

        public LogPublishController(ILogger<LogPublishController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            PublishEndpoint = publishEndpoint;
        }

        public IPublishEndpoint PublishEndpoint { get; }

        [HttpGet]
        public async Task<IActionResult> PublishMessage()
        {
            NonFinanceLogRequest req = new() { CIF = "1", Description = "2", Event = "1", Username = "abc", Remarks = "Remarks" };

            await PublishEndpoint.Publish<NonFinanceLogRequest>(req, x =>
            {
                x.Headers.Set("datetime", "2002-10-10");
                x.Headers.Set("uuid", "1111");
                x.Headers.Set("username", "test");
                x.Headers.Set("channel", "2");
                x.Headers.Set("languageCode", "en");
                x.Headers.Set("requestType", "1234");
                x.Headers.Set("subscriptionId", "12323131");
                x.Headers.Set("version", "1234");
            });
            return Ok();

        }
    }
}
