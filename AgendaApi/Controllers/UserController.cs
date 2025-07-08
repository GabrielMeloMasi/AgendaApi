using AgendaApi.DTOs;
using AgendaApi.Models;
using AgendaApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
           var users = _unityOfWork.UserRepository.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users); 
            return Ok(usersDto);
        }

        [HttpGet]
        [Route("ProfissionalUsers")]
        public ActionResult<IEnumerable<User>> GetAllUsersProfissional()
        {
            var users = _unityOfWork.UserRepository.GetProfissionalUsers();
            if (users == null)
            {
                return NotFound();
            }
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{especialidade}", Name = "ProfissionalByEspecialidade")]
        public ActionResult<IEnumerable<User>> GetUserByEspecialidade(string especialidade)
        {
            var users = _unityOfWork.UserRepository.GetProfissionalByEspecialidade(especialidade);
            if (users == null)
            {
                return NotFound("Profissional não encontrada.");
            }
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(usersDto);
        }

    }
}
