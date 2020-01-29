namespace WebApi.Entities.Joins
{
    public class EmployeeCorporateEvent
    {
        public int EmployeeID { get; set; }
        public int CorporateEventID { get; set; }
        public Employee Employee { get; set; }
        public CorporateEvent CorporateEvent { get; set; }
    }
}
