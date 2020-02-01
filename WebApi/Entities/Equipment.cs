namespace WebApi.Entities
{
    public class Equipment
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeID { get; set; }
    }
}
