using Employee.Backend.Data;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception Exception)
            {
                return ExceptionActionResponse(Exception);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }

            _entity.Remove(row);

            try
            {
                await _context.SaveChangesAsync();

                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    Message = "No se puede borrar porque tiene registros relacionados"
                };
            }
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = row
                };
            }
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        //Metodo que filtra registros por nombres o apellidos si colocas "Ju" buscara registros que coincidan con esa cadena
        // Método genérico que busca registros que contengan una cadena de texto en cualquiera de sus campos de tipo string.
        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(string filtro)
        {
            // Verifica si la cadena de búsqueda está vacía o nula
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = false,
                    Message = "Debe ingresar una cadena para buscar."
                };
            }

            // Convierte el texto a minúsculas para hacer la búsqueda insensible a mayúsculas
            filtro = filtro.ToLower();

            // Obtiene todos los registros de la entidad actual
            var query = _entity.AsQueryable();

            // Usa reflexión para obtener las propiedades de tipo string del modelo genérico T
            var stringProperties = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            // Aplica un filtro dinámico: busca el texto dentro de cualquier propiedad string
            var results = await query.Where(e =>
                stringProperties.Any(p =>
                    // Obtiene el valor de la propiedad y lo convierte a string
                    (p.GetValue(e) != null) &&
                    // Convierte a minúsculas y verifica si contiene la cadena buscada
                    p.GetValue(e)!.ToString()!.ToLower().Contains(filtro)
                )
            ).ToListAsync();

            // Si encontró registros, los devuelve
            if (results.Any())
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = true,
                    Result = results
                };
            }

            // Si no encontró registros, devuelve un mensaje informativo
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = false,
                Message = "No se encontraron registros que coincidan con la búsqueda."
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()
        };

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception Exception)
            {
                return ExceptionActionResponse(Exception);
            }
        }

        private ActionResponse<T> ExceptionActionResponse(Exception exception) => new ActionResponse<T>
        {
            Message = exception.Message
        };

        private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T>
        {
            Message = " Ya existe el registro. "
        };

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();

            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();
            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
    }
}