using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Oyun için kelimeleri listeledik. Tahmin edilmesi gereken kelimeler burada.
        List<string> kelimeler = new List<string> { "hilmi", "salih", "altınışık", "yazılım", "mühendis" };

        // Rastgele kelime seçiyoruz ve küçük harfe çeviriyoruz.
        Random rnd = new Random();
        string secilenKelime = kelimeler[rnd.Next(kelimeler.Count)].ToLower();

        // Kelimenin uzunluğu kadar gizli karakterler ile tahmin ekranı başlatıyoruz.
        char[] tahminEdilen = new char[secilenKelime.Length];
        for (int i = 0; i < tahminEdilen.Length; i++)
        {
            tahminEdilen[i] = '_'; // Tahmin edilmeyen harfler alt çizgiyle gizleniyor.
        }

        // Maksimum hata sayısı ve yanlış tahminler listesi.
        int hatalar = 0;
        const int maxHata = 6;
        List<char> yanlisTahminler = new List<char>();

        // Oyun döngüsü başlıyor.
        while (hatalar < maxHata)
        {
            Console.Clear(); // Her adımda ekran temizleniyor.
            Console.WriteLine("Adam Asmaca Oyunu"); // Başlık
            Console.WriteLine($"Tahmin edilen kelime: {new string(tahminEdilen)}");

            if (yanlisTahminler.Count > 0)
            {
                Console.WriteLine($"Yanlış harfler: {string.Join(", ", yanlisTahminler)}");
            }

            Cizim(hatalar); // Adamın çizimi, her hata yaptıkça biraz daha asılıyor!

            Console.WriteLine("Kelimeyi tahmin edebilir ya da harf tahmini yapabilirsiniz:");
            string input = Console.ReadLine().ToLower(); // Girdi küçük harfe çevriliyor

            // Eğer kullanıcı direkt olarak kelimeyi tahmin etmeye çalışıyorsa
            if (input.Length > 1)
            {
                if (input == secilenKelime) // Eğer doğru kelime girilirse
                {
                    Console.Clear();
                    Console.WriteLine($"Tebrikler! Kelimeyi doğru tahmin ettiniz: {secilenKelime}");

                    // Konsolu kapatmadan önce bir duraklama ekliyoruz.
                    Console.WriteLine("Oyunu kazandınız! Devam etmek için Enter'a basın...");
                    Console.ReadLine(); // Kullanıcıya sonucun ardından oyunu gözlemlemesi için zaman tanıyoruz.
                    break; // Döngüyü bitirip oyunu kazandırıyoruz.
                }
                else
                {
                    // Yanlış kelime tahmin edilirse bir hata ekliyoruz.
                    Console.WriteLine("Yanlış kelime tahmini! Hata sayısı artıyor.");
                    hatalar++;
                }
            }
            else if (!string.IsNullOrEmpty(input)) // Eğer bir harf tahmin ediyorsa
            {
                char tahmin = input[0]; // İlk harfi alıyoruz (kullanıcı string girse bile)

                if (secilenKelime.Contains(tahmin.ToString())) // Doğru harf tahmin edilirse
                {
                    for (int i = 0; i < secilenKelime.Length; i++)
                    {
                        if (secilenKelime[i] == tahmin)
                        {
                            tahminEdilen[i] = tahmin; // Harfi açığa çıkarıyoruz
                        }
                    }

                    // Eğer kelimenin tüm harfleri açığa çıktıysa oyunu kazandınız demektir.
                    if (!new string(tahminEdilen).Contains('_'.ToString()))
                    {
                        Console.Clear();
                        Console.WriteLine($"Tebrikler! Kelimeyi harf harf doğru tahmin ettiniz: {secilenKelime}");

                        // Konsolu kapatmadan önce bir duraklama ekliyoruz.
                        Console.WriteLine("Oyunu kazandınız! Devam etmek için Enter'a basın...");
                        Console.ReadLine(); // Kullanıcıya sonucun ardından oyunu gözlemlemesi için zaman tanıyoruz.
                        break; // Döngüyü bitiriyoruz çünkü kazandınız.
                    }
                }
                else
                {
                    // Yanlış harf tahmini yapılırsa
                    if (!yanlisTahminler.Contains(tahmin))
                    {
                        yanlisTahminler.Add(tahmin);
                        hatalar++;
                    }
                    Console.WriteLine("Yanlış tahmin! Hata sayısı artıyor.");
                }
            }
            else
            {
                // Boş giriş yapılırsa uyarıyoruz.
                Console.WriteLine("Lütfen bir harf veya kelime girin.");
            }

            // Eğer maksimum hata sayısına ulaşırsak oyunu kaybettiniz.
            if (hatalar == maxHata)
            {
                Console.Clear();
                Cizim(hatalar); // Adam tamamen asıldı
                Console.WriteLine("Oyunu kaybettiniz!");
                Console.WriteLine("Doğru kelime: " + secilenKelime);

                // Kaybettikten sonra da ekrana bir duraklama ekliyoruz.
                Console.WriteLine("Devam etmek için Enter'a basın...");
                Console.ReadLine(); // Oyunu kaybettikten sonra sonucun ardından gözlem için zaman tanıyoruz.
            }
        }
    }

    // Adamın çizimini yapan metod.
    static void Cizim(int hataSayisi)
    {
        switch (hataSayisi)
        {
            case 0:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
            case 1:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
            case 2:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
            case 3:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
            case 4:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
            case 5:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" /    |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
            case 6:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" / \\  |");
                Console.WriteLine("      |");
                Console.WriteLine("=========");
                break;
        }
    }
}
