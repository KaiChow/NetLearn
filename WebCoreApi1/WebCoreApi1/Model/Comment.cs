using System.Text.Json.Serialization;

namespace WebCoreApi1.Model
{
    public class Comment
    {
        public long Id { get; set; }
        [JsonIgnore]
        public Article TheArticle { get; set; }

        public string Message { get; set; }
    }
}
