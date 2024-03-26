namespace Domain.Master
{
    public class UserAccess : AuditableWithBaseEntity<int>
    {
        public string UserEmail  { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public UserType UserType { get; set; } 
    }
    public enum UserType
    { 
        Administrator,
        MMUser, 
        FIUser,
        ReadOnly
    }
}
