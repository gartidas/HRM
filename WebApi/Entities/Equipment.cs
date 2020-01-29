namespace WebApi.Entities
{
    public class Equipment
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
