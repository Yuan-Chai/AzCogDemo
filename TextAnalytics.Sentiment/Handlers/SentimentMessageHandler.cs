using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Sentiment;
using MediatR;
using Newtonsoft.Json;
using TextAnalytics.Sentiment.Messages;
using TextAnalytics.Sentiment.Models;

namespace TextAnalytics.Sentiment.Handlers
{
    public class SentimentMessageHandler : IRequestHandler<SentimentRequest, SentimentResponse>
    {
        private readonly ISentimentClient _client;

        public SentimentMessageHandler(ISentimentClient client)
        {
            _client = client;
        }

        public async Task<SentimentResponse> Handle(SentimentRequest request, CancellationToken cancellationToken)
        {
            var inputs = new TextAnalyticsBatchInput(request.Message);

            var result = await _client.PostAync<SentimentV3Response>(JsonConvert.SerializeObject(inputs));

            var document = result.Documents.FirstOrDefault();

            if(document is null)
            {
                throw new Exception("You did something really wrong, you are failed");
            }

            return new SentimentResponse(document.Id, document.Sentiment.ToString());
        }
    }
}
