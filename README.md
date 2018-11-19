# [C#] Kargo Aracı Takibi
Bir kargo şirketinin ulaştırma filosundaki araçların birer nesne ile ifade edilebildiği bir kütüphane olduğunu düşünelim. Bu kütüphane içerisindeki fonksiyonellikler den biriside, araçların uydu
sistemleri yardımıyla düzenli olarak izlenmesi ve güncel koordinat, anlık hız gibi bilgilerinin elde edilmesi olduğunu varsayalım.

Araçların belirlenen hız limitlerini aşmaları sonrasında oluşacak durumların söz konusu kütüphaneyi kullanan uygulamalar tarafından, istenirse ele alınmalarını sağlamak amacıyla
gereken olayları (event) ve sınıfları yazmanız istenmektedir. Böylece söz konusu program, araç hız limitini aştığı zaman neler yapmak istiyorsa bunları istediği şekilde ele alabilecektir.

Sınıf, temsilci ve olay tanımlamalarını aşağıda bir bölümü verilen **Kaynak_Kod_2** çalıştırıldığında; verilen ekran çıktısını alabilecek şekilde projeyi geliştirmeniz istenmektedir. **CargoVehicle** Kargo aracı nesnesi için tasarlanacak sınıfı, **SpeedExceeded** kargo
aracının hız bilgisinin değişmesi durumunda tetiklenecek olayı, **SpeedHandler** olay için kullanılan temsilciyi göstermektedir. **kargo_aracı_SpeedExceeded** ise temsilciye bağlanacak metodun ismidir. Hız limitinin varsayılan değeri olarak **110** alınmıştır.

**Kaynak_Kod_1**
```sh
CargoVehicle kargo_aracı = new CargoVehicle("42SU1975");
kargo_aracı.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);
```

**Kaynak_Kod_2**
```sh
for (byte i = 80; i < 130; i += 5)
{
kargo_aracı1.Speed = i;
kargo_aracı2.Speed = (byte)(i + j);
Console.WriteLine(kargo_aracı1.Plaka+" plakalı aracın hızı = "+kargo_aracı_1.Speed);
Console.WriteLine(kargo_aracı2.Plaka+" plakalı aracın hızı = "+kargo_aracı_2.Speed);
Thread.Sleep(1000);
}
```

**Ekran Çıktısı**
```sh
42SU1975 plakalı aracın hızı = 80
06CD456 plakalı aracın hızı = 90

42SU1975 plakalı aracın hızı = 85
06CD456 plakalı aracın hızı = 95

42SU1975 plakalı aracın hızı = 90
06CD456 plakalı aracın hızı = 100

42SU1975 plakalı aracın hızı = 95
06CD456 plakalı aracın hızı = 105

42SU1975 plakalı aracın hızı = 100
06CD456 plakalı aracın hızı = 110

Alarm: 06CD456 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:47 anındaki hızı: 115
42SU1975 plakalı aracın hızı = 105
06CD456 plakalı aracın hızı = 115

Alarm: 06CD456 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:48 anındaki hızı: 120
42SU1975 plakalı aracın hızı = 110
06CD456 plakalı aracın hızı = 120

Alarm: 42SU1975 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:49 anındaki hızı: 115
Alarm: 06CD456 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:49 anındaki hızı: 125
42SU1975 plakalı aracın hızı = 115
06CD456 plakalı aracın hızı = 125

Alarm: 42SU1975 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:50 anındaki hızı: 120
Alarm: 06CD456 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:50 anındaki hızı: 130
42SU1975 plakalı aracın hızı = 120
06CD456 plakalı aracın hızı = 130

Alarm: 42SU1975 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:51 anındaki hızı: 125
Alarm: 06CD456 plakalı kargo aracı hız sınırını aştı. 21.11.2017 19:11:51 anındaki hızı: 135
42SU1975 plakalı aracın hızı = 125
06CD456 plakalı aracın hızı = 135

Kapatmak için bir tuşa basın...
```
