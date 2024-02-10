using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    public class PharmacyLocationOutput
    {
        /// <summary>
        /// Datos de la farmacia
        /// </summary>
        public PharmacyOutput PharmacyOutput { get; set; }

        /// <summary>
        /// Distancia en metros camiando
        /// </summary>
        public double DistanceInMetersWalking { get; set; }

        /// <summary>
        /// Tiempo estimado de viaje caminado
        /// </summary>
        public string EstimatedTravelTimeWalking { get; set; }

        /// <summary>
        /// Distancia en metros en automovil
        /// </summary>
        public double DistanceInMetersDriving { get; set; }

        /// <summary>
        /// Tiempo estimado de viaje en automovil
        /// </summary>
        public string EstimatedTravelTimeDriving { get; set; }

        /// <summary>
        /// Distancia en metros en automovil teniendo en cuenta el trafico
        /// </summary>
        public double DistanceInMetersDrivingTraffic { get; set; }

        /// <summary>
        /// Tiempo estimado de viaje en automivil teniendo en cuenta el trafico
        /// </summary>
        public string EstimatedTravelTimeDrivingTraffic { get; set; }
    }
}
