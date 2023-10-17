namespace Group3FinalProject.Models
{
    public class GiveRoleOutput
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
