using COMMON.DTO;
using COMMON.Interfaces;
using COMMON.Validadores;
using DAL.SQLSERVER;

namespace divic.CONSOLE
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IGenericRepository<Delivery> deliveryRepository;
            deliveryRepository = new GenericRepository<Delivery>(new DeliveryValidator());
            Delivery c = CrearDeliveryDePrueba();
            deliveryRepository.Create(c);
            c.Nombre = "Andre";
            deliveryRepository.Update(c);
            int cantidadDeliverys = deliveryRepository.Read.Count();

            System.Console.WriteLine(cantidadDeliverys);
        }
        private static Delivery CrearDeliveryDePrueba()
        {
            Random r = new Random();
            return new Delivery()
            {
                Id = r.Next(1, 100),
                Nombre = "Pedro Paramo",
                FechaNacimiento = new DateTime(1990, 11, 21),
                Usuario = "Param23",
                Password = "123param",
                PaquetesEntregados = 12
            };
        }
        /*
        
        static void Main(string[] args)
        {
            IGenericRepository<PaqueteEntregado> paqueteEntregadoRepository;
            paqueteEntregadoRepository = new GenericRepository<PaqueteEntregado>(new PaqueteEntregadoValidator());
            PaqueteEntregado c = CrearPaqueteEntregadoDePrueba();
            int cantidadPaquetesEntregados = paqueteEntregadoRepository.Read.Count();
            System.Console.WriteLine(cantidadPaquetesEntregados);
        }
        private static PaqueteEntregado CrearPaqueteEntregadoDePrueba()
        {
            Random r = new Random();
            return new PaqueteEntregado()
            {
                Id = r.Next(1, 100),
                IdPaquete = 4,
                NombreRecibe = "Jose Lopez",
                TipoPersonaRecibe = "Familiar",
                UrlImagen = "https://facturama.mx/blog/wp-content/uploads/2021/01/curp-generica-sat-1024x631.png",
                CurpRecibe = "XEXX010101HNEXXXA4"
            };
        }*/
    }
}
