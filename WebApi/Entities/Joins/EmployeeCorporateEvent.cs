namespace WebApi.Entities.Joins
{
    public class EmployeeCorporateEvent
    {
        public string EmployeeID { get; set; }
        public string CorporateEventID { get; set; }
        public Employee Employee { get; set; }
        public CorporateEvent CorporateEvent { get; set; }
    }
}
