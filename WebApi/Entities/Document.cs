namespace WebApi.Entities
{
    public class Document
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public FormerEmployee FormerEmployee { get; set; }
        public int FormerEmployeeID { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateID { get; set; }
    }
}
