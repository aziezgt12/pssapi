using krodect.api.Dtos.Master;
using krodect.api.Models;
using krodect.api.Models.Master;

namespace krodect.api.Repo.Interfaces.Master
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<IEnumerable<User>> GetAllByParam(UserFilterDTO param);
    }
}
