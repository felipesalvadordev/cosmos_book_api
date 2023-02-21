using CosmosBookAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosBookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Book> _books;

        public BookService(
            MongoClient mongoClient,
            IConfiguration configuration)
        {
            _mongoClient = mongoClient;
            _database = _mongoClient.GetDatabase(configuration["DatabaseName"]);
            _books = _database.GetCollection<Book>(configuration["CollectionName"]);
        }

        public async Task CreateBook(Book bookIn)
        {
            await _books.InsertOneAsync(bookIn);
        }

        public async Task<Book> GetBook(string id)
        {
            var book = await _books.FindAsync(book => book.Id == id);
            return book.FirstOrDefault();
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await _books.FindAsync(book => true);
            return books.ToList();
        }
    }
}
