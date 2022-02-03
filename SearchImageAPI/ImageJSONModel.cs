using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SearchImageAPI
{
    public class Instrumentation
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
    }

    public class QueryContext
    {
        [JsonProperty("originalQuery")]
        public string OriginalQuery { get; set; }

        [JsonProperty("alterationDisplayQuery")]
        public string AlterationDisplayQuery { get; set; }

        [JsonProperty("alterationOverrideQuery")]
        public string AlterationOverrideQuery { get; set; }

        [JsonProperty("alterationMethod")]
        public string AlterationMethod { get; set; }

        [JsonProperty("alterationType")]
        public string AlterationType { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class InsightsMetadata
    {
        [JsonProperty("pagesIncludingCount")]
        public int PagesIncludingCount { get; set; }

        [JsonProperty("availableSizesCount")]
        public int AvailableSizesCount { get; set; }
    }

    public class Value
    {
        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("datePublished")]
        public DateTime DatePublished { get; set; }

        [JsonProperty("isFamilyFriendly")]
        public bool IsFamilyFriendly { get; set; }

        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }

        [JsonProperty("hostPageUrl")]
        public string HostPageUrl { get; set; }

        [JsonProperty("contentSize")]
        public string ContentSize { get; set; }

        [JsonProperty("encodingFormat")]
        public string EncodingFormat { get; set; }

        [JsonProperty("hostPageDisplayUrl")]
        public string HostPageDisplayUrl { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("hostPageDiscoveredDate")]
        public DateTime HostPageDiscoveredDate { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("imageInsightsToken")]
        public string ImageInsightsToken { get; set; }

        [JsonProperty("insightsMetadata")]
        public InsightsMetadata InsightsMetadata { get; set; }

        [JsonProperty("imageId")]
        public string ImageId { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }

        [JsonProperty("hostPageFavIconUrl")]
        public string HostPageFavIconUrl { get; set; }

        [JsonProperty("hostPageDomainFriendlyName")]
        public string HostPageDomainFriendlyName { get; set; }
    }

    public class ImageRoot
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("instrumentation")]
        public Instrumentation Instrumentation { get; set; }

        [JsonProperty("readLink")]
        public string ReadLink { get; set; }

        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("queryContext")]
        public QueryContext QueryContext { get; set; }

        [JsonProperty("totalEstimatedMatches")]
        public int TotalEstimatedMatches { get; set; }

        [JsonProperty("nextOffset")]
        public int NextOffset { get; set; }

        [JsonProperty("currentOffset")]
        public int CurrentOffset { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }


}
