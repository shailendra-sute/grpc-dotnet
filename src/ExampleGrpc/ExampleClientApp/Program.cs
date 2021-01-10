using ExampleClient;
using Grpc.Net.Client;
using System;

namespace ExampleClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);

            var bookstoreClient = new Bookstore.BookstoreClient(channel);
            var shelf = bookstoreClient.GetShelf(new GetShelfRequest { Shelf = 878788787 });
            Console.WriteLine($"Shelf Response Id: {shelf.Id} and Theme: {shelf.Theme}");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
