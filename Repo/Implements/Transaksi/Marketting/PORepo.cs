using System.Data;
using Dapper;
using System.Reflection.PortableExecutable;
using krodect.api.Models.Transaksi.Marketting;
using krodect.api.Repository.Interfaces.Transaksi.Marketting;

namespace krodect.api.Repo.Implements.Transaksi.Marketting
{
    public class PORepo : IPORepo
    {
        private readonly IDbConnection _context;

        public PORepo(IDbConnection dbConnection)
        {
            _context = dbConnection;
        }

        

        public async Task<IEnumerable<PurchaseOrder>> GetAll(int page, int pageSize, string? shipDate = null, string? poDate = null)
        {
            var offset = (page - 1) * pageSize;

            string sql = "SELECT * FROM mar_vw_trn_purchase_order_factory";

            var whereConditions = new List<string>();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(shipDate))
            {
                whereConditions.Add("ship_date = @ShipDate");
                parameters.Add("ShipDate", DateTime.Parse(shipDate)); 
            }

            if (!string.IsNullOrWhiteSpace(poDate))
            {
                whereConditions.Add("po_date = @PoDate");
                parameters.Add("PoDate", DateTime.Parse(poDate)); 
            }

            if (whereConditions.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", whereConditions);
            }

            sql += " ORDER BY po_hdr_id LIMIT @PageSize OFFSET @Offset";

            parameters.Add("PageSize", pageSize);
            parameters.Add("Offset", offset);

            return await _context.QueryAsync<PurchaseOrder>(sql, parameters);
        }


        public async Task<int> GetTotalCount(string? shipDate = null, string? poDate = null)
        {
            const string query = "SELECT COUNT(*) FROM mar_vw_trn_purchase_order_factory";

            var whereConditions = new List<string>();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(shipDate))
            {
                whereConditions.Add("ship_date = @ShipDate");
                parameters.Add("ShipDate", DateTime.Parse(shipDate)); 
            }

            if (!string.IsNullOrWhiteSpace(poDate))
            {
                whereConditions.Add("po_date = @PoDate");
                parameters.Add("PoDate", DateTime.Parse(poDate)); 
            }

            if (whereConditions.Count > 0)
            {
                return await _context.QueryFirstAsync<int>(query + " WHERE " + string.Join(" AND ", whereConditions), parameters);
            }

            return await _context.QueryFirstAsync<int>(query);
        }


        public async Task<PurchaseOrder> GetBySO(string contractNumber)
        {
            return await _context.QueryFirstAsync<PurchaseOrder>($"SELECT * FROM mar_vw_trn_purchase_order_factory WHERE contract_no = '{contractNumber}'");
        }




        public async Task<PurchaseOrder> GetDataByIdAsync(int id)
        {
            return await _context.QueryFirstAsync<PurchaseOrder>("select * from tbl_mst_mesin where machine_id = 1");
        }


        public async Task<IEnumerable<PurchaseOrder>> GetBySO2(int page, int pageSize)
        {

            var offset = (page - 1) * pageSize;

            var result = await _context.QueryAsync<PurchaseOrder>($"select * from mar_vw_trn_purchase_order_factory LIMIT {pageSize} OFFSET {offset}");

            return result;
        }

        #region Not Use

        public Task Update(PurchaseOrder entity)
        {
            throw new NotImplementedException();
        }
        public Task Add(PurchaseOrder entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task<PurchaseOrder> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            throw new NotImplementedException();
        }

        



        #endregion
    }


}
