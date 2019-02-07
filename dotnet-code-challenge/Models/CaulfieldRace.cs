using System.Xml.Serialization;
using System.Collections.Generic;

namespace dotnet_code_challenge.Models
{
    [XmlRoot(ElementName = "meeting")]
    public class Meeting
    {
        [XmlElement(ElementName = "Meetingid")]
        public string Id { get; set; }

        [XmlElement(ElementName = "MeetingType")]
        public string Type { get; set; }

        [XmlElement(ElementName = "track")]
        public Track Track { get; set; }

        [XmlArray("races")]
        [XmlArrayItem("race")]
        public List<Race> Races { get; set; }
    }

    [XmlRoot(ElementName = "track")]
    public class Track
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }      
    }

    [XmlRoot(ElementName = "race")]
    public class Race
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlArray("horses")]
        [XmlArrayItem("horse")]
        public List<Horse> Horses { get; set; }

        [XmlArray("prices")]
        [XmlArrayItem("price")]
        public List<Price> Prices { get; set; }
    }

    [XmlRoot(ElementName = "horse")]
    public class Horse
    {
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public string _Number { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "Price")]
        public string Price { get; set; }
    }

    [XmlRoot(ElementName = "price")]
    public class Price
    {
        [XmlArray("horses")]
        [XmlArrayItem("horse")]
        public List<Horse> Horses { get; set; }

        [XmlElement(ElementName = "priceType")]
        public string Type { get; set; }
    }
}
