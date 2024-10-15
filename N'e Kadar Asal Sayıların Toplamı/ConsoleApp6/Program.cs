using System;

class PrimeSum
{
    static void Main()
    {
        int N;

        // Kullanıcıdan pozitif bir tam sayı alana kadar sormaya devam ediyoruz
        while (true)
        {
            Console.Write("Lütfen N değerini girin (pozitif bir tam sayı): ");
            string input = Console.ReadLine();

            // Girdiyi tam sayıya çevirmeye çalışıyoruz, başarılı olursa döngüden çıkıyoruz
            if (int.TryParse(input, out N) && N > 1)
            {
                break; // Geçerli bir sayı girildiyse döngüyü kırıyoruz
            }
            else
            {
                Console.WriteLine("Lütfen 1'den büyük geçerli bir pozitif tam sayı girin.");
            }
        }

        // N'ye kadar olan asal sayıların toplamını buluyoruz
        int primeSum = SumOfPrimesUpToN(N);

        // Toplam sonucu ekrana yazdırıyoruz
        Console.WriteLine($"{N}'e kadar olan asal sayıların toplamı: {primeSum}");

        // Konsolun kapanmasını önlemek için bekliyoruz
        Console.ReadLine();
    }

    // Verilen N sayısına kadar olan asal sayıların toplamını bulan fonksiyon
    static int SumOfPrimesUpToN(int N)
    {
        int sum = 0; // Asal sayıların toplamını tutmak için değişken
        for (int i = 2; i <= N; i++) // 2'den N'ye kadar tüm sayıları kontrol ediyoruz
        {
            if (IsPrime(i)) // Eğer sayı asal ise
            {
                sum += i; // Toplama ekliyoruz
            }
        }
        return sum; // Toplamı döndürüyoruz
    }

    // Bir sayının asal olup olmadığını kontrol eden fonksiyon
    static bool IsPrime(int number)
    {
        if (number < 2) return false; // 2'den küçük sayılar asal olamaz
        for (int i = 2; i * i <= number; i++) // Sayının kareköküne kadar olan değerlerle bölünebilirlik kontrolü
        {
            if (number % i == 0) // Eğer herhangi bir sayıya bölünüyorsa asal değildir
            {
                return false;
            }
        }
        return true; // Hiçbir sayıya tam bölünmediyse asal demektir
    }
}
