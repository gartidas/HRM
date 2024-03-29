﻿using System.Collections.Generic;

namespace WebApi.Entities
{
    public class WorkPlace
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public string Location { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Specialty> Specialties { get; set; }
        public WorkPlaceLeader WorkPlaceLeader { get; set; }
        public string WorkPlaceLeaderID { get; set; }
    }
}
