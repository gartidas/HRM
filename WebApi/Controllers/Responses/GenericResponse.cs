using System.Collections.Generic;

namespace WebApi.Controllers.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
