namespace krodect.api.Models
{
    public class BaseModel
    {
        public string? created_by { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string? updated_by { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public string? computer { get; set; }
        public Nullable<DateTime> computer_date { get; set; }
    }
}
