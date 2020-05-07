using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TextAnalytics.Sentiment.Messages;

namespace ApiHost.Controllers
{
    [Route("api/[controller]")]
    public class SentimentController : Controller
    {
        private readonly IMediator _meidator;

        public SentimentController(IMediator mediator)
        {
            _meidator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SentimentRequest request)
        {
            return new OkObjectResult(await _meidator.Send(request));
        }
    }
}
