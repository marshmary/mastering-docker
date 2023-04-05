using LightNovelService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IGrpcAuthorClient _grpcAuthorClient;

        public AuthorController(IGrpcAuthorClient grpcAuthorClient)
        {
            _grpcAuthorClient = grpcAuthorClient;
        }

        [HttpGet("{id}")]
        public ActionResult GetAuthorById(int id)
        {
            var author = _grpcAuthorClient.GetAuthor(id);
            return Ok(author);
        }
    }
}