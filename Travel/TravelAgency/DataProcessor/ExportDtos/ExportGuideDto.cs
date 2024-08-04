
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuideDto
    {
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [XmlArray("TourPackages")]
        public List<ExportTourPackageDto> TourPackages { get; set; }
    }
}
