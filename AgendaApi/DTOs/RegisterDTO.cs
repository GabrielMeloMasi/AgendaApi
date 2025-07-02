namespace AgendaApi.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Cliente" ou "Profissional"
        public string Cpf { get; set; }
        public string NomeCompleto { get; set;  }
    }
}
