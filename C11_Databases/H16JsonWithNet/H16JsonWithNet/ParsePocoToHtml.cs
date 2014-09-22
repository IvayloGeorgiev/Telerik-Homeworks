namespace H16JsonWithNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ParsePocoToHtml
    {
        public static string ParseToHtml(IEnumerable<Item> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<html><head><title>Pocos</title></head><body><section><ul>");
            int questionIndex = 1;

            foreach (var item in items)
            {
                sb.Append(string.Format("<li>Question {0}", questionIndex));
                sb.Append(string.Format("<ul><li>Title - {0}</li><li>Category - {1}</li><li>Link - <a href=\"{2}\">click</a></li></ul>", item.Title, item.Category, item.Link));
                sb.Append("</li>");
                questionIndex++;
            }

            sb.Append("</ul></section></body></html>");
            return sb.ToString();
        }
    }
}
