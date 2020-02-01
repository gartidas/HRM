namespace WebApi.Entities
{
    public class Document
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeID { get; set; }
        public FormerEmployee FormerEmployee { get; set; }
        public string FormerEmployeeID { get; set; }
        public Candidate Candidate { get; set; }
        public string CandidateID { get; set; }
    }
}
