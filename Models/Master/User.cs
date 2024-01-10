namespace krodect.api.Models.Master
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public int group_id { get; set; }
        public int telegram_id { get; set; }
        public string email { get; set; }
        public bool is_active { get; set; }
        public long wa_number { get; set; }
        public bool send_reminder { get; set; }
        public int regnofactory { get; set; }
    }
}
