using System.Collections.Generic;

namespace Maturnik.WebUI.Shared.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
            Succeeded = true;

            Errors = new List<string>();
        }
 
        public ApiResponse()
        {
            Errors = new List<string>();
        }

        private ApiResponse(bool succeeded, IEnumerable<string> errors)
        {
            this.Succeeded = succeeded;
            this.Errors = errors;
        }


        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static ApiResponse<T> SuccessEmpty()
        {
            return new ApiResponse<T>(true, new List<string>());
        }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>(data);
        }
    }
}
