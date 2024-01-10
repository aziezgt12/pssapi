namespace krodect.api.Models.Transaksi.Marketting
{
    public class PurchaseOrder
    {
        public int po_hdr_id { get; set; }
        public string ship_date { get; set; }
        public string po_number { get; set; }
        public DateTime po_date { get; set; }
        public int contract_hdr_id { get; set; }
        public string contract_no { get; set; }
        public int factory_id { get; set; }
        public string factory_abbr { get; set; }
        public string factory_name { get; set; }
        public int export_by_factory { get; set; }
        public int customer_id { get; set; }
        public string customer_company_name { get; set; }
        public int status_id { get; set; }
        public string status_name { get; set; }
    }
}
