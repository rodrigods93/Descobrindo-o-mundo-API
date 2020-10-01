using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Descobrindo_o_mundo_API.Models
{
    public class Paciente
    {
        #region Propriedades
        private int _id;
        private int _idUsuario;
        private string _nickname;
        #endregion

        #region Properties
        public int Id { get => _id ; set => _id = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Nickname { get => _nickname; set => _nickname = value; }
        #endregion

        #region Construtores
        public Paciente()
        {
        
        }

        public Paciente(int id,int idUsuario,string nickname)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.Nickname = nickname;
        }

        public Paciente(string nick,int idUsuario)
        {
            this.Nickname = nick;
            this.IdUsuario = idUsuario;
        }
        #endregion
    }
}
