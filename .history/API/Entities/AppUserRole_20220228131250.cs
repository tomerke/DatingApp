namespace API.Entities
{
    public class AppUserRole: IdentityUserRole
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }


    }
}