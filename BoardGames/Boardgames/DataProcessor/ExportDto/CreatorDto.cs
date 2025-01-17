﻿
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class CreatorDto
    {
        [XmlElement("CreatorName")]
        public string CreatorName { get; set; } = null!;

        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [XmlArray("Boardgames")]
        public List<BoardgameDto> Boardgames { get; set; } = new List<BoardgameDto>();
    }
}
