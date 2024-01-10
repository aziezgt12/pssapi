using System.Data;
using Dapper;
using System.Reflection.PortableExecutable;

namespace krodect.api.Repo.Implements
{
    public class DataRepo : IDataRepo
    {
        private readonly IDbConnection _context;

        public DataRepo(IDbConnection dbConnection)
        {
            _context = dbConnection;
        }

        public async Task<Machine> GetDataByIdAsync(int id)
        {
            return await _context.QueryFirstAsync<Machine>("select * from tbl_mst_mesin where machine_id = 1");
        }
    }

}
