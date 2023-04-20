using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesOrionTM.Model.Entity
{
    public abstract class DateTimeController
    {
        private DateTime prDateTimeRegCreation;
        private string prIdUserRegCreation;
        private DateTime prDateTimeRegUpdate;
        private string prIdUserRegUpdate;

        public DateTimeController()
        {
        }

        public DateTime DateTimeRegCreation
        {
            get
            {
                return prDateTimeRegCreation;
            }
            set
            {
                prDateTimeRegCreation = value;
            }
        }

        public string IdUserRegCreation
        {
            get
            {
                return prIdUserRegCreation;
            }
            set
            {
                prIdUserRegCreation = value;
            }
        }

        public DateTime DateTimeRegUpdate
        {
            get
            {
                return prDateTimeRegUpdate;
            }
            set
            {
                prDateTimeRegUpdate = value;
            }
        }

        public string IdUserRegUpdate
        {
            get
            {
                return prIdUserRegUpdate;
            }
            set
            {
                prIdUserRegUpdate = value;
            }
        }

        public void ChangeDateInsert(string paIdUser)
        {
            prDateTimeRegCreation = DateTime.Now;
            prDateTimeRegUpdate = prDateTimeRegCreation;
            prIdUserRegCreation = paIdUser;
            prIdUserRegUpdate = paIdUser;
        }

        public void ChangeDateUpdate(string paIdUser)
        {
            prDateTimeRegUpdate = DateTime.Now;
            prIdUserRegUpdate = paIdUser;
        }
    }
}




namespace br.com.procomp.Infra.Model.Entity
{
    /// <summary>
    /// Classe genérica de controle de data/hora dos registros
    /// da base de dados
    /// </summary>
    public abstract class DataHoraControle
    {
        
        /// <summary>
        /// Atualiza os campos de data/hora e usuario de controle de
        /// atualizacao do registro
        /// </summary>
        /// <param name="paintIdUsuario">Id do usuario de criacao do registro</param>
        
    }
}
