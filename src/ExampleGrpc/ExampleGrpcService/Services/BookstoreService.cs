using ExampleGrpcService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExampleGrpcService
{
    public class BookstoreService : Bookstore.BookstoreBase
    {
        private readonly ILogger<BookstoreService> _logger;
        public BookstoreService(ILogger<BookstoreService> logger)
        {
            _logger = logger;
        }

        public override async Task<Shelf> GetShelf(GetShelfRequest request,
            ServerCallContext context)
        {
            _logger.LogInformation("BookService called with Create Shelf Request: {0}", request);
            return await Task.FromResult(new Shelf
            {
                Id = request.Shelf,
                Theme = "Non Fiction"
            });
        }
    }
}
