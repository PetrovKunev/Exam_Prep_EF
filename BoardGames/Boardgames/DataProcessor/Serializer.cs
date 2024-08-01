namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
            .Where(c => c.Boardgames.Any())
            .Select(c => new CreatorDto
            {
                CreatorName = c.FirstName + " " + c.LastName,
                BoardgamesCount = c.Boardgames.Count,
                Boardgames = c.Boardgames
                    .OrderBy(bg => bg.Name)
                    .Select(bg => new BoardgameDto
                    {
                        BoardgameName = bg.Name,
                        BoardgameYearPublished = bg.YearPublished
                    })
                    .ToList()
            })
            .ToArray()
            .OrderByDescending(c => c.BoardgamesCount)
            .ThenBy(c => c.CreatorName)
            .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CreatorDto[]), new XmlRootAttribute("Creators"));
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty); // Removing namespaces

            using var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, creators, xmlNamespaces);
            return stringWriter.ToString();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
           
            {
                var sellers = context.Sellers
                    .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                    .Select(s => new
                    {
                        s.Name,
                        s.Website,
                        Boardgames = s.BoardgamesSellers
                            .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                            .Select(bs => bs.Boardgame)
                            .OrderByDescending(bg => bg.Rating)
                            .ThenBy(bg => bg.Name)
                            .Select(bg => new
                            {
                                bg.Name,
                                bg.Rating,
                                Mechanics = bg.Mechanics,
                                Category = bg.CategoryType.ToString()
                            })
                            .ToArray()
                    })
                    .ToArray()
                    .OrderByDescending(s => s.Boardgames.Length)
                    .ThenBy(s => s.Name)
                    .Take(5)
                    .ToArray();

                var result = JsonConvert.SerializeObject(sellers, Formatting.Indented);

                return result;
            }
        }
    }
}