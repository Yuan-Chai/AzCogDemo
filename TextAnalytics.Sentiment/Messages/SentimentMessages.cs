using System;
using MediatR;

namespace TextAnalytics.Sentiment.Messages
{
    public class SentimentRequest : IRequest<SentimentResponse>
    {
       public string Message { get; set; }
    }

    public class SentimentResponse
    {
        public SentimentResponse(string referrenceId, string sentiment)
        {
            ReferrenceId = referrenceId;
            Sentiment = sentiment;
        }

        public string ReferrenceId { get; set; }
        public string Sentiment { get; set; }
    }
}
