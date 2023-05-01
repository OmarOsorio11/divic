using COMMON.DTO;
using COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace divic.BIZ
{
    public abstract class GenericManager<T> : IGenericManager<T> where T : BaseDTO
    {
        public IGenericRepository<T> repository;
        public GenericManager(IGenericRepository<T> repositorio)
        {
            repository = repositorio;
        }

        public string Error
        {
            get
            {
                return repository.Error;
            }
            set => Error = value;
        }

        public IEnumerable<T> ObtenerTodos
        {
            get
            {
                try
                {
                    Error = "";
                    return repository.Read;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    return null;
                }
            }
        }


        public bool Actualizar(T entidad)
        {
            try
            {
                bool r = repository.Update(entidad);
                Error = repository.Error;
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Borrar(int id)
        {
            try
            {
                bool r = repository.Delete(id);
                Error = repository.Error;
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;

            }
        }

        public T BuscarPorId(int id)
        {
            try
            {
                Error = "";
                return repository.SearchById(id);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public bool Crear(T entidad)
        {
            try
            {
                bool r = repository.Create(entidad);
                Error = repository.Error;
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
                throw;
            }
        }
    }
}
