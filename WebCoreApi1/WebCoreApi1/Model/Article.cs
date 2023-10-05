using System.Text.Json.Serialization;

namespace WebCoreApi1.Model
{
    public class Article
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
