namespace WebApi.Entities
{
    public class UserAccount
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
    public enum Role
    {
        SysAdmin = 3,
        HR_Worker = 2,
        WorkPlaceLeader = 1,
        Employee = 0
    }
}
