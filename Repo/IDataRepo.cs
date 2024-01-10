using System.Reflection.PortableExecutable;

namespace krodect.api.Repo
{
    public interface IDataRepo
    {
        Task<Machine> GetDataByIdAsync(int id);
    }
}

