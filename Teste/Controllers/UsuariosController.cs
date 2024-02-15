using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Teste.Data.DbContexts;
using Teste.Entities;
using Teste.Request;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppMySqlDbContext _mySqlDbContext;
        public UsuariosController(AppMySqlDbContext mySqlContext) => _mySqlDbContext = mySqlContext;
        
        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm]PostUsuarioRequest request)
        {
            try
            {
                var memoryStream = new MemoryStream();
                request.Imagem.CopyTo(memoryStream);

                var usuario = new Usuarios()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Telefone = request.Telefone,
                    Senha = request.Senha,
                    Imagem = memoryStream.ToArray()
                };
               
                _mySqlDbContext.Usuarios.Add(usuario);
                await _mySqlDbContext.SaveChangesAsync();
                
                return StatusCode(StatusCodes.Status201Created, "Usuario registrado com sucesso.");
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao registrar usuario. " + ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromForm]Usuarios request)
        {
            try
            {
                _mySqlDbContext.Entry(request).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _mySqlDbContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Usuario atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar usuario. " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuarios),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var usuario = await _mySqlDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
                if(usuario != null)
                    return Ok(usuario);

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pesquisar usuario. " + ex.Message);
            }
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(List<Usuarios>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _mySqlDbContext.Usuarios.ToListAsync();
                if(usuarios.Any())
                    return Ok(usuarios);

                return NotFound("Nenhum usuario cadastrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar usuario. " + ex.Message);
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromForm] PostUsuarioLoginRequest request)
        {
            try
            {
                var usuario = await _mySqlDbContext.Usuarios.FirstOrDefaultAsync(x => x.Email == request.Email);
                if (usuario == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Usuario não existe.");

                if(usuario.Senha != request.Senha)
                    return StatusCode(StatusCodes.Status400BadRequest, "Senha incorreta.");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tantar fazer login. " + ex.Message);
            }
        }
    }
}
