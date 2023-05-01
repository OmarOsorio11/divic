using COMMON.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface IGenericManager<T> where T : BaseDTO
    {
        string Error { get; }
        bool Crear(T entidad);
        IEnumerable<T> ObtenerTodos { get; }
        bool Actualizar(T entidad);
        bool Borrar(int id);
        T BuscarPorId(int id);
    }

}
