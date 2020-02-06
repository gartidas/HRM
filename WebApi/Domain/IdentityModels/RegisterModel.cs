﻿using System;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Domain.IdentityModels
{
    public class RegisterModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
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
        public string WorkPlaceID { get; set; }
        public Role Role { get; set; }
        public List<Document> Documentation { get; set; }
    }
    public enum Role
    {
        HR_Worker = 1,
        WorkPlaceLeader = 2,
        Employee = 3
    }
}
