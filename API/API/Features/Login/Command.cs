namespace API.Features.Login
{
    public partial class GerarToken
    {
        public class Command
        {
            public string login { get; set; }

            public string password { get; set; }
        }
    }
}
