namespace EFCore1
{
    /// <summary>
    /// 1,Add-Migration XXXX
    /// 2,Update-Database
    /// </summary>
    public class Book
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateTime PubTime { get; set; }
        public double Price { get; set; }

    }
}
