using System;

namespace Desktop.Responses.ModelResponses.Models
{
    class Vacation
    {
        public string ID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }
    }
}
