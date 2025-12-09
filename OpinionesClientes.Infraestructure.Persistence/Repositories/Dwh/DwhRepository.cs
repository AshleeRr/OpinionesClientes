using Microsoft.EntityFrameworkCore;
using OpinionesClientes.Application.Dtos;
using OpinionesClientes.Application.IRepositories.Dwh;
using OpinionesClientes.Persistence.Repositories.Dwh.Context;
using OpinionesCLientes.Domain.Entities.Dwh.Dimensions;
using OpinionesCLientes.Domain.Entities.Dwh.Facts;

namespace OpinionesClientes.Persistence.Repositories.Dwh
{
    public class DwhRepository : IDwhRepository
    {
        private readonly DwhContext _context;

        public DwhRepository(DwhContext context)
        {
            _context = context;
        }
        public async Task LoadFactsDataAsync(List<FactCommentsDto> factDtos)
        {
            var factList = new List<FactComentarios>();

            foreach (var item in factDtos)
            {
                // Obtener fks  desde dims 
                var clienteKey = await _context.DimClientes
                    .Where(c => c.ClienteId == item.IdCliente)
                    .Select(c => c.ClienteKey)
                    .FirstOrDefaultAsync();

                if (clienteKey == 0)
                {
                    clienteKey = await _context.DimClientes
                        .Where(c => c.ClienteId == 0)
                        .Select(c => c.ClienteKey)
                        .FirstAsync();
                }

                var productoKey = await _context.DimProductos
                    .Where(p => p.ProductId == item.IdProducto)
                    .Select(p => p.ProductKey)
                    .FirstOrDefaultAsync();

                if (productoKey == 0)
                {
                    productoKey = await _context.DimProductos
                        .Where(c => c.ProductId == 0)
                        .Select(c => c.ProductKey)
                        .FirstAsync();
                }

                var fact = new FactComentarios
                {
                    ComentarioId = item.ComentarioId,
                    Comentario = item.Comentario,
                    FechaRealizacion = item.FechaRealizacion,
                    IdCliente = clienteKey,
                    IdProducto = productoKey,
                    Clasificacion = item.Clasificacion,
                    Rating = item.Rating,
                    IdFuente = item.IdFuente
                };

                factList.Add(fact);
            }

            await _context.FactComentarios.AddRangeAsync(factList);
            await _context.SaveChangesAsync();
        }

        public async Task LoadDimsDataAsync(DimDto dimDtos)
        {
            var dimClientes = dimDtos.Clientes.Select(c => new DimClientes            
            {
                ClienteId = c.IdCliente,
                Nombre = c.Nombre,
                Email = c.Email
            }).ToList();

            await _context.DimClientes.AddRangeAsync(dimClientes);

            // Cliente desconocido
            if (!await _context.DimClientes.AnyAsync(c => c.ClienteId == 0))
            {
                await _context.DimClientes.AddAsync(new DimClientes
                {
                    ClienteId = 0,
                    Nombre = "Cliente Desconocido",
                    Email = "N/A"
                });
                await _context.SaveChangesAsync();
            }

            var dimProductos = dimDtos.Productos.Select(p => new DimProductos
            {
                ProductId = p.IdProducto,
                Nombre = p.Nombre,
                NombreCategoria = p.Categoria,
            }).ToList();

            await _context.DimProductos.AddRangeAsync(dimProductos);

            // Producto desconocido
            if (!await _context.DimProductos.AnyAsync(c => c.ProductId == 0))
            {
                await _context.DimProductos.AddAsync(new DimProductos
                {
                    ProductId = 0,
                    Nombre = "Producto Desconocido",
                    NombreCategoria = "N/A"
                });
                await _context.SaveChangesAsync();
            }
            
            var dimFuentes = dimDtos.FuentesDatos.Select(f => new DimFuente_Datos
            {
                FuenteId = f.IdFuente,
                TipoFuente = f.TipoFuente,
                FechaDeCarga = f.FechaCarga
            }).ToList();

            await _context.DimFuente_Datos.AddRangeAsync(dimFuentes);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetOrCreateFuenteKeyAsync(string tipoFuente)
        {
            tipoFuente = tipoFuente.Trim().ToLower();
            var fuente = await _context.DimFuente_Datos
                .FirstOrDefaultAsync(f => f.TipoFuente.ToLower() == tipoFuente);

            if (fuente != null)
                return fuente.FuenteKey;

            string nuevoCodigo = await GenerarNuevoCodigoFuenteAsync();

            var nuevaFuente = new DimFuente_Datos
            {
                FuenteId = nuevoCodigo,
                TipoFuente = tipoFuente,
                FechaDeCarga = DateTime.Now
            };

            _context.DimFuente_Datos.Add(nuevaFuente);
            await _context.SaveChangesAsync();

            return nuevaFuente.FuenteKey;
        }

        public async Task CleanDimensionsAsync()
        {
            await _context.DimClientes.ExecuteDeleteAsync();
            await _context.DimProductos.ExecuteDeleteAsync();
            await _context.DimFuente_Datos.ExecuteDeleteAsync();
        }

        public async Task CleanFactsAsync()
        {
            await _context.FactComentarios.ExecuteDeleteAsync();
        }

        private async Task<string> GenerarNuevoCodigoFuenteAsync()
        {
            int count = await _context.DimFuente_Datos.CountAsync();
            return $"F{(count + 1).ToString("D3")}";
        }
    }
}

