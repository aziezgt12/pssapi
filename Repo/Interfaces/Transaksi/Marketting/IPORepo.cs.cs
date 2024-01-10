using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using krodect.api.Models;
using krodect.api.Models.Transaksi.Marketting;

namespace krodect.api.Repository.Interfaces.Transaksi.Marketting;
public interface IPORepo : IBaseRepo<PurchaseOrder>
{
    Task<IEnumerable<PurchaseOrder>> GetAll(int page, int pageSize, string? shipDate = null, string? poDate = null);
    Task<int> GetTotalCount(string? shipDate = null, string? poDate = null);
    Task<PurchaseOrder> GetBySO(string contractNumber);
    Task<IEnumerable<PurchaseOrder>> GetBySO2(int page, int pageSize);

}