using System.ComponentModel.DataAnnotations;

namespace LightNovelService.Dtos
{
    public class AuthorCreateDto
    {
        public string JpName { get; set; } = null!;

        public string RomajiName { get; set; } = null!;

        [Url]
        public string Twitter { get; set; } = null!;
    }
}