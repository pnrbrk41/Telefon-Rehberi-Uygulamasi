using System;
using System.Collections.Generic;

class Project_1
{
    public static void Main(string[] args)
    {

        HazirKayitlarGetir();

        string secim = "";

        while (secim != "6")
        {

            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(6) Çıkmak için");

            secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    NumaraEkle();
                    break;

                case "2":
                    NumaraSil();
                    break;

                case "3":
                    NumaraGuncelle();
                    break;

                case "4":
                    NumaraListele();
                    break;

                case "5":
                    NumaraArama();
                    break;

                case "6": continue;

                default:
                    Console.WriteLine("1 ile 5 arası seçim yapınız ya da 6 ile çıkış yapınız.");
                    Console.ReadKey();
                    break;
            }



        }
    }

    public static void NumaraEkle()
    {
      Console.Write("Lütfen isim giriniz             : ");
      string isim = Console.ReadLine();

      Console.Write("Lütfen soyisim giriniz          : ");
      string soyisim = Console.ReadLine();

      Console.Write("Lütfen telefon numarası giriniz : ");
      string telno = Console.ReadLine();

      Kisiler.Add(new TelefonDefteri{Isim = isim, Soyisim = soyisim, TelNo = telno});

      Console.WriteLine("Numaranız başarıyla eklenmiştir.\n");
      Console.ReadKey();
    }

    public static void NumaraSil()
    {
      Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
      string filtre = Console.ReadLine();
      
      
      foreach(var item in Kisiler){
        
        if(filtre == item.Isim || filtre == item.Soyisim){
          Console.Write(item.Isim + " " + item.Soyisim + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n) : ");
          string evethayır = Console.ReadLine();

          if(evethayır == "y"){
            Kisiler.Remove(item);
            Console.WriteLine(item.Isim + " " + item.Soyisim + " isimli kişi rehberden silindi.\n");
            break;
          }
          if(evethayır == "n"){
            Console.WriteLine("Ana menüye dönülüyor...\n");
            break;
          }
        }

        else{

          Console.WriteLine("\nAradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
          Console.WriteLine("* Silmeyi sonlandırmak için : (1) ");
          Console.WriteLine("* Yeniden denemek için      : (2) ");
          string secimyap = Console.ReadLine();

          if(secimyap == "1")
            break;
          if(secimyap == "2")
            NumaraSil();
          if(secimyap != "1" || secimyap != "2"){
            Console.WriteLine("Lütfen seçiminizi 1 ya da 2 yazarak yapınız! Devam için herhangi bir tuşa basın.\n");
            Console.ReadKey();
          }
                    
        }
         
      }

      
    }

    public static void NumaraGuncelle()
    {
      Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
      string filtre = Console.ReadLine();
      int sayac = 0;
      
      foreach(var item in Kisiler){
        
        if(filtre == item.Isim || filtre == item.Soyisim){
          Console.WriteLine(item.Isim + " " + item.Soyisim + " için yeni numarayı giriniz: ");
          string yenitelno = Console.ReadLine();
          item.TelNo = yenitelno;
          Console.WriteLine("\n");
          sayac += 1;
          break;
        }
      }

      if(sayac == 0){
        Console.WriteLine("\nAradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
          Console.WriteLine("* Güncellemeyi sonlandırmak için : (1) ");
          Console.WriteLine("* Yeniden denemek için      : (2) ");
          string secimyap = Console.ReadLine();

          if(secimyap == "1")
            return;
          if(secimyap == "2")
            NumaraGuncelle();
          
      }

  

      
    }

    public static void NumaraListele()
    {
        Console.WriteLine("Telefon Rehberi");
        Console.WriteLine("**********************************************");
        foreach (var item in Kisiler)
        {
            Console.WriteLine("\nİsim: " + item.Isim);
            Console.WriteLine("Soyisim: " + item.Soyisim);
            Console.WriteLine("Telefon Numarasi: " + item.TelNo);
        }
        Console.WriteLine("\n");
    }

    public static void NumaraArama()
    {
      Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
      Console.WriteLine("**********************************************\n");
      Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1)");
      Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
      string secimyap = Console.ReadLine();

      if(secimyap == "1"){
        Console.WriteLine("Lütfen bulmak istediğiniz kişinin adını ya da soyadını giriniz: ");
      string filtre = Console.ReadLine();

        foreach(var item in Kisiler){
          if(item.Isim == filtre || item.Soyisim == filtre){
            Console.WriteLine("\nİsim: " + item.Isim);
            Console.WriteLine("Soyisim: " + item.Soyisim);
            Console.WriteLine("Telefon Numarasi: " + item.TelNo);
          }
        }
        Console.WriteLine("\n");
      } 
      else if(secimyap == "2"){
        Console.WriteLine("Lütfen bulmak istediğiniz kişinin telefon numarasını giriniz: ");
      string filtre = Console.ReadLine();

        foreach(var item in Kisiler){
          if(item.TelNo == filtre){
            Console.WriteLine("\nİsim: " + item.Isim);
            Console.WriteLine("Soyisim: " + item.Soyisim);
            Console.WriteLine("Telefon Numarasi: " + item.TelNo);
          }
        }
        Console.WriteLine("\n");
      }
      
    }

    class TelefonDefteri
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TelNo { get; set; }

        public TelefonDefteri(string isim, string soyisim, string telno)
        {
            Isim = isim;
            Soyisim = soyisim;
            TelNo = telno;
        }

        public TelefonDefteri() { }
    }

    static List<TelefonDefteri> Kisiler = new List<TelefonDefteri>();
    //Varsayılan 5 kaydı ekleme:  
    public static void HazirKayitlarGetir()
    {
        Kisiler.Add(new TelefonDefteri() { Isim = "yeni1", Soyisim = "bir", TelNo = "111100111111" });
        Kisiler.Add(new TelefonDefteri() { Isim = "yeni2", Soyisim = "iki", TelNo = "25552222222" });
        Kisiler.Add(new TelefonDefteri() { Isim = "yeni3", Soyisim = "üç", TelNo = "33333333333" });
    }
}