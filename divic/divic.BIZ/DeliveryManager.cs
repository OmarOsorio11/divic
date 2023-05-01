using COMMON.DTO;
using COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace divic.BIZ
{
    public class DeliveryManager : GenericManager<Delivery>
    {
        public DeliveryManager(IGenericRepository<Delivery> repositorio) : base(repositorio)
        {

        }

        public bool ActualizarDelivery(Delivery delivery)
        {
            return repository.Update(delivery);

        }

        public bool CrearDelivery(Delivery delivery)
        {
            return repository.Create(delivery);
        }

        public bool EliminarDelivery(int deliveryId)
        {
            return repository.Delete(deliveryId);
        }

        public IEnumerable<Delivery> ObtenerTodosLosDeliverys()
        {
            return repository.Read;
                }

        public Delivery ObtenerDeliveryPorId(int deliveryId)
        {
            return repository.SearchById(deliveryId);
        }
    }
}