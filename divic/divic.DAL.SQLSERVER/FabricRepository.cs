using COMMON.DTO;
using COMMON.Interfaces;
using COMMON.Validadores;
using DAL.SQLSERVER;

namespace divic.DAL.SQLSERVER
{
    public static class FabricRepository
    {
        public static IGenericRepository<Delivery> Delivery()
        {
            return new GenericRepository<Delivery>(new DeliveryValidator());
        }
        public static IGenericRepository<Paquete> Paquete()
        {
            return new GenericRepository<Paquete>(new PaqueteValidator());
        }
        public static IGenericRepository<PaqueteEnTransito> PaqueteEnTransito()
        {
            return new GenericRepository<PaqueteEnTransito>(new PaqueteEnTransitoValidator());
        }
        public static IGenericRepository<PaqueteEntregado> PaqueteEntregado()
        {
            return new GenericRepository<PaqueteEntregado>(new PaqueteEntregadoValidator());
        }
    }
}
