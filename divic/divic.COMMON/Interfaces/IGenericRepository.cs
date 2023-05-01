using COMMON.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface IGenericRepository<T> where T : BaseDTO
    {
        string Error { get; }
        bool Create(T entidad);
        IEnumerable<T> Read { get; }
        bool Update(T entidad);
        bool Delete(int id);
        T SearchById(int id);
        IEnumerable<T> Query(string query);
    }
}
