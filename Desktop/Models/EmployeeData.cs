﻿using System;

namespace Desktop.Models
{
    class EmployeeData
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthCertificateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Specialty { get; set; }
        public string AddressOfPermanentResidence { get; set; }
        public string Citizenship { get; set; }
        public bool Gender { get; set; }
        public double Salary { get; set; }
        public int NumberOfVacationDays { get; set; }
        public string IdCardNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string HealthInsuranceCompany { get; set; }
        public int NumberOfChildren { get; set; }
        public FamilyStatus FamilyStatus { get; set; }
        public string NameOfTheBank { get; set; }
        public string AccountNumber { get; set; }
        public Role Role { get; set; }
        public bool IsAssignedWorkplaceLeader { get; set; }
    }

    public enum FamilyStatus
    {
        Single = 0,
        Married = 1,
        Divorced = 2,
        Widowed = 3
    }
}
