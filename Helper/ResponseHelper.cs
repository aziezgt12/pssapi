namespace krodect.api.Helper
{
    public static class ResponseHelper
    {
        public class ApiResponse<T>
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public IEnumerable<T>? Results { get; set; }
        }

        public class ApiResponseWithPaging<T> : ApiResponse<T>
        {
            public int? TotalRecords { get; set; }
            public int? TotalPages { get; set; }
            public int? CurrentPage { get; set; }
            public int? PageSize { get; set; }
        }

        public static ApiResponse<T> CreateResponse<T>(T? data, int code = 200, string message = "OK")
        {
            var response = new ApiResponse<T>
            {
                Code = code,
                Message = message,
                Results = data != null ? new List<T> { data } : null
            };

            return response;
        }

        public static ApiResponse<T> CreateResponse<T>(IEnumerable<T>? data, int code = 200, string message = "OK")
        {
            var response = new ApiResponse<T>
            {
                Code = code,
                Message = message,
                Results = data
            };

            return response;
        }



        public static ApiResponseWithPaging<T> CreateResponseWithPaging<T>(IEnumerable<T>? data, int code = 200, string message = "OK", int? totalRecords = null, int? totalPages = null, int? currentPage = null, int? pageSize = null)
        {
            var response = new ApiResponseWithPaging<T>
            {
                Code = code,
                Message = message,
                Results = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = currentPage,
                PageSize = pageSize
            };

            return response;
        }
    }
}
