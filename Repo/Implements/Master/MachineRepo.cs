using Dapper;
using System.Data;
using krodect.api.Models;
using krodect.api.Repo.Interfaces.Master;

namespace krodect.api.Repo.Implements.Master
{
    public class MachineRepo : IMachineRepo
    {
        private readonly IDbConnection _context;
        public MachineRepo(IDbConnection dbConnection)
        {
            _context = dbConnection;
        }



        public Task Add(Machine entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Machine>> GetAll()
        {
            string sql = "select * from mar_vw_trn_purchase_order_factory limit 100";

            return await _context.QueryAsync<Machine>(sql);
        }

        public Task<Machine> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Machine entity)
        {
            throw new NotImplementedException();
        }
    }
}







