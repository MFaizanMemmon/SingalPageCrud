using System.Collections.Generic;

namespace SingalPageCrud.Models
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> ErrorList { get; set; }
        public object Data { get; set; }

    }
}
