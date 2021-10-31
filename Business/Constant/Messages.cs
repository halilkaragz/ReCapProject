using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {        
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandAdded = "Marka eklendi";
        public static string InvalidCarDailyPrice = "Arabanın günlük kiralama fiyatı sıfırdan büyük olmalıdır!";
        public static string InvalidRentforNotReturn = "Araç teslim edilmediği için kiralama başarısız";
    }
}
