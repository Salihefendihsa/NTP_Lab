using System;

class SpiralMatrix
{
    static void Main()
    {
        int N;

        // Kullanıcıdan NxN boyutunu doğru bir şekilde alana kadar soruyoruz
        while (true)
        {
            Console.Write("Matrisin boyutunu (NxN) girin: ");
            string input = Console.ReadLine();

            // Girdiyi sayıya çevirmeye çalışıyoruz, başarılı olursa döngüden çıkıyoruz
            if (int.TryParse(input, out N) && N > 0)
            {
                break; // Geçerli bir sayı girildiyse döngüyü kırıyoruz
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir pozitif tam sayı girin.");
            }
        }

        // NxN boyutlarında bir matris oluşturuyoruz
        int[,] matrix = new int[N, N];

        // Spiral matrisin sınırlarını tanımlıyoruz
        int top = 0, bottom = N - 1, left = 0, right = N - 1;
        int number = 1; // Matrise yazılacak ilk sayı

        // Döngü ile spiral sıraya göre matrisi dolduruyoruz
        while (top <= bottom && left <= right)
        {
            // Üst kenardan sağa doğru gidiyoruz
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = number++;
            }
            top++; // Üst sınırı bir azaltıyoruz çünkü o satır doldu

            // Sağ kenardan aşağıya doğru gidiyoruz
            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = number++;
            }
            right--; // Sağ sınırı bir azaltıyoruz çünkü o sütun doldu

            // Alt kenardan sola doğru gidiyoruz
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    matrix[bottom, i] = number++;
                }
                bottom--; // Alt sınırı bir artırıyoruz çünkü o satır doldu
            }

            // Sol kenardan yukarıya doğru gidiyoruz
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    matrix[i, left] = number++;
                }
                left++; // Sol sınırı bir artırıyoruz çünkü o sütun doldu
            }
        }

        // Matrisi ekrana yazdırıyoruz
        Console.WriteLine("Spiral Matris:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j].ToString("D2") + " "); // D2: İki haneli formatta yazdırıyoruz
            }
            Console.WriteLine(); // Her satırdan sonra bir alt satıra geçiyoruz
        }

        // Konsolun kapanmasını önlemek için bekleme ekliyoruz
        Console.ReadLine();
    }
}
