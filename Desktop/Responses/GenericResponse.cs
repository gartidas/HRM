using System.Collections.Generic;

namespace Desktop.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
