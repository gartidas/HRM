using System;
using System.Collections.Generic;
using WebApi.Entities.Joins;

namespace WebApi.Entities
{
    public class Employee
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
        public WorkPlace WorkPlace { get; set; }
        public int WorkPlaceID { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<Document> Documentation { get; set; }
        public UserAccount Account { get; set; }
        public List<Vacation> Vacations { get; set; }
        public List<EmployeeCorporateEvent> EmployeeCorporateEvent { get; set; }
        public List<Equipment> Equipment { get; set; }
        public EquipmentStatus EquipmentStatus { get; set; }
    }
    public enum Gender
    {
        Male = 1,
        Female = 0
    }
    public enum EquipmentStatus
    {
        Received = 0,
        RequestedReturn = 1,
        Returned = 2
    }
}
