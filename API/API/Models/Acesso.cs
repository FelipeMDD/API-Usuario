namespace API.Models
{
    public class Acesso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool Role { get; set; }
    }
}
