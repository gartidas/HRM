using Microsoft.AspNetCore.Identity;
using System;

namespace WebApi.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthCertificateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Specialty { get; set; }
        public string AddressOfPermanentResidence { get; set; }
        public string Citizenship { get; set; }
        public bool Gender { get; set; }
        public double Salary { get; set; }
        public int NumberOfVacationDays { get; set; }
        public int NumberOfWorkedOffDays { get; set; }
        public EquipmentStatus EquipmentStatus { get; set; }
    }
    public enum EquipmentStatus
    {
        Received = 0,
        RequestedReturn = 1,
        Returned = 2
    }
}
