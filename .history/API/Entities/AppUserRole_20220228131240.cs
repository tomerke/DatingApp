namespace API.Entities
{
    public class AppUserRole: Ide
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }


    }
}