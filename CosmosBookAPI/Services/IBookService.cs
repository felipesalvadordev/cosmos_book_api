using CosmosBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosBookAPI.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Get all books from the Books collection
        /// </summary>
        /// <returns></returns>
        Task<List<Book>> GetBooks();

        /// <summary>
        /// Get a book by its id from the Books collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetBook(string id);
        /// <summary>
        /// Insert a book into the Books collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task CreateBook(Book book);
    }
}
