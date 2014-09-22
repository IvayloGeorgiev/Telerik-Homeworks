namespace T02Articles
{
    using System;

    public class Article : IComparable<Article>
    {
        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Article obj)
        {
            return (int)(this.Price - obj.Price);
        }
    }
}
