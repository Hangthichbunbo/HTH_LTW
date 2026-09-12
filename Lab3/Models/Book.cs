using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace Lab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; } = string.Empty;
        public float Price { get; set; }
        public int TotalPage { get; set; }
        // Renamed from Sumary -> Summary and initialized to avoid CS8618 warnings
        public string Summary { get; set; } = string.Empty;
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/01.jpg",
                    Price = 10.99f,
                    TotalPage = 180,
                    Summary = "A novel about the American dream and the disillusionment of the Jazz Age."
                },
                new Book()
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/02.jpg",
                    Price = 12.99f,
                    TotalPage = 281,
                    Summary = "A novel about racial injustice and the loss of innocence in the Deep South."
                },
                new Book()
                {
                    Id = 3,
                    Title = "1984",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/03.jpg",
                    Price = 9.99f,
                    TotalPage = 328,
                    Summary = "A dystopian novel about a totalitarian regime that uses surveillance and propaganda to control its citizens."
                },
                new Book()
                {
                    Id = 4,
                    Title = "Pride and Prejudice",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "/images/products/04.jpg",
                    Price = 11.99f,
                    TotalPage = 279,
                    Summary = "A novel about the social norms and expectations of the British upper class in the early 19th century."
                }
            };
            return books;
        }
        // Return nullable Book? because FirstOrDefault may return null
        public Book? GetBookById(int id)
        {
            Book? book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "F. Scott Fitzgerald"},
            new SelectListItem {Value = "2", Text = "Harper Lee"},
            new SelectListItem {Value = "3", Text = "George Orwell"},
            new SelectListItem {Value = "4", Text = "Jane Austen"}
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "Fiction"},
            new SelectListItem {Value = "2", Text = "Classic"},
            new SelectListItem {Value = "3", Text = "Dystopian"},
            new SelectListItem {Value = "4", Text = "Romance"}
        };
    }
}
