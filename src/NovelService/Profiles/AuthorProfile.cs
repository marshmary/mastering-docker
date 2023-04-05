using AuthorService;
using AutoMapper;
using LightNovelService.Models;

namespace LightNovelService.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorGrpc, Author>();
        }
    }
}