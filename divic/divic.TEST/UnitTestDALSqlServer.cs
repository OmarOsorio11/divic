using COMMON.DTO;
using COMMON.Interfaces;
using COMMON.Validadores;
using DAL.SQLSERVER;

namespace divic.TEST2
{
    [TestClass]
    public class UnitTestDALSqlServer
    {
        IGenericRepository<Delivery> deliveryRepository;
        IGenericRepository<Paquete> paqueteRepository;
        IGenericRepository<PaqueteEnTransito> paqueteEnTransitoRepository;
        IGenericRepository<PaqueteEntregado> paqueteEntregadoRepository;

        Random r;

        private Delivery CrearDeliveryDePrueba()
        {
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
        private Paquete CrearPaqueteDePrueba()
        {
            return new Paquete()
            {
                Id = r.Next(1, 100),
                Descripcion = "Caja de 10*20",
                DireccionEntrega = "Casa azul, las azucenas #30, esq con Ramon Farias, la cofradia, uruapan.",
                Estatus = "En transito",
                Contacto = "1231331231"
            };
        }
        private PaqueteEnTransito CrearPaqueteEnTransitoDePrueba()
        {
            return new PaqueteEnTransito()
            {
                Id = r.Next(1, 100),
                IdDelivery = 3,
                IdPaquete = 4
            };
        }
        private PaqueteEntregado CrearPaqueteEntregadoDePrueba()
        {
            return new PaqueteEntregado()
            {
                Id = r.Next(1, 100),
                IdPaquete = 4,
                NombreRecibe = "Jose Lopez",
                TipoPersonaRecibe = "Familiar",
                UrlImagen = "https://facturama.mx/blog/wp-content/uploads/2021/01/curp-generica-sat-1024x631.png",
                CurpRecibe = "XEXX010101HNEXXXA4"
            };
        }

        public UnitTestDALSqlServer()
        {
            deliveryRepository = new GenericRepository<Delivery>(new DeliveryValidator());
            paqueteRepository = new GenericRepository<Paquete>(new PaqueteValidator());
            paqueteEnTransitoRepository = new GenericRepository<PaqueteEnTransito>(new PaqueteEnTransitoValidator());
            paqueteEntregadoRepository = new GenericRepository<PaqueteEntregado>(new PaqueteEntregadoValidator());
            r = new Random();
        }
        [TestMethod]
        public void TestMethodDelivery()
        {
            Delivery c = CrearDeliveryDePrueba();
            int cantidadDeliverys = deliveryRepository.Read.Count();
            Assert.IsTrue(deliveryRepository.Create(c), deliveryRepository.Error);
            Assert.AreEqual(cantidadDeliverys + 1, deliveryRepository.Read.Count(), "no se inserto el registro");
            int ultimoID = deliveryRepository.Read.Max(j => j.Id);
            Delivery modificado = deliveryRepository.SearchById(ultimoID);
            modificado.Nombre = "Pepe";
            Assert.IsTrue(deliveryRepository.Update(modificado), deliveryRepository.Error);
            Delivery modificado2 = deliveryRepository.SearchById(ultimoID);
            Assert.AreEqual("Pepe", modificado2.Nombre, "Realmente no se actualizo");
            Assert.IsTrue(deliveryRepository.Delete(ultimoID), deliveryRepository.Error);
            Assert.AreEqual(cantidadDeliverys, deliveryRepository.Read.Count(), "no se elimino el producto");

        }


        [TestMethod]
        public void TestMethodPaquetesEntregados()
        {
            PaqueteEntregado c = CrearPaqueteEntregadoDePrueba();
            int cantidadPaquetesEntregados = paqueteEntregadoRepository.Read.Count();
            Assert.IsTrue(paqueteEntregadoRepository.Create(c), paqueteEntregadoRepository.Error);
            Assert.AreEqual(cantidadPaquetesEntregados + 1, paqueteEntregadoRepository.Read.Count(), "no se inserto el registro");
            int ultimoID = paqueteEntregadoRepository.Read.Max(j => j.Id);
            PaqueteEntregado modificado = paqueteEntregadoRepository.SearchById(ultimoID);
            modificado.NombreRecibe = "Pepe";
            Assert.IsTrue(paqueteEntregadoRepository.Update(modificado), paqueteEntregadoRepository.Error);
            PaqueteEntregado modificado2 = paqueteEntregadoRepository.SearchById(ultimoID);
            Assert.AreEqual("Pepe", modificado2.NombreRecibe, "Realmente no se actualizo");
            Assert.IsTrue(paqueteEntregadoRepository.Delete(ultimoID), paqueteEntregadoRepository.Error);
            Assert.AreEqual(cantidadPaquetesEntregados, paqueteEntregadoRepository.Read.Count(), "no se elimino el producto");

        }
        [TestMethod]
        public void TestMethodPaquetes()
        {
            Paquete c = CrearPaqueteDePrueba();
            int cantidadPaquetes = paqueteRepository.Read.Count();
            Assert.IsTrue(paqueteRepository.Create(c), paqueteRepository.Error);
            Assert.AreEqual(cantidadPaquetes + 1, paqueteRepository.Read.Count(), "no se inserto el registro");
            int ultimoID = paqueteRepository.Read.Max(j => j.Id);
            Paquete modificado = paqueteRepository.SearchById(ultimoID);
            modificado.Descripcion = "Pepe";
            Assert.IsTrue(paqueteRepository.Update(modificado), paqueteRepository.Error);
            Paquete modificado2 = paqueteRepository.SearchById(ultimoID);
            Assert.AreEqual("Pepe", modificado2.Descripcion, "Realmente no se actualizo");
            Assert.IsTrue(paqueteRepository.Delete(ultimoID), paqueteRepository.Error);
            Assert.AreEqual(cantidadPaquetes, paqueteRepository.Read.Count(), "no se elimino el producto");

        }
        [TestMethod]
        public void TestMethodPaquetesEnTransito()
        {
            PaqueteEnTransito c = CrearPaqueteEnTransitoDePrueba();
            int cantidadPaquetesEnTransito = paqueteEnTransitoRepository.Read.Count();
            Assert.IsTrue(paqueteEnTransitoRepository.Create(c), paqueteEnTransitoRepository.Error);
            Assert.AreEqual(cantidadPaquetesEnTransito + 1, paqueteEnTransitoRepository.Read.Count(), "no se inserto el registro");
            int ultimoID = paqueteEnTransitoRepository.Read.Max(j => j.Id);
            PaqueteEnTransito modificado = paqueteEnTransitoRepository.SearchById(ultimoID);
            modificado.IdPaquete = 3;
            //Assert.IsTrue(paqueteEnTransitoRepository.Update(modificado), paqueteEnTransitoRepository.Error);
            //PaqueteEnTransito modificado2 = paqueteEnTransitoRepository.SearchById(ultimoID);
            //Assert.AreEqual(3, modificado2.IdPaquete, "Realmente no se actualizo");
            //Assert.IsTrue(paqueteEnTransitoRepository.Delete(ultimoID), paqueteEnTransitoRepository.Error);
            //Assert.AreEqual(cantidadPaquetesEnTransito, paqueteEnTransitoRepository.Read.Count(), "no se elimino el producto");

        }
    }

}