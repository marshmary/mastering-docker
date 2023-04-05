using AuthorService;
using AutoMapper;
using LightNovelService.Dtos;
using LightNovelService.Models;

namespace LightNovelService.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreateDto, Author>();

            CreateMap<Author, AuthorGrpc>();
        }
    }
}