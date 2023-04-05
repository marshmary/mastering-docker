using LightNovelService.Models;

namespace LightNovelService.Data
{
    public static class SeedData
    {
        public static Author[] authors = {
            new Author {
                Id = 1,
                JpName = "枯野瑛",
                RomajiName = "Kareno Akira",
                Twitter = "https://twitter.com/a_kareno"
            },
            new Author {
                Id = 2,
                JpName = "白石定規",
                RomajiName = "Shiraishi Jougi",
                Twitter = "https://twitter.com/jojojojougi"
            },
            new Author {
                Id = 3,
                JpName = "安里アサト",
                RomajiName = "Asato Asato",
                Twitter = "https://twitter.com/asakura_toru"
            },
            new Author {
                Id = 4,
                JpName = "時雨沢恵一",
                RomajiName = "Sigusawa Keiichi",
                Twitter = "https://twitter.com/sigsawa"
            },
        };

        public static void PrepareDatabase(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var authorRepo = serviceScope.ServiceProvider.GetService<IAuthorRepo>();

                foreach (var author in authors)
                {
                    var existedAuthor = authorRepo!.GetById(author.Id).Result;
                    if (existedAuthor == null)
                    {
                        authorRepo.Add(author);
                    }
                }

                authorRepo!.SaveChangeAsync().Wait();
            }
        }
    }
}