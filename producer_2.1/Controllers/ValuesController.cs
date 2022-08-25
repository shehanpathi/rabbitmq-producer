
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ms_common_model.nonFinanceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace producer_2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPublishEndpoint _bus;
        public ValuesController(IPublishEndpoint bus)
        {
            _bus = bus;
        }

        public async Task Index()
        {
            NonFinanceLogRequest req = new NonFinanceLogRequest() { CIF = "1", Description = "2", Event = "1", Username = "abc", Remarks = "Remarks" };

            await _bus.Publish<NonFinanceLogRequest>(req, x =>
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

        }
    }
}
