namespace Framework.DataModel.BookDepo
{
    public class BookTitles
    {
        public enum BookTitle
        {
            TheLittlePrince
        }

        public class Book
        {
            public string Title;
            public string Isbn;
            public string Author;
            public string Langugae;
            public decimal NzPrice;
        }
    }
}
