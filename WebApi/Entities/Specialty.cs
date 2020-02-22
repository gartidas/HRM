namespace WebApi.Entities
{
    public class Specialty
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public bool Type { get; set; }
        public WorkPlace Workplace { get; set; }
        public string WorkplaceID { get; set; }
    }
}
