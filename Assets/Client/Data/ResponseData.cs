/*
 * These classes were made with help of http://json2csharp.com/
 * and sample data sets from the API
 */

using System;
using System.Collections.Generic;
// ReSharper disable UnusedMember.Global

namespace Client.Data
{
    [Serializable]
    public class Meta
    {
        public string Offset;
        public string Limit;
        public string Mediaobject;
        public string Availability;
        public int Count;
        public int Program;
        public int Clip;
    }

    [Serializable]
    public class Description
    {
        public string Fi;
        public string Sv;
    }

    [Serializable]
    public class Video
    {
        public List<object> Language;
        public List<object> Format;
        public string Type;
    }

    [Serializable]
    public class Creator
    {
        public string Name;
        public string Type;
    }

    [Serializable]
    public class Title
    {
        public string Fi;
        public string En;
        public string Sv;
        public string Und;

        public string GetFinalTitle()
        {
            if (!string.IsNullOrEmpty(Fi))
            {
                return Fi;
            }
            return Und;
        }
    }

    [Serializable]
    public class Broader
    {
        public string Id;
    }

    [Serializable]
    public class Subject
    {
        public string Id;
        public Title Title;
        public string InScheme;
        public string Type;
        public List<Notation> Notation;
        public Broader Broader;
        public string Key;
    }

    [Serializable]
    public class PartOfSeason
    {
        public Description Description;
        public int SeasonNumber;
        public List<Creator> Creator;
        public PartOfSeries PartOfSeries;
        public DateTime IndexDataModified;
        public string Type;
        public string ProductionId;
        public Title Title;
        public List<object> CountryOfOrigin;
        public string Id;
        public List<Subject> Subject;
    }

    [Serializable]
    public class CoverImage
    {
        public string Id;
        public bool Available;
        public string Type;
        public int Version;
    }

    [Serializable]
    public class Notation
    {
        public string Value;
        public string ValueType;
    }

    [Serializable]
    public class Season
    {
        public Description Description;
        public int SeasonNumber;
        public List<object> Creator;
        public PartOfSeries PartOfSeries;
        public DateTime IndexDataModified;
        public string Type;
        public string ProductionId;
        public Title Title;
        public List<object> CountryOfOrigin;
        public string Id;
        public List<Subject> Subject;
    }

    [Serializable]
    public class Image
    {
        public string Id;
        public bool Available;
        public string Type;
        public int Version;
    }

    [Serializable]
    public class PartOfProduct
    {
        public Description Description;
        public List<object> Creator;
        public DateTime IndexDataModified;
        public Title Title;
        public List<object> CountryOfOrigin;
        public List<object> Interactions;
        public string Id;
        public Image Image;
        public List<Subject> Subject;
    }

    [Serializable]
    public class Interaction
    {
        public Title Title;
        public string Type;
        public string Url;
    }

    [Serializable]
    public class AvailabilityDescription
    {
        public string Fi;
        public string Sv;
    }

    [Serializable]
    public class PromotionTitle
    {
        public string Fi;
        public string Sv;
    }

    [Serializable]
    public class PartOfSeries
    {
        public Description Description;
        public List<object> Creator;
        public string Type;
        public Title Title;
        public CoverImage CoverImage;
        public List<Season> Season;
        public List<object> CountryOfOrigin;
        public string Id;
        public Image Image;
        public PartOfProduct PartOfProduct;
        public List<Subject> Subject;
        public List<Interaction> Interactions;
        public List<string> AlternativeId;
        public AvailabilityDescription AvailabilityDescription;
        public PromotionTitle PromotionTitle;
    }

    [Serializable]
    public class ContentRating
    {
        public Title Title;
        public List<object> Reason;
        public int? AgeRestriction;
        public string RatingSystem;
        public string Type;
    }

    [Serializable]
    public class ItemTitle
    {
        public string Fi;
        public string Sv;
    }

    [Serializable]
    public class Format
    {
        public string InScheme;
        public string Type;
        public string Key;
    }

    [Serializable]
    public class Audio
    {
        public List<string> Language;
        public List<Format> Format;
        public string Type;
    }

    [Serializable]
    public class OriginalTitle
    {
        public string Und;
    }

    [Serializable]
    public class Tags
    {
        public bool Catalog;
    }

    [Serializable]
    public class Service
    {
        public string Id;
    }

    [Serializable]
    public class Publisher
    {
        public string Id;
    }

    [Serializable]
    public class ContentProtection
    {
        public string Id;
        public string Type;
    }

    [Serializable]
    public class Media
    {
        public string Id;
        public string Duration;
        public List<ContentProtection> ContentProtection;
        public bool Available;
        public string Type;
        public bool Downloadable;
        public int Version;
    }

    [Serializable]
    public class PublicationEvent
    {
        public Tags Tags;
        public Service Service;
        public List<Publisher> Publisher;
        public DateTime StartTime;
        public string TemporalStatus;
        public DateTime EndTime;
        public string Type;
        public string Duration;
        public string Region;
        public string Id;
        public int Version;
        public Media Media;
    }

    [Serializable]
    public class LongDescription
    {
        public string Fi;
        public string Sv;
    }

    [Serializable]
    public class Datum
    {
        public Description Description;
        public Video Video;
        public string TypeMedia;
        public List<Creator> Creator;
        public PartOfSeason PartOfSeason;
        public PartOfSeries PartOfSeries;
        public DateTime IndexDataModified;
        public List<string> AlternativeId;
        public string Type;
        public string Duration;
        public string ProductionId;
        public ContentRating ContentRating;
        public Title Title;
        public ItemTitle ItemTitle;
        public List<string> CountryOfOrigin;
        public string Id;
        public string TypeCreative;
        public Image Image;
        public List<Audio> Audio;
        public PartOfProduct PartOfProduct;
        public OriginalTitle OriginalTitle;
        public List<PublicationEvent> PublicationEvent;
        public string Collection;
        public List<Subject> Subject;
        public List<object> Subtitling;
        public int? EpisodeNumber;
        public LongDescription LongDescription;
        public List<Interaction> Interactions;
        public PromotionTitle PromotionTitle;
    }

    [Serializable]
    public class RootObject
    {
        public string ApiVersion;
        public Meta Meta;
        public List<Datum> Data;
    }
}