using System;
using System.Collections.Generic;

namespace TextAnalytics.Sentiment.Models
{
    public class TextAnalyticsBatchInput
    {
        public IList<TextAnalyticsInput> Documents { get; set; }


        public TextAnalyticsBatchInput(string content)
        {
            Documents = new List<TextAnalyticsInput>()
                {
                    new TextAnalyticsInput{
                        Id = Guid.NewGuid().ToString(),
                        Text = content
                     }
                };
        }
    }
}
