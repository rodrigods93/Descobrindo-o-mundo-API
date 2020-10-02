using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Descobrindo_o_mundo_API.Models;
using Descobrindo_o_mundo_API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Descobrindo_o_mundo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //api/[controller]
        [HttpPost]
        public ActionResult<TblUsuario> Cadastrar([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Cadastrar(usuario);
                descobrindo_mundoContext _db = new descobrindo_mundoContext();
                var user = _db.TblUsuario.Single(x => x.EmailUsuario == usuario.Email);
                return Created("api/Usuario", user);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(
                        500, new ErrorResponse("Não foi possível cadastrar o usuário.")
                    );
            }
            catch (Exception e)
            {
                return StatusCode(
                        500, new ErrorResponse("Não foi possível responder a requisição.")
                    );
            }
        }

        //api/[controller]/Login
        [HttpGet("Login")]
        public ActionResult<Usuario> Login([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(usuario.Login(usuario.Email, usuario.Senha));
                //;
            }
            catch (System.InvalidOperationException e)
            {
                return Unauthorized(
                        new ErrorResponse("Login ou senha inválidos")
                    );
            }
            catch (Exception e)
            {

                return StatusCode(
                        500, new ErrorResponse("Não foi possível responder a requisição")
                    );
            }
        }

        //api/[controller]/RecuperarSenha
        [HttpPost("RecuperarSenha")]
        public ActionResult RecuperarSenha([FromBody] Usuario usuario)
        {
            usuario.RecuperarSenha(usuario.Email);
            return Ok();
        }
    }
}
