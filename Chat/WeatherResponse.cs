/// @autor Ключерев Артемий 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{

    // информация о температуре
    public class TemperatureInfo
    {
        public float Temp { get; set; } // температура
    }

    // информация о погоде
    public class WeatherResponse
    {

        public TemperatureInfo Main { get; set; }
        public string Name { get; set; } // название города
    }
}