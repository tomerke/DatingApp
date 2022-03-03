namespace API.Entities
{
    public class AppUserRole: IdentityUser
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }


    }
}