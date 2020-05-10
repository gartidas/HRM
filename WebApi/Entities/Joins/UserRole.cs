namespace WebApi.Entities.Joins
{
    public class UserRole
    {
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
