namespace WebApi.Entities
{
    public class Specialty
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public Type Type { get; set; }
        public WorkPlace Workplace { get; set; }
        public string WorkplaceID { get; set; }
    }
    public enum Type
    {
        Actual = 1,
        Needed = 0
    }
}
