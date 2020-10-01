using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descobrindo_o_mundo_API.Models
{
    public class Profissional
    {
        #region Propriedades
        private int _id;
        private int _idUsuario;
        private string _crm;
        #endregion

        #region Properties
        public int Id { get => _id; set => _id = value; }
        public int IdUsuairo { get => _idUsuario; set => _idUsuario = value; }
        public string Crm { get => _crm; set => _crm = value; }
        #endregion

        #region Construtores
        public Profissional() {}
        public Profissional(string crm)
        {
            this.Crm = crm;
        }
        #endregion
    }
}
