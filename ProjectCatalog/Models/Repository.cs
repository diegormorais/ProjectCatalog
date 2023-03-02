namespace ProjectCatalog.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string Owner { get; set; }
    }
}
