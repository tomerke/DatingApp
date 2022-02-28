namespace API.Entities
{
    public class AppUserRole: Identity
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }


    }
}