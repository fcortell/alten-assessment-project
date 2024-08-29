﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace alten_assessment_project.Application.Shows
{
    public partial class ShowsDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("runtime")]
        public long? Runtime { get; set; }

        [JsonProperty("averageRuntime")]
        public long AverageRuntime { get; set; }

        [JsonProperty("premiered")]
        public DateTimeOffset Premiered { get; set; }

        [JsonProperty("ended")]
        public DateTimeOffset? Ended { get; set; }

        [JsonProperty("officialSite")]
        public Uri OfficialSite { get; set; }

        [JsonProperty("schedule")]
        public ScheduleDTO Schedule { get; set; }

        [JsonProperty("rating")]
        public RatingDTO Rating { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("network")]
        public NetworkDTO Network { get; set; }

        [JsonProperty("webChannel")]
        public NetworkDTO WebChannel { get; set; }

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
        public Name Name { get; set; }

        [JsonProperty("code")]
        public Code Code { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }
    }

    public partial class ExternalDTO
    {
        [JsonProperty("tvrage")]
        public long Tvrage { get; set; }

        [JsonProperty("thetvdb")]
        public long? Thetvdb { get; set; }

        [JsonProperty("imdb")]
        public string Imdb { get; set; }
    }

    public partial class ImageDTO
    {
        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [JsonProperty("original")]
        public Uri Original { get; set; }
    }

    public partial class LinkDTO
    {
        [JsonProperty("self")]
        public Self Self { get; set; }

        [JsonProperty("previousepisode")]
        public Episode Previousepisode { get; set; }

        [JsonProperty("nextepisode", NullValueHandling = NullValueHandling.Ignore)]
        public Episode Nextepisode { get; set; }
    }

    public partial class Episode
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Self
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
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
        public Uri OfficialSite { get; set; }
    }

    public partial class RatingDTO
    {
        [JsonProperty("average")]
        public double? Average { get; set; }
    }

    public partial class ScheduleDTO
    {
        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("days")]
        public List<Day> Days { get; set; }
    }

    public enum Code { Ca, De, Fr, Gb, Jp, Us };

    public enum Name { Canada, France, Germany, Japan, UnitedKingdom, UnitedStates };

    public enum Timezone { AmericaHalifax, AmericaNewYork, AsiaTokyo, EuropeBusingen, EuropeLondon, EuropeParis };

    public enum Genre { Action, Adventure, Anime, Comedy, Crime, Drama, Espionage, Family, Fantasy, History, Horror, Legal, Medical, Music, Mystery, Romance, ScienceFiction, Sports, Supernatural, Thriller, War, Western };

    public enum Language { English, Japanese };

    public enum Day { Friday, Monday, Saturday, Sunday, Thursday, Tuesday, Wednesday };

    public enum Time { Empty, The0900, The1200, The1300, The2000, The2030, The2100, The2130, The2200, The2230, The2300, The2330 };

    public enum Status { Ended, Running, ToBeDetermined };

    public enum TypeEnum { Animation, Documentary, Reality, Scripted, TalkShow };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CodeConverter.Singleton,
                NameConverter.Singleton,
                TimezoneConverter.Singleton,
                GenreConverter.Singleton,
                LanguageConverter.Singleton,
                DayConverter.Singleton,
                TimeConverter.Singleton,
                StatusConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Code) || t == typeof(Code?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CA":
                    return Code.Ca;
                case "DE":
                    return Code.De;
                case "FR":
                    return Code.Fr;
                case "GB":
                    return Code.Gb;
                case "JP":
                    return Code.Jp;
                case "US":
                    return Code.Us;
            }
            throw new Exception("Cannot unmarshal type Code");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Code)untypedValue;
            switch (value)
            {
                case Code.Ca:
                    serializer.Serialize(writer, "CA");
                    return;
                case Code.De:
                    serializer.Serialize(writer, "DE");
                    return;
                case Code.Fr:
                    serializer.Serialize(writer, "FR");
                    return;
                case Code.Gb:
                    serializer.Serialize(writer, "GB");
                    return;
                case Code.Jp:
                    serializer.Serialize(writer, "JP");
                    return;
                case Code.Us:
                    serializer.Serialize(writer, "US");
                    return;
            }
            throw new Exception("Cannot marshal type Code");
        }

        public static readonly CodeConverter Singleton = new CodeConverter();
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Canada":
                    return Name.Canada;
                case "France":
                    return Name.France;
                case "Germany":
                    return Name.Germany;
                case "Japan":
                    return Name.Japan;
                case "United Kingdom":
                    return Name.UnitedKingdom;
                case "United States":
                    return Name.UnitedStates;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            switch (value)
            {
                case Name.Canada:
                    serializer.Serialize(writer, "Canada");
                    return;
                case Name.France:
                    serializer.Serialize(writer, "France");
                    return;
                case Name.Germany:
                    serializer.Serialize(writer, "Germany");
                    return;
                case Name.Japan:
                    serializer.Serialize(writer, "Japan");
                    return;
                case Name.UnitedKingdom:
                    serializer.Serialize(writer, "United Kingdom");
                    return;
                case Name.UnitedStates:
                    serializer.Serialize(writer, "United States");
                    return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class TimezoneConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Timezone) || t == typeof(Timezone?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "America/Halifax":
                    return Timezone.AmericaHalifax;
                case "America/New_York":
                    return Timezone.AmericaNewYork;
                case "Asia/Tokyo":
                    return Timezone.AsiaTokyo;
                case "Europe/Busingen":
                    return Timezone.EuropeBusingen;
                case "Europe/London":
                    return Timezone.EuropeLondon;
                case "Europe/Paris":
                    return Timezone.EuropeParis;
            }
            throw new Exception("Cannot unmarshal type Timezone");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Timezone)untypedValue;
            switch (value)
            {
                case Timezone.AmericaHalifax:
                    serializer.Serialize(writer, "America/Halifax");
                    return;
                case Timezone.AmericaNewYork:
                    serializer.Serialize(writer, "America/New_York");
                    return;
                case Timezone.AsiaTokyo:
                    serializer.Serialize(writer, "Asia/Tokyo");
                    return;
                case Timezone.EuropeBusingen:
                    serializer.Serialize(writer, "Europe/Busingen");
                    return;
                case Timezone.EuropeLondon:
                    serializer.Serialize(writer, "Europe/London");
                    return;
                case Timezone.EuropeParis:
                    serializer.Serialize(writer, "Europe/Paris");
                    return;
            }
            throw new Exception("Cannot marshal type Timezone");
        }

        public static readonly TimezoneConverter Singleton = new TimezoneConverter();
    }

    internal class GenreConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Genre) || t == typeof(Genre?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Action":
                    return Genre.Action;
                case "Adventure":
                    return Genre.Adventure;
                case "Anime":
                    return Genre.Anime;
                case "Comedy":
                    return Genre.Comedy;
                case "Crime":
                    return Genre.Crime;
                case "Drama":
                    return Genre.Drama;
                case "Espionage":
                    return Genre.Espionage;
                case "Family":
                    return Genre.Family;
                case "Fantasy":
                    return Genre.Fantasy;
                case "History":
                    return Genre.History;
                case "Horror":
                    return Genre.Horror;
                case "Legal":
                    return Genre.Legal;
                case "Medical":
                    return Genre.Medical;
                case "Music":
                    return Genre.Music;
                case "Mystery":
                    return Genre.Mystery;
                case "Romance":
                    return Genre.Romance;
                case "Science-Fiction":
                    return Genre.ScienceFiction;
                case "Sports":
                    return Genre.Sports;
                case "Supernatural":
                    return Genre.Supernatural;
                case "Thriller":
                    return Genre.Thriller;
                case "War":
                    return Genre.War;
                case "Western":
                    return Genre.Western;
            }
            throw new Exception("Cannot unmarshal type Genre");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Genre)untypedValue;
            switch (value)
            {
                case Genre.Action:
                    serializer.Serialize(writer, "Action");
                    return;
                case Genre.Adventure:
                    serializer.Serialize(writer, "Adventure");
                    return;
                case Genre.Anime:
                    serializer.Serialize(writer, "Anime");
                    return;
                case Genre.Comedy:
                    serializer.Serialize(writer, "Comedy");
                    return;
                case Genre.Crime:
                    serializer.Serialize(writer, "Crime");
                    return;
                case Genre.Drama:
                    serializer.Serialize(writer, "Drama");
                    return;
                case Genre.Espionage:
                    serializer.Serialize(writer, "Espionage");
                    return;
                case Genre.Family:
                    serializer.Serialize(writer, "Family");
                    return;
                case Genre.Fantasy:
                    serializer.Serialize(writer, "Fantasy");
                    return;
                case Genre.History:
                    serializer.Serialize(writer, "History");
                    return;
                case Genre.Horror:
                    serializer.Serialize(writer, "Horror");
                    return;
                case Genre.Legal:
                    serializer.Serialize(writer, "Legal");
                    return;
                case Genre.Medical:
                    serializer.Serialize(writer, "Medical");
                    return;
                case Genre.Music:
                    serializer.Serialize(writer, "Music");
                    return;
                case Genre.Mystery:
                    serializer.Serialize(writer, "Mystery");
                    return;
                case Genre.Romance:
                    serializer.Serialize(writer, "Romance");
                    return;
                case Genre.ScienceFiction:
                    serializer.Serialize(writer, "Science-Fiction");
                    return;
                case Genre.Sports:
                    serializer.Serialize(writer, "Sports");
                    return;
                case Genre.Supernatural:
                    serializer.Serialize(writer, "Supernatural");
                    return;
                case Genre.Thriller:
                    serializer.Serialize(writer, "Thriller");
                    return;
                case Genre.War:
                    serializer.Serialize(writer, "War");
                    return;
                case Genre.Western:
                    serializer.Serialize(writer, "Western");
                    return;
            }
            throw new Exception("Cannot marshal type Genre");
        }

        public static readonly GenreConverter Singleton = new GenreConverter();
    }

    internal class LanguageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Language) || t == typeof(Language?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "English":
                    return Language.English;
                case "Japanese":
                    return Language.Japanese;
            }
            throw new Exception("Cannot unmarshal type Language");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Language)untypedValue;
            switch (value)
            {
                case Language.English:
                    serializer.Serialize(writer, "English");
                    return;
                case Language.Japanese:
                    serializer.Serialize(writer, "Japanese");
                    return;
            }
            throw new Exception("Cannot marshal type Language");
        }

        public static readonly LanguageConverter Singleton = new LanguageConverter();
    }

    internal class DayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Day) || t == typeof(Day?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Friday":
                    return Day.Friday;
                case "Monday":
                    return Day.Monday;
                case "Saturday":
                    return Day.Saturday;
                case "Sunday":
                    return Day.Sunday;
                case "Thursday":
                    return Day.Thursday;
                case "Tuesday":
                    return Day.Tuesday;
                case "Wednesday":
                    return Day.Wednesday;
            }
            throw new Exception("Cannot unmarshal type Day");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Day)untypedValue;
            switch (value)
            {
                case Day.Friday:
                    serializer.Serialize(writer, "Friday");
                    return;
                case Day.Monday:
                    serializer.Serialize(writer, "Monday");
                    return;
                case Day.Saturday:
                    serializer.Serialize(writer, "Saturday");
                    return;
                case Day.Sunday:
                    serializer.Serialize(writer, "Sunday");
                    return;
                case Day.Thursday:
                    serializer.Serialize(writer, "Thursday");
                    return;
                case Day.Tuesday:
                    serializer.Serialize(writer, "Tuesday");
                    return;
                case Day.Wednesday:
                    serializer.Serialize(writer, "Wednesday");
                    return;
            }
            throw new Exception("Cannot marshal type Day");
        }

        public static readonly DayConverter Singleton = new DayConverter();
    }

    internal class TimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Time) || t == typeof(Time?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Time.Empty;
                case "09:00":
                    return Time.The0900;
                case "12:00":
                    return Time.The1200;
                case "13:00":
                    return Time.The1300;
                case "20:00":
                    return Time.The2000;
                case "20:30":
                    return Time.The2030;
                case "21:00":
                    return Time.The2100;
                case "21:30":
                    return Time.The2130;
                case "22:00":
                    return Time.The2200;
                case "22:30":
                    return Time.The2230;
                case "23:00":
                    return Time.The2300;
                case "23:30":
                    return Time.The2330;
            }
            throw new Exception("Cannot unmarshal type Time");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Time)untypedValue;
            switch (value)
            {
                case Time.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Time.The0900:
                    serializer.Serialize(writer, "09:00");
                    return;
                case Time.The1200:
                    serializer.Serialize(writer, "12:00");
                    return;
                case Time.The1300:
                    serializer.Serialize(writer, "13:00");
                    return;
                case Time.The2000:
                    serializer.Serialize(writer, "20:00");
                    return;
                case Time.The2030:
                    serializer.Serialize(writer, "20:30");
                    return;
                case Time.The2100:
                    serializer.Serialize(writer, "21:00");
                    return;
                case Time.The2130:
                    serializer.Serialize(writer, "21:30");
                    return;
                case Time.The2200:
                    serializer.Serialize(writer, "22:00");
                    return;
                case Time.The2230:
                    serializer.Serialize(writer, "22:30");
                    return;
                case Time.The2300:
                    serializer.Serialize(writer, "23:00");
                    return;
                case Time.The2330:
                    serializer.Serialize(writer, "23:30");
                    return;
            }
            throw new Exception("Cannot marshal type Time");
        }

        public static readonly TimeConverter Singleton = new TimeConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Ended":
                    return Status.Ended;
                case "Running":
                    return Status.Running;
                case "To Be Determined":
                    return Status.ToBeDetermined;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Ended:
                    serializer.Serialize(writer, "Ended");
                    return;
                case Status.Running:
                    serializer.Serialize(writer, "Running");
                    return;
                case Status.ToBeDetermined:
                    serializer.Serialize(writer, "To Be Determined");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Animation":
                    return TypeEnum.Animation;
                case "Documentary":
                    return TypeEnum.Documentary;
                case "Reality":
                    return TypeEnum.Reality;
                case "Scripted":
                    return TypeEnum.Scripted;
                case "Talk Show":
                    return TypeEnum.TalkShow;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Animation:
                    serializer.Serialize(writer, "Animation");
                    return;
                case TypeEnum.Documentary:
                    serializer.Serialize(writer, "Documentary");
                    return;
                case TypeEnum.Reality:
                    serializer.Serialize(writer, "Reality");
                    return;
                case TypeEnum.Scripted:
                    serializer.Serialize(writer, "Scripted");
                    return;
                case TypeEnum.TalkShow:
                    serializer.Serialize(writer, "Talk Show");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
