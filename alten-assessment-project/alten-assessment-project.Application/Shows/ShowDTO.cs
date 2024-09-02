using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace alten_assessment_project.Application.Shows
{
    public partial class ShowDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("runtime")]
        public long? Runtime { get; set; }

        [JsonProperty("averageRuntime")]
        public long AverageRuntime { get; set; }

        [JsonProperty("premiered")]
        public string Premiered { get; set; }

        [JsonProperty("ended")]
        public string? Ended { get; set; }

        [JsonProperty("officialSite")]
        public string OfficialSite { get; set; }

        [JsonProperty("schedule")]
        public ScheduleDTO Schedule { get; set; }

        [JsonProperty("rating")]
        public RatingDTO Rating { get; set; }

        [JsonProperty("weight")]
        public long? Weight { get; set; }

        [JsonProperty("network")]
        public NetworkDTO Network { get; set; }

        [JsonProperty("webChannel")]
        public WebChannelDTO WebChannel { get; set; }

        [JsonProperty("dvdCountry")]
        public CountryDTO DvdCountry { get; set; }

        [JsonProperty("externals")]
        public ExternalDTO External { get; set; }

        [JsonProperty("image")]
        public ImageDTO Image { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("_links")]
        public LinkDTO Link { get; set; }
    }

    public partial class CountryDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public partial class ExternalDTO
    {
        [JsonProperty("tvrage")]
        public int? Tvrage { get; set; }

        [JsonProperty("thetvdb")]
        public long? Thetvdb { get; set; }

        [JsonProperty("imdb")]
        public string Imdb { get; set; }
    }

    public partial class ImageDTO
    {
        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }
    }

    public partial class LinkDTO
    {
        [JsonProperty("self")]
        public SelfDTO Self { get; set; }

        [JsonProperty("previousepisode")]
        public EpisodeDTO Previousepisode { get; set; }

        [JsonProperty("nextepisode", NullValueHandling = NullValueHandling.Ignore)]
        public EpisodeDTO Nextepisode { get; set; }
    }

    public partial class EpisodeDTO
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class SelfDTO
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class NetworkDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public CountryDTO Country { get; set; }

        [JsonProperty("officialSite")]
        public string OfficialSite { get; set; }
    }

    public partial class WebChannelDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public CountryDTO Country { get; set; }

        [JsonProperty("officialSite")]
        public string OfficialSite { get; set; }
    }

    public partial class RatingDTO
    {
        [JsonProperty("average")]
        public double? Average { get; set; }
    }

    public partial class ScheduleDTO
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("days")]
        public string Days { get; set; }
    }
}
