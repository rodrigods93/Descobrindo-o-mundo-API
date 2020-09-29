using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Descobrindo_o_mundo_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Descobrindo_o_mundo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            usuario.Cadastrar(usuario);
            if(usuario.Tipo == 1)
            {
                Paciente _paciente = new Paciente();
                int id = TrazIdUsuario(usuario.Email);
                _paciente.Cadastrar((Paciente)usuario,id);
            }
        }

        //api/[controller]/Login
        [HttpGet("Login")]
        public Usuario Login([FromBody] Usuario usuario)
        {
            Usuario _usuario = new Usuario();
            Usuario UsuarioRetorno = _usuario.Login(usuario.Email, usuario.Senha);
            return UsuarioRetorno;
        }

        public static int TrazIdUsuario(string p)
        {
            descobrindo_mundoContext db = new descobrindo_mundoContext();
            TblUsuario _usuario = db.TblUsuario.Single(x => x.EmailUsuario == p);
            return _usuario.IdUsuario;
        }

        /*public class Teste
        {
            private DateTime _data;
            public string data {
                get => _data.ToString();
                set => _data = DateTime.Parse(value);
            }
        }*/
    }
}
