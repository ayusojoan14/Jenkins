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
    public class MVMesa : MVBase
    {
        #region Campos y propiedades priivados

        /// <summary>
        /// Ponemos los objetos que vamos a guardar en el 
        /// </summary>
        private Mesa _mesa;
        private Reserva _reserva;
        private DisponibilidadMesa _disponibilidadMesa;
        private Horario _horario;
        private Personal _personal;
        private Restaurante _restaurante;


        public MVMesa(HorarioRepository horarioRepository,
                       MesaRepository mesaRepository,
                       ReservaRepository reservaRepository,
                       DisponibilidadMesaRepository disponibilidadMesa,
                       PersonalRepository personalRepository)
        {
          
            _horarioRepository = horarioRepository;
            _personalRepository = personalRepository;
            _disponibilidadMesaRepository = disponibilidadMesa;
            _reservaRepository = reservaRepository;
            _mesaRepository = mesaRepository;


        }







        /// <summary>
        /// Ponemos los repositorios que vayamos a necesitar
        /// </summary>
        private HorarioRepository _horarioRepository;
        private MesaRepository _mesaRepository;
        private ReservaRepository _reservaRepository;
        private DisponibilidadMesaRepository _disponibilidadMesaRepository;
        private PersonalRepository _personalRepository;

        ///Lista de las mesas que puede haber
        ///
        private List<DisponibilidadMesa> _listaDisponibilidadMesas;


        #endregion

    }
}
