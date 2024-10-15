using System;

class MatrixMultiplication
{
    static void Main()
    {
        int N;

        // Kullanıcıdan matrisin boyutunu doğru bir şekilde alana kadar soruyoruz
        while (true)
        {
            Console.Write("Matrislerin boyutunu (NxN) girin: ");
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

        // Matris elemanlarını rastgele mi yoksa elle mi girmek istiyor?
        Console.Write("Matris elemanlarını otomatik doldurmak için 'r' tuşlayın, elle girmek için 'e' tuşlayın: ");
        char fillType = Console.ReadKey().KeyChar;
        Console.WriteLine();

        // İlk matrisin doldurulması
        int[,] matrix1 = new int[N, N];
        Console.WriteLine("Birinci matrisi doldurun:");
        FillMatrix(matrix1, N, fillType);

        // İkinci matrisin doldurulması
        int[,] matrix2 = new int[N, N];
        Console.WriteLine("İkinci matrisi doldurun:");
        FillMatrix(matrix2, N, fillType);

        // Sonuç matrisi oluşturuluyor
        int[,] resultMatrix = new int[N, N];

        // Matris çarpımını gerçekleştiriyoruz
        MultiplyMatrices(matrix1, matrix2, resultMatrix, N);

        // Birinci matrisi yazdırıyoruz
        Console.WriteLine("Birinci Matris:");
        PrintMatrix(matrix1, N);

        // İkinci matrisi yazdırıyoruz
        Console.WriteLine("İkinci Matris:");
        PrintMatrix(matrix2, N);

        // Sonuç matrisi ekrana yazdırılıyor
        Console.WriteLine("Matrislerin çarpım sonucu:");
        PrintMatrix(resultMatrix, N);

        // Konsolun kapanmasını engellemek için bir bekleme ekliyoruz
        Console.ReadLine();
    }

    // Matrisi rastgele veya elle sayılarla dolduran fonksiyon
    static void FillMatrix(int[,] matrix, int N, char fillType)
    {
        Random rand = new Random(); // Rastgele sayı üreteci

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (fillType == 'r' || fillType == 'R')
                {
                    // Eğer 'r' veya 'R' girildiyse rastgele doldur
                    matrix[i, j] = rand.Next(1, 10); // 1 ile 9 arasında rastgele bir tam sayı atıyoruz
                }
                else if (fillType == 'e' || fillType == 'E')
                {
                    // Eğer 'e' veya 'E' girildiyse kullanıcıdan elle girdi al
                    while (true)
                    {
                        Console.Write($"[{i + 1}, {j + 1}] elemanını girin: ");
                        string input = Console.ReadLine();

                        // Kullanıcıdan alınan girdinin geçerli bir tam sayı olup olmadığını kontrol ediyoruz
                        if (int.TryParse(input, out matrix[i, j]))
                        {
                            break; // Eğer geçerli bir sayı girdiyse döngüden çıkıyoruz
                        }
                        else
                        {
                            Console.WriteLine("Lütfen geçerli bir tam sayı girin.");
                        }
                    }
                }
            }
        }
    }

    // İki matrisi çarpan fonksiyon
    static void MultiplyMatrices(int[,] matrix1, int[,] matrix2, int[,] resultMatrix, int N)
    {
        // Her bir eleman için çarpma işlemi
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                resultMatrix[i, j] = 0; // İlk başta sonucu sıfırlıyoruz
                for (int k = 0; k < N; k++)
                {
                    // Matris çarpım işlemi
                    resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
    }

    // Matrisi ekrana düzgün bir formatta yazdıran fonksiyon
    static void PrintMatrix(int[,] matrix, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j].ToString("D2") + " "); // Her elemanı iki haneli yazdırıyoruz
            }
            Console.WriteLine(); // Her satırdan sonra bir alt satıra geçiyoruz
        }
    }
}

