using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jenkins.Backend.Modelo;
using Jenkins.Backend.MVVM.Base;
using Jenkins.Backend.Repositorios;
using Jenkins.Backend.Servicios_Repositorios_;

namespace Jenkins.Backend.MVVM
{
    internal class MVMesa : MVBase
    {
        #region Campos y propiedades priivados

        /// <summary>
        /// Ponemos los objetos que vamos a guardar en el 
        /// </summary>
        private Mesa _mesa;
        private Reserva _reserva;
        





        /// <summary>
        /// Ponemos los repositorios que vayamos a necesitar
        /// </summary>

        private MesaRepository _mesaRepository;
        private ReservaRepository _reservaRepository;
        private DisponibilidadMesaRepository _disponibilidadMesaRepository;
        #endregion

    }
}
