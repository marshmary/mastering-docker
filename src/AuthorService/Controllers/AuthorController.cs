using AutoMapper;
using LightNovelService.Data;
using LightNovelService.Dtos;
using LightNovelService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepo authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorRepo.GetAll();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            var author = await _authorRepo.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);

            await _authorRepo.Add(author);
            var rs = await _authorRepo.SaveChangeAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var author = await _authorRepo.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            _authorRepo.Delete(author);
            var rs = await _authorRepo.SaveChangeAsync();

            return Ok();
        }
    }
}