using System.Collections.Generic;

namespace WebApi.Domain
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
