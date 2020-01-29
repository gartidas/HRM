using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class FormerEmployee
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthCertificateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Specialty { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressOfPermanentResidence { get; set; }
        public string Citizenship { get; set; }
        public Gender Gender { get; set; }
        public double Salary { get; set; }
        public int NumberOfVacationDays { get; set; }
        public int NumberOfWorkedOffDays { get; set; }
        public List<Document> Documentation { get; set; }
        public string TerminationReason { get; set; }
        public DateTime TerminationDate { get; set; }
        public int TerminatedByID { get; set; }

    }
}
