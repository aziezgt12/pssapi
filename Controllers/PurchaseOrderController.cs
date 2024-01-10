using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using krodect.api.Models;
using krodect.api.Repo.Interfaces.Master;
using krodect.api.Repository.Interfaces.Transaksi.Marketting;
using Microsoft.AspNetCore.Authorization;
using krodect.api.Helper;
using krodect.api.Dtos.Master;

namespace krodect.api.Controllers
{
    [Route("api/purchaseOrder")]
    [ApiController]
    //[Authorize]
    public class PurchaseOrder : ControllerBase
    {
        private readonly IPORepo _poRepo;

        public PurchaseOrder(IPORepo poRepo)
        {
            _poRepo = poRepo;
        }

        [HttpGet("getAllByParam", Name = "getAllByParam")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10, string? shipDate = null, string? poDate = null)
        {
            try
            {
                var totalRecords = await _poRepo.GetTotalCount(shipDate, poDate);

                if (totalRecords == 0)
                {
                    return NotFound(ResponseHelper.CreateResponse<object>(null, code: 404, message: "NOT FOUND"));
                }

                var data = await _poRepo.GetAll(page, pageSize, shipDate, poDate);

                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                var result = ResponseHelper.CreateResponseWithPaging(data, code: 200, message: "OK", totalRecords: totalRecords, totalPages: totalPages, currentPage: page, pageSize: pageSize);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.CreateResponse<object>(null, code:500, message: ex.Message));
            }
        }

        [HttpGet("getBySo", Name = "getBySo")]
        public async Task<IActionResult> GetBySo(string contractNumber)
        {
            try
            {

                var data = await _poRepo.GetBySO(contractNumber);

                var result = ResponseHelper.CreateResponse(data, code: 200, message: "OK");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.CreateResponse<object>(null, code: 500, message: ex.Message));
            }
        }


        [HttpPost("getBySo2", Name = "getBySo2")]
        public async Task<IActionResult> GetBySo2(int page = 1, int pageSize = 10)
        {
            try
            {

                var data = await _poRepo.GetBySO2(page, pageSize);

                var result = ResponseHelper.CreateResponse(data, code: 200, message: "OK");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHelper.CreateResponse<object>(null, code: 500, message: ex.Message));
            }
        }
    }
}
