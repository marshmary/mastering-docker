using AuthorService;
using AutoMapper;
using Grpc.Net.Client;
using LightNovelService.Models;

namespace LightNovelService.Services
{
    public interface IGrpcAuthorClient
    {
        Author? GetAuthor(int id);
    }

    public class GrpcAuthorClient : IGrpcAuthorClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<GrpcAuthorClient> _logger;
        private readonly GrpcAuthors.GrpcAuthorsClient _client;

        public GrpcAuthorClient(IConfiguration configuration, IMapper mapper, ILogger<GrpcAuthorClient> logger)
        {
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;

            // Get artistsServer url from appsetting
            string serverUrl = configuration.GetValue<string>("Grpc:Author");

            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            // Create connection to artistsServer
            var channel = GrpcChannel.ForAddress(serverUrl,
                new GrpcChannelOptions { HttpHandler = httpHandler });
            _client = new GrpcAuthors.GrpcAuthorsClient(channel);
        }

        public Author? GetAuthor(int id)
        {
            _logger.LogInformation($"Getting author from AuthorService with authorId: {id}");
            // Call artistsServer
            var author = _client.GetAuthor(new GetAuthorRequest { Id = id });
            return _mapper.Map<Author>(author);
        }

    }
}