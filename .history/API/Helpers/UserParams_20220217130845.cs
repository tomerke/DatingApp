namespace API.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get ; set; } = 1;
        public int _pageSize { get; set; } = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string CurrentUserName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public int MinAge { get; set; } = 18;
        public string Name { get; set; }
        
        


    }
}