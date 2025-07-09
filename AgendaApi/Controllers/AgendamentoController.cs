using AgendaApi.Models;
using AgendaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : Controller
    {
        private readonly IUnitOfWork _unityOfWork;

        public AgendamentoController(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Agendamento>> GetAllAgendamentos()
        {
            var agendamentos = _unityOfWork.AgendamentoRepository.GetAll();
            return Ok(agendamentos);
        }

        [HttpGet("{id:int}", Name = "AgendamentoById")]
        public ActionResult<Agendamento> GetAgendamentoById(int id)
        {
            var agendamento = _unityOfWork.AgendamentoRepository.Get(a => a.AgendamentoId == id);
            if (agendamento == null)
            {
                return NotFound();
            }
            return Ok(agendamento);
        }

        [HttpGet("{profissionalId}/{clientId}", Name = "GetAgendamentoPorProfissionalECliente")]
        public ActionResult<Agendamento> GetAgendamentoPorProfissionalECliente(string profissionalId, string clientId)
        {
            var agendamento = _unityOfWork.AgendamentoRepository.Get(a => a.ProfissionalUserId == profissionalId && a.ClienteUserId == clientId);
            if (agendamento == null)
            {
                return NotFound();
            }
            return Ok(agendamento);
        }

        [HttpGet("{clientId}", Name = "GetAgendamentoPorClientId")]
        public ActionResult<Agendamento> GetAgendamentoPorClientId(string clientId)
        {
            var agendamento = _unityOfWork.AgendamentoRepository.GetByClientId(clientId);
            if (agendamento == null)
            {
                return NotFound();
            }
            return Ok(agendamento);
        }


        [HttpPost]
        public ActionResult<Agendamento> Post(Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest("Dados invalidos");
            }

            var conflito = _unityOfWork.AgendamentoRepository.GetAll().Any(a =>
            a.ProfissionalUserId == agendamento.ProfissionalUserId &&
            (
            (agendamento.DataHoraInicio >= a.DataHoraInicio && agendamento.DataHoraInicio < a.DataHoraFim) ||
            (agendamento.DataHoraFim > a.DataHoraInicio && agendamento.DataHoraFim <= a.DataHoraFim) ||
            (agendamento.DataHoraInicio <= a.DataHoraInicio && agendamento.DataHoraFim >= a.DataHoraFim)
            )
            );

            if (conflito)
            {
                return Conflict("Já existe um agendamento para esse profissional nesse horário.");
            }


            var newAgendamento = _unityOfWork.AgendamentoRepository.Create(agendamento);
            _unityOfWork.commit();
            return new CreatedAtRouteResult("AgendamentoById", new { id = newAgendamento.AgendamentoId }, newAgendamento);
        }
    }
}
