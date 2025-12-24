namespace dis_klinigi_otomasyon_programi
{
    // Randevu sınıfı
    public class RandevuBilgisi
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = "";
        public string Saat { get; set; } = "";
        public string Tarih { get; set; } = "";
        public string Tedavi { get; set; } = "";
    }

    // Tedavi sınıfı
    public class TedaviBilgisi
    {
        public int Id { get; set; }
        public string TedaviAdi { get; set; } = "";
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; } = "";
    }

    // Reçete sınıfı
    public class ReceteBilgisi
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = "";
        public string TedaviAdi { get; set; } = "";
        public decimal Tutar { get; set; }
        public int Miktar { get; set; }
    }

    // Ortak veri deposu (tüm formlar arasında paylaşılacak)
    public static class VeriDeposu
    {
        public static List<RandevuBilgisi> Randevular { get; set; } = new List<RandevuBilgisi>();
        public static List<TedaviBilgisi> Tedaviler { get; set; } = new List<TedaviBilgisi>();
        public static List<ReceteBilgisi> Receteler { get; set; } = new List<ReceteBilgisi>();

        public static int SonRandevuId { get; set; } = 0;
        public static int SonTedaviId { get; set; } = 0;
        public static int SonReceteId { get; set; } = 0;

        public static string[] Hastalar { get; } = new string[]
        {
            "Ahmet Yılmaz",
            "Mehmet Kaya",
            "Ayşe Demir",
            "Fatma Çelik",
            "Ali Öztürk",
            "Zeynep Aksoy",
            "Mustafa Şahin",
            "Emine Koç",
            "Hasan Kaya",
            "Emine Gül"
        };

        static VeriDeposu()
        {
            // Örnek tedaviler
            Tedaviler.Add(new TedaviBilgisi { Id = ++SonTedaviId, TedaviAdi = "Dolgu", Tutar = 500, Aciklama = "Diş dolgusu işlemi" });
            Tedaviler.Add(new TedaviBilgisi { Id = ++SonTedaviId, TedaviAdi = "Çekim", Tutar = 300, Aciklama = "Diş çekimi işlemi" });
            Tedaviler.Add(new TedaviBilgisi { Id = ++SonTedaviId, TedaviAdi = "Kanal Tedavi", Tutar = 1500, Aciklama = "Kanal tedavisi işlemi" });
            Tedaviler.Add(new TedaviBilgisi { Id = ++SonTedaviId, TedaviAdi = "Diş Taşı Temizleme", Tutar = 400, Aciklama = "Diş taşı temizleme işlemi" });

            // Örnek randevular
            Randevular.Add(new RandevuBilgisi { Id = ++SonRandevuId, AdSoyad = "Ahmet Yılmaz", Tarih = DateTime.Now.ToString("dd.MM.yyyy"), Saat = "09.00-10.00", Tedavi = "Dolgu" });
            Randevular.Add(new RandevuBilgisi { Id = ++SonRandevuId, AdSoyad = "Ayşe Demir", Tarih = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"), Saat = "10.30-11.30", Tedavi = "Çekim" });
            Randevular.Add(new RandevuBilgisi { Id = ++SonRandevuId, AdSoyad = "Mehmet Kaya", Tarih = DateTime.Now.AddDays(2).ToString("dd.MM.yyyy"), Saat = "13.30-14.30", Tedavi = "Kanal Tedavi" });

            // Örnek reçeteler
            Receteler.Add(new ReceteBilgisi { Id = ++SonReceteId, AdSoyad = "Ahmet Yılmaz", TedaviAdi = "Dolgu", Tutar = 500, Miktar = 1 });
            Receteler.Add(new ReceteBilgisi { Id = ++SonReceteId, AdSoyad = "Ayşe Demir", TedaviAdi = "Çekim", Tutar = 300, Miktar = 2 });
        }
    }
}
