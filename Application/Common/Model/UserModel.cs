namespace Application.Common.Model
{
    public class UserModel
    {
        public string UserId { get; set; }  
        public string UserName { get; set; }    
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Editor { get; set; }
        public DateTime Modified { get; set; }
    }
}
