using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AgendaApi.Models
{
    public class Agendamento
    {
        [Key]
        public int AgendamentoId { get; set; }
        [Required]
        public string? TituloAgendamento { get; set; }
        [Required]
        public string ClienteUserId { get; set; }
        [Required]
        public string ProfissionalUserId { get; set; }
        [Required]
        public DateTime DataHoraInicio { get; set; }
        [Required]
        public DateTime DataHoraFim {  get; set; }
        public string? Observacoes { get; set; }
    }
}
