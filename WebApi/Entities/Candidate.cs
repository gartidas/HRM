using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Candidate
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Vzdelanie { get; set; }
        public string Specialty { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double RequestedSalary { get; set; }
        public int Evaluation { get; set; }
        public int MyProperty { get; set; }
        public Status Status { get; set; }
        public string AdditionalInfo { get; set; }
        public List<Document> Documentation { get; set; }
    }
    public enum Status
    {
        Received = 0,
        InvitedToApply = 1,
        InProcess = 2,
        NotSelected = 3,
        Hired = 4,
        PositionWithdrawn = 5
    }
}
