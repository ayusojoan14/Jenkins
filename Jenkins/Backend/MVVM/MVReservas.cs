using Jenkins.Backend.Modelo;
using Jenkins.Backend.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins.Backend.MVVM
{
    public class MVReservas : MVBase
    {
        #region Campos y propiedades
        private Reserva _reserva;
        private Cliente _cliente;












        public Reserva Reserva
        {
            get => _reserva;
            set => SetProperty(ref _reserva, value);
        }
        #endregion
    }
}
