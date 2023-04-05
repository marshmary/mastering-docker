using AutoMapper;
using Grpc.Core;
using LightNovelService.Data;

namespace AuthorService.Services
{
    public class GrpcAuthorServer : GrpcAuthors.GrpcAuthorsBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepo _authorRepo;

        public GrpcAuthorServer(IMapper mapper, IAuthorRepo authorRepo)
        {
            _mapper = mapper;
            _authorRepo = authorRepo;
        }

        public override async Task<AuthorGrpc> GetAuthor(GetAuthorRequest request, ServerCallContext context)
        {
            var author = await _authorRepo.GetById(request.Id);
            return _mapper.Map<AuthorGrpc>(author);
        }
    }
}