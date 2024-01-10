using Dapper;
using System.Data;
using krodect.api.Dtos.Master;
using krodect.api.Models;
using krodect.api.Models.Master;
using krodect.api.Repo.Interfaces;
using krodect.api.Repo.Interfaces.Master;

namespace krodect.api.Repo.Implements.Master
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbConnection _context;
        private readonly string sqlTemplate = "SELECT * FROM users";
        private readonly ILogger<UserRepo> _logger;
        private readonly LoggingService _loggingService;
        public UserRepo(IDbConnection dbConnection, ILogger<UserRepo> logger, LoggingService loggingService)
        {
            _context = dbConnection;
            _logger = logger;
            _loggingService = loggingService;

        }

        private string WhereQuery(string condition)
        {
            return $"{sqlTemplate} WHERE {condition}";
        }

        public async Task<IEnumerable<User>> GetAll()
        {

            return await _context.QueryAsync<User>(sqlTemplate);
        }



        public async Task<IEnumerable<User>> GetAllByParam(UserFilterDTO param)
        {
            try
            {
                var conditions = new List<string>();
                var parameters = new DynamicParameters();

                conditions.Add("1 = 1");

                if (param.send_reminder != null)
                {
                    conditions.Add("send_reminder = @send_reminder");
                    parameters.Add("send_reminder", param.send_reminder);
                }

                if (param.is_active != null)
                {
                    conditions.Add("is_active = @is_active");
                    parameters.Add("is_active", param.is_active);
                }

                if (!param.wa_null)
                {
                    conditions.Add("wa_number IS NOT NULL");
                }

                string sql = $"{sqlTemplate} WHERE {string.Join(" AND ", conditions)}";
                //_logger.LogInformation("Ini adalah contoh pesan informasi log dari controller.");
                //_logger.LogError("Ini adalah contoh pesan informasi log dari controller.");
                //_loggingService.Info();

                return await _context.QueryAsync<User>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw; // Melempar kembali exception untuk penanganan lebih lanjut
            }
        }



        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }

    }
}







