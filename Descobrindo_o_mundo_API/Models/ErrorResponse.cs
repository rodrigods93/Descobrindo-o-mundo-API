using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descobrindo_o_mundo_API.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(string error)
        {
            Erro = error;
        }
        public string Erro { get; set; }
    }
}