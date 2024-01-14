using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

public enum KahveTuru
{
    Cortado = 1,
    Latte,
    FlatWhite,
    CaramelMacchiato,
    WhiteChocolateMocha,
    Cappuccino
}

public enum OdemeTipi
{
    Nakit = 1,
    KrediKarti,
    Havale
}

//Kredi kartı bilgilerini tutan KrediKarti sınıfı
class KrediKarti
{
    public string KartNumarasi { get; set; }
    public string SonKullanmaTarihi { get; set; }
    public string GuvenlikKodu { get; set; }
}

//Müşteri bilgilerini tutaN Musteri sınıfı
class Musteri
{
    // Müşteri bilgilerini tutan sınıf
    public string KullaniciAdi { get; set; }
    public string Email { get; set; }
    public string Adres { get; set; }


    // Müşteri sınıfının kurucu metodu
    public Musteri(string kullaniciAdi, string email, string adres)
    {
        KullaniciAdi = kullaniciAdi;
        Email = email;
        Adres = adres;
    }


    // Müşteri profilini görüntüleme metodu
    public void ProfiliGoruntule()
    {
        Console.WriteLine("Müşteri Profili:");
        Console.WriteLine($"Kullanıcı Adı: {KullaniciAdi}");
        Console.WriteLine($"E-posta: {Email}");
        Console.WriteLine($"Adres: {Adres}");
        Console.WriteLine();
    }


    // Müşteri bilgilerini güncelleme metodu
    public void BilgileriGuncelle()
    {
        Console.WriteLine("Müşteri Bilgilerini Güncelle:");


        Console.Write("Yeni Kullanıcı Adı: ");
        KullaniciAdi = Console.ReadLine();


        Console.Write("Yeni E-posta: ");
        Email = Console.ReadLine();


        Console.Write("Yeni Adres: ");
        Adres = Console.ReadLine();


        Console.WriteLine("Bilgileriniz güncellendi.");
    }
}

// Ürün bilgilerini tutan abstract sınıf
abstract class Urun
{


    public string Ad { get; set; }
    public decimal Fiyat { get; set; }


    // Süt türünü tutan özellik
    public string SutTuru { get; set; }


    // Ürün sınıfının kurucu metodu
    public Urun(string ad, decimal fiyat, string sutTuru)
    {
        Ad = ad;
        Fiyat = fiyat;
        SutTuru = sutTuru;
    }


    // Süt türüne göre fiyatı güncelleme metodu
    public void SutTuruneGoreFiyatGuncelle()
    {
        // Süt türüne göre fiyatı arttır
        if (SutTuru == "Badem Sütü")
        {
            Fiyat += 18.00m; // Badem sütü için fiyatı arttır
        }
        else if (SutTuru == "Hindistan Cevizi Sütü")
        {
            Fiyat += 15.00m; // Hindistan cevizi sütü için fiyatı arttır
        }
        if (SutTuru == "Laktozsuz Süt")
        {
            Fiyat += 16.00m; // Laktozsuz süt için fiyatı arttır
        }
        if (SutTuru == "Yulaf Sütü")
        {
            Fiyat += 12.00m; // Yulaf sütü için fiyatı arttır
        }
    }


    // Ürün bilgilerini görüntüleme metodu
    public virtual void UrunBilgisi()
    {
        Console.WriteLine($"Ürün Adı: {Ad}");
        Console.WriteLine($"Fiyat: ₺{Fiyat:N2}");
        Console.WriteLine($"Süt Türü: {SutTuru}");


    }
}

class Kahve : Urun
{
    // Kahve ürününü temsil eden sınıf
    public string KahveTuru { get; set; }
    public decimal SutFiyati { get; set; }


    // Urun sınıfından alınan özellikleri kullanan kurucu metot
    public Kahve(string ad, decimal fiyat, string kahveTuru, decimal sutFiyati, string sutTuru)
        : base(ad, fiyat, sutTuru)
    {
        KahveTuru = kahveTuru;
        SutFiyati = sutFiyati;
    }


    // Ürün bilgilerini görüntüleme metodu
    public override void UrunBilgisi()
    {


        Console.WriteLine($"Kahve Türü: {KahveTuru}");
        Console.WriteLine($"Süt Türü: {SutTuru}");
    }
}

class KampanyaIndirim
{
    // Kampanya indirimi bilgilerini tutan sınıf
    public string Ad { get; set; }
    public decimal IndirimOrani { get; set; }




    // Kampanya indirimi sınıfının kurucu metodu
    public KampanyaIndirim(string ad, decimal indirimOrani)
    {
        Ad = ad;
        IndirimOrani = indirimOrani;
    }
}


class Program
{
    // Kullanıcı adı, alışveriş sepeti, aktif kredi kartı ve müşteri bilgilerini tutan değişkenler
    static string kullaniciAdi = "";
    static List<Urun> sepet = new List<Urun>();
    static KrediKarti aktifKrediKarti;
    static Musteri aktifMusteri;

    static void Main(string[] args)
    {
        // Uygulama başlatıldığında ekrana mesaj yazdır
        Console.WriteLine("Cafe Otomasyonu yükleniyor...");
        Thread.Sleep(1000); //1 saniye bekle
        Console.Clear(); //Ekranı temizle


        do
        {
            // Kullanıcıya giriş yapma veya çıkış yapma seçenekleri sun
            Console.WriteLine("Giriş Ekranı:");
            Console.WriteLine("1. Kayıt Ol");
            Console.WriteLine("2. Çıkış");


            int girisSecim;
            //Girilen değer, sayı değilse ya da 1den küçük, 2den büyükse hata ver.
            while (!int.TryParse(Console.ReadLine(), out girisSecim) || girisSecim < 1 || girisSecim > 3)
            {
                Console.WriteLine("Geçersiz giriş. Lütfen 1-2 arasında bir sayı seçin.");
            }


            switch (girisSecim)
            {
                case 1:
                    // Kullanıcı kayıt ol seçeneğini seçerse GirisYap metodu çağrılır
                    GirisYap();
                    break;


                case 2:
                    // Kullanıcı çıkış yap seçeneğini seçerse uygulama kapatılır
                    Console.WriteLine("Çıkış yapılıyor...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;


                default:
                    break;
            }


            // Eğer kullanıcı giriş yapmışsa, ana menüyü göster
            if (!string.IsNullOrEmpty(kullaniciAdi))
            {
                MenuGoster();
            }


        } while (true);
    }

    static void GirisYap()
    {
        Console.Clear();

        do
        {
            // Kullanıcıdan sadece harfler içeren bir kullanıcı adı iste
            Console.WriteLine("Kullanıcı Adınız (sadece harf giriniz):");
            kullaniciAdi = Console.ReadLine();


            // Eğer girilen kullanıcı adı sadece harflerden oluşmuyorsa, hata mesajı ver ve kullanıcıyı tekrar giriş yapmaya yönlendir
            if (!IsAllLetters(kullaniciAdi))
            {
                Console.WriteLine("Geçersiz kullanıcı adı! Lütfen sadece harf kullanın.");
                Console.ReadKey();
                Console.Clear();
            }


        } while (!IsAllLetters(kullaniciAdi)); // Kullanıcı geçerli bir kullanıcı adı girene kadar döngü devam eder


        // E-posta ve şifre bilgileri iste
        Console.WriteLine("");
        Console.WriteLine("E-posta Adresiniz");
        string email = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Şifreniz");
        string sifre = SifreYaz();


        Console.Clear();


        Console.WriteLine("Giriş Bilgileriniz:");
        Console.WriteLine("-------------------------------");




        // Kullanıcı adı, şifre veya e-posta geçersizse hata mesajı ver ve kullanıcı bilgileri tekrar girilmesi iste
        if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(email) || !IsValidEmail(email))
        {
            Console.WriteLine("Kullanıcı adı, şifre veya e-posta adresi geçersiz! Enter'a basıp tekrardan bilgilerinizi giriniz.");
            Console.ReadKey();
            Console.Clear();
            kullaniciAdi = ""; // Kullanıcı adını sıfırlamak için
        }
        else
        {
            // Giriş bilgileri doğru girildiyse bilgileri görüntüle ve müşteri nesnesi oluştur
            Console.WriteLine($"Kullanıcı Adı: {kullaniciAdi}");
            Console.WriteLine($"E-posta Adresi: {email}");
            Console.WriteLine($"Şifre: {new string('*', sifre.Length)}");
            Console.WriteLine("-------------------------------");


            Console.WriteLine("\nGiriş başarılı!");


            // Aktif müşteri oluştur
            aktifMusteri = new Musteri(kullaniciAdi, email, "Default Adres");


            Console.ReadKey();
        }


        Console.Clear();
    }

    static void MenuGoster()
    {
        Console.Clear();

        // Ana menü seçenekleri
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("ANA MENÜ:");
        Console.WriteLine("1. Kahve Menüsü");
        Console.WriteLine("2. Sepetimi Göster");
        Console.WriteLine("3. Sepeti Sil");
        Console.WriteLine("4. Sipariş ve Ödeme");
        Console.WriteLine("5. Kampanyalar ve İndirimler");
        Console.WriteLine("6. Müşteri Profili Güncelle");
        Console.WriteLine("7. Çıkış");
        Console.WriteLine("-------------------------------------------");




        Console.WriteLine("Seçiminizi yapınız:");


        int menuSecim;


        // Kullanıcının geçerli bir menü seçeneği girmesi sağlanır
        while (!int.TryParse(Console.ReadLine(), out menuSecim) || menuSecim < 1 || menuSecim > 7)
        {
            Console.WriteLine("Geçersiz seçim. Lütfen 1-7 arasında bir sayı seçin.");
        }


        // Kullanıcının seçtiği degere göre fonksiyonu çağır
        switch (menuSecim)
        {
            case 1:
                KahveMenu();
                break;


            case 2:
                SepetiGoster();
                break;


            case 3:
                SepetiSil();
                break;


            case 4:
                SiparisVeOdeme();
                break;


            case 5:
                KampanyaVeIndirimler();
                break;


            case 6:
                ProfilGuncelle();
                break;


            case 7:
                // Kullanıcı çıkış yapmak isterse kullanıcıya bir kez daha sor
                Console.Write("Çıkış yapmak istiyor musunuz? (E/H): ");
                string cikisSecim = Console.ReadLine();


                // Onaylanırsa çıkış yapılır
                if (cikisSecim.ToLower() == "e")
                {
                    Console.WriteLine("Çıkış yapılıyor...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }


                //Onaylanmazsa menüyü göster
                else
                {
                    Console.WriteLine("Çıkış işlemi iptal edildi.");
                    MenuGoster();
                }
                break;


            default:
                break;
        }
    }

    static void KahveMenu()
    {
        // Ekranı temizle
        Console.Clear();


        // Kahve menüsü listelenir
        Console.WriteLine("KAHVE MENÜSÜ");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("1. Cortado");
        Console.WriteLine("2. Latte");
        Console.WriteLine("3. Flat White");
        Console.WriteLine("4. Caramel Macchiato");
        Console.WriteLine("5. White Chocolate Mocha");
        Console.WriteLine("6. Cappuccino");
        Console.WriteLine("7. Geri Dön");
        Console.WriteLine("-------------------------------------------");


        Console.WriteLine("Seçiminizi yapınız:");


        int kahveSecim;


        // Kullanıcının geçerli bir kahve seçeneği girmesi sağlanır
        while (!int.TryParse(Console.ReadLine(), out kahveSecim) || kahveSecim < 1 || kahveSecim > 7)
        {
            Console.WriteLine("Geçersiz seçim. Lütfen 1-7 arasında bir sayı seçin.");
        }


        if (kahveSecim != 7)
        {
            // Kahve boyutu seç
            decimal boyutFiyati = KahveBoyutuSec(out string kahveBoyutu);


            // Kahve siparişi al ve sepete ekle
            KahveSiparisiAl((KahveTuru)kahveSecim, boyutFiyati);
        }
        else
        {
            // Kullanıcı "7. Geri Dön" seçeneğini seçerse ana menüye dönülür
            MenuGoster();
        }
    }

    static decimal KahveBoyutuSec(out string kahveBoyutu)
    {
        Console.Clear(); // Ekran temizlenir
        Console.WriteLine("KAHVE BOYUTU SEÇİMİ");
        // Kahve boyutları listelenir
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("1. Küçük ");
        Console.WriteLine("2. Orta           +10tl");
        Console.WriteLine("3. Büyük          +20tl");
        Console.WriteLine("-------------------------------------------");


        Console.WriteLine("Seçiminizi yapınız:");


        int boyutSecim;
        // Kullanıcının geçerli bir boyut seçeneği girmesi sağlanır
        while (!int.TryParse(Console.ReadLine(), out boyutSecim) || boyutSecim < 1 || boyutSecim > 3)
        {
            Console.WriteLine("Geçersiz seçim. Lütfen 1-3 arasında bir sayı seçin.");
        }


        decimal boyutFiyati = 0m;


        // Kullanıcının seçtiği boyuta göre fiyat belirlenir
        switch (boyutSecim)
        {
            case 1:
                kahveBoyutu = "Küçük";
                break;


            case 2:
                kahveBoyutu = "Orta";
                boyutFiyati = 10.00m;
                break;


            case 3:
                kahveBoyutu = "Büyük";
                boyutFiyati = 20.00m;
                break;


            default:
                kahveBoyutu = "";
                break;
        }
        return boyutFiyati; // Seçilen boyutun fiyatı döndür
    }

    static string SutSecimiAl()
    {
        Console.Clear();
        Console.WriteLine("");
        // Kahve için süt seçenekleri listelenir
        Console.WriteLine("------------------------------------");
        Console.WriteLine("KAHVENİZDE İSTEDİĞİNİZ SÜTÜ SEÇİN:");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1. Normal Süt");
        Console.WriteLine("2. Hindistan Cevizi Sütü        +15tl");
        Console.WriteLine("3. Badem Sütü                   +18tl");
        Console.WriteLine("4. Laktozsuz Süt                +16tl");
        Console.WriteLine("5. Yulaf Sütü                   +12tl");
        Console.WriteLine("------------------------------------");




        Console.WriteLine("Seçiminizi yapınız:");


        int sutSecim;


        // Kullanıcının geçerli bir süt seçeneği girmesi sağlanır
        while (!int.TryParse(Console.ReadLine(), out sutSecim) || sutSecim < 1 || sutSecim > 5)
        {
            Console.WriteLine("Geçersiz seçim. Lütfen 1-3 arasında bir sayı seçin.");
        }


        string sutTuru = "";


        // Kullanıcının seçtiği süt türü belirlenir
        switch (sutSecim)
        {
            case 1:
                sutTuru = "Normal Süt";
                break;


            case 2:
                sutTuru = "Hindistan Cevizi Sütü";
                break;


            case 3:
                sutTuru = "Badem Sütü ";
                break;


            case 4:
                sutTuru = "Laktozsuz Süt";
                break;


            case 5:
                sutTuru = "Yulaf Sütü";
                break;


            default:
                break;
        }


        return sutTuru;// Seçilen süt türünü döndür


    }

    static void KahveSiparisiAl(KahveTuru kahveTuru, decimal boyutFiyati)
    {
        do
        {
            decimal sutFiyati = 0m;
            string sutTuru = SutSecimiAl(); // Süt seçimi yapılır


            //Yeni bir kahve nesnesi oluşturulur
            var kahve = new Kahve(kahveTuru.ToString(), 60m + boyutFiyati + sutFiyati, kahveTuru.ToString(), sutFiyati, sutTuru);
            kahve.SutTuruneGoreFiyatGuncelle();


            //Sepete eklenir
            sepet.Add(kahve);


            //Başka bir kahve siparişi vermek isteyip istemediği sorulur
            Console.Write("Başka kahve siparişi vermek ister misiniz? (E/H): ");
            string devamSecim = Console.ReadLine();


            // "E" girilirse kahve menüsüne, "H" girilirse ana menüye dön
            if (devamSecim.ToLower() == "e")
            {
                KahveMenu();
            }
            else
            {
                MenuGoster();
                break;
            }


        } while (true);


        Console.ReadKey();
    }

    static void SepetiGoster()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("SEPETİM");
        Console.WriteLine("-------------------------------------------");


        //Sepet boş değil ise sepetteki her ürün için bilgiler görüntülenir ve toplam fiyat hesaplanır
        if (sepet.Count > 0)
        {
            decimal toplamFiyat = 0m;


            foreach (var urun in sepet)
            {
                urun.UrunBilgisi();
                toplamFiyat += urun.Fiyat;
            }


            // Toplam tutar görüntülenir
            Console.WriteLine($"Toplam Tutar: ₺{toplamFiyat:N2}");
        }
        else
        {
            Console.WriteLine("Sepetiniz boş.");
        }


        Console.ReadKey();
        MenuGoster();
    }

    static void SepetiSil()
    {
        Console.Clear();
        Console.WriteLine("SEPETİ SİL");
        Console.WriteLine("-------------------------------------------");

        // Sepet boş ise uyarı gönder
        if (sepet.Count == 0)
        {
            Console.WriteLine("Sepetinizde zaten hiç ürün bulunmamaktadır.");
        }
        else
        {
            // Kullanıcıya hangi ürünü silmek istediğini seçmesini iste
            Console.WriteLine("Lütfen silmek istediğiniz ürünü seçiniz:");
            for (int i = 0; i < sepet.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sepet[i].Ad} - ₺{sepet[i].Fiyat:N2}");
            }

            Console.Write("Silmek istediğiniz ürünün numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int secilenUrun) && secilenUrun >= 1 && secilenUrun <= sepet.Count)
            {
                Urun silinecekUrun = sepet[secilenUrun - 1];

                // Silme işleminden önce kullanıcıdan onay al
                Console.Write($"'{silinecekUrun.Ad}' ürününü silmek istediğinize emin misiniz? (E/H): ");
                string onay = Console.ReadLine();

                if (onay.ToUpper() == "E")
                {
                    // Seçilen ürünü sepetten sil
                    sepet.Remove(silinecekUrun);
                    Console.WriteLine($"{silinecekUrun.Ad} başarıyla sepetten silindi.");
                }
                else
                {
                    Console.WriteLine("İşlem iptal edildi.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz bir ürün numarası girdiniz.");
            }
        }

        Console.ReadKey();
        MenuGoster();
    }

    static void SiparisVeOdeme()
    {
        Console.Clear();
        Console.WriteLine("SİPARİŞ VE ÖDEME EKRANI");
        Console.WriteLine("-------------------------------------------");


        // Sepette hiç ürün yoksa kullanıcı uyarılır ve menüye geri dönülür
        if (sepet.Count == 0)
            if (sepet.Count == 0)
            {
                Console.WriteLine("Sepetinizde hiç ürün bulunmamaktadır. Lütfen önce ürün ekleyin.");
                Console.ReadKey();
                MenuGoster();
                return;
            }


        decimal toplamFiyat = 0;


        // Sepetteki her ürünün bilgileri görüntülenir ve toplam fiyat hesaplanır
        foreach (var urun in sepet)
        {
            urun.UrunBilgisi();
            toplamFiyat += urun.Fiyat;
            Console.WriteLine("-------------------------------");
        }


        Console.WriteLine($"Toplam Fiyat: {toplamFiyat:C}");


        // Ödeme tipi seçimini yap
        Console.WriteLine("Ödeme Tipini Seçin:");
        Console.WriteLine("1. Nakit");
        Console.WriteLine("2. Kredi Kartı");
        Console.WriteLine("3. Banka Havalesi");


        OdemeTipi odemeTipi;
        while (!Enum.TryParse(Console.ReadLine(), out odemeTipi) || !Enum.IsDefined(typeof(OdemeTipi), odemeTipi))
        {
            Console.WriteLine("Geçersiz giriş. Lütfen 1-3 arasında bir sayı seçin.");
        }


        // Ödeme tipine göre işlemler yapılır
        if (odemeTipi == OdemeTipi.KrediKarti)
        {
            // Kredi kartı ödeme işlemi başlatılır
            bool odemeBasarili = false;


            while (!odemeBasarili)
            {
                // Kredi kartı bilgileri alınır ve doğruluğu kontrol edilir
                Console.Write("Kart Numarası (16 haneli): ");
                string kartNumarasi = GetMaskedCreditCardNumber();
                if (kartNumarasi.Length != 16 || !kartNumarasi.All(char.IsDigit))
                {
                    Console.WriteLine("Geçersiz kart numarası. 16 haneli ve sadece sayılardan oluşmalıdır.");
                    continue;
                }


                Console.Write("Son Kullanma Tarihi (AA/YY): ");
                string sonKullanmaTarihi = Console.ReadLine();


                int ay, yil;
                if (!int.TryParse(sonKullanmaTarihi.Substring(0, 2), out ay) || ay < 1 || ay > 12 || !int.TryParse(sonKullanmaTarihi.Substring(3, 2), out yil) || yil < 22)
                {
                    Console.WriteLine("Geçersiz ay veya yıl değeri. Lütfen geçerli bir tarih girin.");
                    return;
                }


                // Güvenlik kodunu al ve kontrol et
                Console.Write("Güvenlik Kodu (3 haneli): ");
                string guvenlikKodu = Console.ReadLine();
                if (guvenlikKodu.Length != 3 || !guvenlikKodu.All(char.IsDigit))
                {
                    Console.WriteLine("Geçersiz güvenlik kodu. 3 haneli ve sadece sayılardan oluşmalıdır.");
                    continue;
                }


                // Kredi kartı nesnesini oluştur
                aktifKrediKarti = new KrediKarti
                {
                    KartNumarasi = kartNumarasi,
                    SonKullanmaTarihi = sonKullanmaTarihi,
                    GuvenlikKodu = guvenlikKodu
                };


                Console.Write("Ödeme yapmak istiyor musunuz? (E/H): ");
                string odemeSecim = Console.ReadLine();


                if (odemeSecim.ToLower() == "e")
                {
                    // Ödeme işlemi gerçekleştiriliyor...
                    Console.WriteLine("\nKredi Kartı ile ödeme yapılıyor...");
                    Thread.Sleep(2000); // 2 saniye beklet


                    Console.WriteLine("\nSiparişiniz alınmıştır.");
                    Console.WriteLine("");
                    Thread.Sleep(4000); // 2 saniye beklet


                    odemeBasarili = true;
                    sepet.Clear(); // Sepeti temizle


                    MenuGoster();
                }
                else
                {
                    Console.WriteLine("\nÖdeme işlemi iptal edildi.");
                    MenuGoster();
                    return; // Ödeme iptal edildiği için fonksiyondan çık
                }
            }
        }
        else if (odemeTipi == OdemeTipi.Nakit)
        {
            NakitOdemeYap(toplamFiyat);
        }
        else if (odemeTipi == OdemeTipi.Havale)
        {
            HavaleOdemeYap(toplamFiyat);
        }
        else
        {
            Console.WriteLine("\nGeçersiz ödeme tipi seçildi.");
            return;
        }
    }

    static void NakitOdemeYap(decimal toplamFiyat)
    {
        Console.Clear();
        Console.WriteLine("NAKİT ÖDEME");
        Console.WriteLine("-------------------------------------------");


        decimal toplamTutar = ToplamTutariHesapla();
        Console.WriteLine($"Toplam Tutar: ₺{toplamTutar:N2}");


        Console.WriteLine("Nakit ödeme yapılıyor...");
        Thread.Sleep(2000);


        Console.WriteLine("Ödeme tamamlandı. Teşekkür ederiz!");


        sepet.Clear(); // Sepeti temizle
        Console.ReadKey();
        MenuGoster();


    }

    static void HavaleOdemeYap(decimal toplamFiyat)
    {
        Console.Clear();
        Console.WriteLine("BANKA HAVALESİ İLE ÖDEME");
        Console.WriteLine("-------------------------------------------");


        decimal toplamTutar = ToplamTutariHesapla();
        Console.WriteLine($"Toplam Tutar: ₺{toplamTutar:N2}");


        Console.WriteLine("Banka havalesi ile ödeme yapılıyor. Lütfen aşağıdaki hesap numarasına tutarı gönderin.");


        // Banka hesap bilgileri
        string bankaHesapAdi = "Cafe Bankası";
        string bankaSube = "Şube: 1234";
        string hesapNumarasi = "Hesap No: 5678";
        string iban = "IBAN: TR12 3456 7890 1234 5678 9012 34";


        Console.WriteLine($"{bankaHesapAdi}\n{bankaSube}\n{hesapNumarasi}\n{iban}");


        Console.WriteLine("\nÖdeme onaylandıktan sonra siparişiniz hazırlanacaktır. Teşekkür ederiz!");


        sepet.Clear(); // Sepeti temizle
        Console.ReadKey();
        MenuGoster();


    }

    // Sepetteki ürünlerin toplam fiyatını hesaplayan metod
    static decimal ToplamTutariHesapla()
    {
        decimal toplamTutar = 0m;


        // Sepetteki her ürünün fiyatını toplam tutara ekler
        foreach (var urun in sepet)
        {
            toplamTutar += urun.Fiyat;
        }


        return toplamTutar;
    }

    // Kampanya ve indirim bilgilerini tutan liste
    static List<KampanyaIndirim> kampanyaIndirimListesi = new List<KampanyaIndirim>();

    static bool indirimUygulandi = false;
    static void KampanyaVeIndirimler()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("KAMPANYA VE İNDİRİMLER");
        Console.WriteLine("-------------------------------------------");


        // Örnek kampanya ve indirimleri listeye ekleyelim
        kampanyaIndirimListesi.Add(new KampanyaIndirim("Özel İndirim", 0.1m)); // %10 indirim
        kampanyaIndirimListesi.Add(new KampanyaIndirim("Kahve Festivali", 0.15m)); // %15 indirim


        // Kampanya ve indirimleri listeleyelim
        foreach (var kampanyaIndirim in kampanyaIndirimListesi)
        {
            Console.WriteLine($"{kampanyaIndirim.Ad}: %{kampanyaIndirim.IndirimOrani * 100} indirim");
        }


        Console.Write("Indirim kodu giriniz (Çıkmak için 'exit' yazabilirsiniz): ");
        string indirimKodu = Console.ReadLine();


        if (indirimKodu.ToLower() == "exit")
        {
            Console.Clear();
            MenuGoster();
            Console.ReadKey();
            return;
        }


        // Kullanıcı tarafından girilen indirim kodunu kontrol et
        KampanyaIndirim kullanilanIndirim = kampanyaIndirimListesi.Find(indirim => indirim.Ad.ToLower() == indirimKodu.ToLower());




        if (kullanilanIndirim != null && !indirimUygulandi) // Kontrol ekledik
        {
            // Toplam indirimli tutarı hesapla
            decimal toplamFiyat = ToplamIndirimliTutar(kullanilanIndirim.IndirimOrani);


            // Sepetin toplam fiyatını güncelle
            sepet.ForEach(urun => urun.Fiyat -= urun.Fiyat * kullanilanIndirim.IndirimOrani);


            Console.WriteLine($"Toplam İndirimli Tutar: {toplamFiyat:C}");


            // Kullanılan indirimi indirim listesinden çıkar
            kampanyaIndirimListesi.Remove(kullanilanIndirim);


            indirimUygulandi = true; // İndirim uygulandı bilgisini güncelledik
        }
        else if (indirimUygulandi)
        {
            Console.WriteLine("Bu indirim zaten uygulandı.");
        }
        else
        {
            Console.WriteLine("Geçersiz indirim kodu.");
        }


        Thread.Sleep(5000);
        Console.Clear();
        MenuGoster();
        Console.ReadKey();
    }

    static decimal ToplamIndirimliTutar(decimal indirimOrani)
    {
        decimal toplamFiyat = 0;


        // Sepetteki ürünlerin toplam fiyatını hesapla
        foreach (var urun in sepet)
        {
            toplamFiyat += urun.Fiyat;
        }


        // İndirim oranını uygula
        decimal indirimMiktari = toplamFiyat * indirimOrani;
        toplamFiyat -= indirimMiktari;


        return toplamFiyat;
    }

    static bool IsValidInput(string input, string inputType)
    {
        switch (inputType.ToLower())
        {
            case "username":
                // Kullanıcı adı kontrolü: Sadece harf ve rakamlardan oluşmalı, boşluk içermemelialı
                return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetterOrDigit);


            case "email":
                // E-posta kontrolü: Basit bir e-posta format kontrolü
                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(input);
                    return mailAddress.Address == input;
                }
                catch
                {
                    return false;
                }


            case "address":
                // Adres kontrolü: Boş olmamalı
                return !string.IsNullOrWhiteSpace(input);


            default:
                return false;
        }
    }

    static void ProfilGuncelle()
    {
        Console.Clear();
        Console.WriteLine("PROFİL GÜNCELLEME EKRANI");
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine("Hangi bilgiyi güncellemek istersiniz?");
        Console.WriteLine("1. Kullanıcı Adı");
        Console.WriteLine("2. E-Posta");
        Console.WriteLine("3. Adres");
        Console.WriteLine("4. İptal");

        Console.Write("Seçiminizi yapın (1-4): ");
        string secim = Console.ReadLine();

        switch (secim)
        {
            case "1":
                // Kullanıcı Adı güncelleme
                Console.Write("Yeni Kullanıcı Adı: ");
                string yeniKullaniciAdi = Console.ReadLine();
                if (IsValidInput(yeniKullaniciAdi, "username"))
                {
                    aktifMusteri.KullaniciAdi = yeniKullaniciAdi;
                    Console.WriteLine("Kullanıcı Adınız güncellenmiştir.");
                }
                else
                {
                    Console.WriteLine("Geçersiz kullanıcı adı. Kullanıcı adı sadece harf ve rakamlardan oluşmalı, boşluk içermemeli ve en az 3 karakter olmalıdır.");
                }
                break;

            case "2":
                // E-Posta güncelleme
                Console.Write("Yeni E-Posta: ");
                string yeniEmail = Console.ReadLine();
                if (IsValidInput(yeniEmail, "email"))
                {
                    aktifMusteri.Email = yeniEmail;
                    Console.WriteLine("E-Posta adresiniz güncellenmiştir.");
                }
                else
                {
                    Console.WriteLine("Geçersiz e-posta adresi. Lütfen geçerli bir e-posta adresi girin.");
                }
                break;

            case "3":
                // Adres güncelleme
                Console.Write("Yeni Adres: ");
                string yeniAdres = Console.ReadLine();
                if (IsValidInput(yeniAdres, "address"))
                {
                    aktifMusteri.Adres = yeniAdres;
                    Console.WriteLine("Adresiniz güncellenmiştir.");
                }
                else
                {
                    Console.WriteLine("Adres boş olamaz. Lütfen geçerli bir adres girin.");
                }
                break;

            case "4":
                // İptal
                Console.WriteLine("İşlem iptal edildi.");
                break;

            default:
                Console.WriteLine("Geçersiz seçim. Lütfen 1-4 arasında bir sayı girin.");
                break;
        }

        Console.ReadKey();
        MenuGoster();
    }

    static string SifreYaz()
    {
        string sifre = "";
        ConsoleKeyInfo key;


        do
        {
            key = Console.ReadKey(true);


            // Backspace'e basıldıysa ve şifre boş değilse bir karakteri sil
            if (key.Key == ConsoleKey.Backspace && sifre.Length > 0)
            {
                sifre = sifre.Substring(0, sifre.Length - 1);
                Console.Write("\b \b");
            }
            else if (key.Key != ConsoleKey.Enter) // Enter'a basılmadıysa karakteri ekle
            {
                sifre += key.KeyChar;
                Console.Write("*");
            }


        } while (key.Key != ConsoleKey.Enter);


        Console.WriteLine();
        return sifre;
    }

    // Verilen bir e-posta adresinin geçerli olup olmadığını kontrol eden metod
    static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    // Verilen bir metnin sadece harf içerip içermediğini kontrol eden metod
    static bool IsAllLetters(string input)
    {
        foreach (char c in input)
        {
            if (!Char.IsLetter(c))
                return false;
        }
        return true;
    }

    // Kullanıcıdan kredi kartı numarasını alarak maskeleyen metot
    private static string GetMaskedCreditCardNumber()
    {
        StringBuilder maskedNumber = new StringBuilder();
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (char.IsDigit(key.KeyChar) && maskedNumber.Length < 16)
            {
                maskedNumber.Append(key.KeyChar);
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && maskedNumber.Length > 0)
            {
                maskedNumber.Remove(maskedNumber.Length - 1, 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return maskedNumber.ToString();
    }
}