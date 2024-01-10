namespace krodect.api.Dtos.OTP
{
    public class SendDocumentDTO
    {
        public string caption { get; set; }
        public string media_pic_public { get; set; }
        public List<WaNumber> no_hp_items { get; set; }
    }
}
