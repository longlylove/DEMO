using System;

namespace Framework.DataModel.BookDepo
{
    public class Books
    {
        public static BookTitles.Book GetBook(BookTitles.BookTitle book)
        {
            switch (book)
            {
                    case BookTitles.BookTitle.TheLittlePrince:
                    return new BookTitles.Book
                    {
                        Author = "Antoine de Saint-Exupery",
                        Isbn = "0123456789ISBN",
                        Langugae = "English",
                        NzPrice = (decimal)17.54,
                        Title = "The Little Prince"
                    };
                    
                default:
                    throw new Exception("Book is not found!");
            }
        }
    }
}
