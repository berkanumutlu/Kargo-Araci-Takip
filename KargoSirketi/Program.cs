using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KargoSirketi
{
    class Program
    {
        // Olay için kullanılan Temsilci tanımlanıyor.
        public delegate void SpeedHandler(object sender, CargoVehicle cv);

        // Kargo aracı nesnesi için tasarlanacak Sınıf
        public class CargoVehicle
        {
            private int speed;
            private static int hizsiniri = 110;
            private string plaka;
            private DateTime zaman;

            // Kargo aracının hız bilgisinin değişmesi durumunda tetiklenecek olay
            public event SpeedHandler SpeedExceeded;

            public int Speed
            {
                get { return speed; }
                set
                {
                    if (value > hizsiniri && SpeedExceeded!=null)
                    {
                        SpeedExceeded(this, new CargoVehicle(Plaka, value));// Hız sınırı aşılınca Event tetikleniyor.
                    }
                    speed = value;
                }
            }

            public string Plaka
            {
                get { return plaka; }
                set { plaka = value; }
            }

            public DateTime Zaman
            {
                get { return zaman; }
                set { zaman = value; }
            }

            public CargoVehicle(string plaka, int speed)
            {
                this.plaka = plaka;
                this.speed = speed;
            }
        }

        // Temsilciye bağlanacak metot
        public static void kargo_aracı_SpeedExceeded(object sender, CargoVehicle cv)
        {
            cv.Zaman = DateTime.Now;
            Console.WriteLine("Alarm: " + cv.Plaka + " plakalı kargo aracı hız sınırını aştı. " + cv.Zaman + " anındaki hızı: " + cv.Speed);
        }

        static void Main(string[] args)
        {
            // Kaynak_Kod_1
            CargoVehicle kargo_aracı1 = new CargoVehicle("42SU1975", 80);
            kargo_aracı1.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);

            CargoVehicle kargo_aracı2 = new CargoVehicle("06CD456", 90);
            kargo_aracı2.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);

            // Kaynak_Kod_2
            for (byte i = 80; i < 130; i += 5)
            {
                kargo_aracı1.Speed = i;
                kargo_aracı2.Speed = (byte)(i + 10);
                Console.WriteLine(kargo_aracı1.Plaka + " plakalı aracın hızı = " + kargo_aracı1.Speed);
                Console.WriteLine(kargo_aracı2.Plaka + " plakalı aracın hızı = " + kargo_aracı2.Speed + "\n");
                Thread.Sleep(1000);
            }
            Console.Write("Kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}