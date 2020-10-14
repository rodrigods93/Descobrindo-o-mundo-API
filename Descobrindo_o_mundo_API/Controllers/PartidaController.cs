using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Descobrindo_o_mundo_API;
using Descobrindo_o_mundo_API.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Descobrindo_o_mundo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        //api/[controller]/{nickname}
        [HttpGet("{nickname}")]
        public ActionResult<List<TblPartida>> Listar(string nickname)
        {
            try
            {
                descobrindo_mundoContext _db = new descobrindo_mundoContext();
                var listaTblPartida = _db.TblPartida.Where(x => x.IdPacientePartidaNavigation.DscNicknamePaciente == nickname).ToList();
                List<Partida> listaPartida = new List<Partida>();
                foreach (var tblPartida in listaTblPartida)
                {
                    Partida partida = new Partida(tblPartida.IdJogoPartida, tblPartida.IdPacientePartida, tblPartida.IdPalavraPartida, tblPartida.DtPartida.ToString(), tblPartida.DuracaoPartida.ToString(), tblPartida.StatusPartida, (int)tblPartida.QtdErrosPartida, (int)tblPartida.QtdAcertosPartida);
                    listaPartida.Add(partida);
                }
                return Ok(listaTblPartida);
            }
            catch (Exception)
            {

                return StatusCode(
                        500,
                        new ErrorResponse("Não foi possível responder a requisição.")
                    );
            }
        }

        //api/[controller]
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Partida partida)
        {
            try
            {
                partida.Cadastrar(partida);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(
                        500,
                        new ErrorResponse("Não foi possível responder a requisição.")
                    );
            }
        }
    }
}
