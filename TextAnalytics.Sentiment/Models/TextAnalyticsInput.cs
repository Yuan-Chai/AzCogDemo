﻿namespace TextAnalytics.Sentiment.Models
{
    public class TextAnalyticsInput
    {
        /// <summary>
        /// A unique, non-empty document identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The input text to process.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The language code. Default is english ("en").
        /// </summary>
        public string LanguageCode { get; set; } = "en";
    }
}
