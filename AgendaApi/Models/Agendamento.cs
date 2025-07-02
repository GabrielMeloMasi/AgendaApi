using System.Data;

namespace AgendaApi.Models
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
       // public int ClienteId { get; set; }
      //  public Cliente Cliente { get; set; }
       // public int ProfissionalId { get; set; }
        //public Profissional? Profissional { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim {  get; set; }
        public string? Observacoes { get; set; }
    }
}
