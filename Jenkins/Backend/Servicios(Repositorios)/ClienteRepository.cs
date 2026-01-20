using Jenkins.Backend.Modelo;
using Jenkins.Backend.Servicios_Repositorios_;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jenkins.Backend.Servicios
{
    /// <summary>
    /// Repositorio específico para la entidad <see cref="Cliente"/>.
    /// </summary>
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(
            PracticaDllContext context,
            ILogger<ClienteRepository> logger)
            : base(context, logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtiene un cliente por su DNI (sin tracking).
        /// </summary>
        public async Task<Cliente?> GetByDniAsync(string dni, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                .FirstOrDefaultAsync(c => c.Dni == dni, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Comprueba si existe un cliente con el DNI indicado.
        /// </summary>
        public async Task<bool> ExistsByDniAsync(string dni, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                .AnyAsync(c => c.Dni == dni, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Obtiene un cliente con todas sus relaciones cargadas.
        /// </summary>
        public async Task<Cliente?> GetWithRelationsAsync(string dni, CancellationToken cancellationToken = default)
        {
            try
            {
                return await Query(asNoTracking: false,
                        c => c.Pedidos,
                        c => c.Reservas,
                        c => c.Usuarios)
                    .FirstOrDefaultAsync(c => c.Dni == dni, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el cliente con DNI {Dni}", dni);
                throw;
            }
        }
    }
}
