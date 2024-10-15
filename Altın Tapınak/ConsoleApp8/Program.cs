using System;
using System.Collections.Generic;

class Program
{
    // Hareket yönleri: Yukarı, Aşağı, Sol, Sağ
    static int[] rowDirection = { -1, 1, 0, 0 };
    static int[] colDirection = { 0, 0, -1, 1 };

    static void Main(string[] args)
    {
        try
        {
            // Labirent boyutunu kullanıcıdan al
            Console.Write("Labirent boyutunu (N) girin: ");
            int N = int.Parse(Console.ReadLine());

            // Labirent boyutunun geçerli olup olmadığını kontrol et
            if (N <= 0)
            {
                Console.WriteLine("Labirent boyutu pozitif bir sayı olmalıdır.");
                return;
            }

            // Labirent matrisini oluştur
            int[,] labirent = new int[N, N];
            Console.WriteLine("Labirenti satır satır girin (0 veya 1 değerleri ile):");
            for (int i = 0; i < N; i++)
            {
                // Her satırı kullanıcıdan al ve boşluklarla ayırarak değerlere dönüştür
                string[] satir = Console.ReadLine().Split(' ');

                // Girdi kontrolü: her satırda N eleman olmalı
                if (satir.Length != N)
                {
                    Console.WriteLine("Hatalı giriş. Her satırda " + N + " adet değer olmalıdır.");
                    return;
                }

                for (int j = 0; j < N; j++)
                {
                    labirent[i, j] = int.Parse(satir[j]);

                    // Geçerli değerlerin sadece 0 veya 1 olduğunu kontrol et
                    if (labirent[i, j] != 0 && labirent[i, j] != 1)
                    {
                        Console.WriteLine("Hatalı giriş. Sadece 0 veya 1 değeri kullanılmalıdır.");
                        return;
                    }
                }
            }

            // En kısa yolu bul ve sonucu yazdır
            int sonuc = EnKisaYoluBul(labirent, N);
            if (sonuc == -1)
            {
                Console.WriteLine("Yol Yok");
            }
            else
            {
                Console.WriteLine("En Kısa Yol: " + sonuc + " adım");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }

        // Programın kapanmaması için kullanıcıdan bir tuşa basmasını bekle
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }

    // Hücre bilgisini tutan sınıf
    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Adim { get; set; }

        public Cell(int row, int col, int adim)
        {
            Row = row;
            Col = col;
            Adim = adim;
        }
    }

    // En kısa yolu bulma fonksiyonu
    static int EnKisaYoluBul(int[,] labirent, int N)
    {
        // Eğer başlangıç veya bitiş noktası 1 değilse, hazineye ulaşılamaz
        if (labirent[0, 0] == 0 || labirent[N - 1, N - 1] == 0)
        {
            return -1; // Yol Yok
        }

        // Kuyruk (sıra) yapısı, hücre konumu ve adım sayısını tutar
        Queue<Cell> kuyruk = new Queue<Cell>();
        // Ziyaret edilen hücreler için matrisi oluştur
        bool[,] ziyaretEdildi = new bool[N, N];

        // Başlangıç noktasını kuyruğa ekle ve işaretle
        kuyruk.Enqueue(new Cell(0, 0, 1));
        ziyaretEdildi[0, 0] = true;

        // Kuyruk boşalana kadar veya hedefe ulaşılana kadar devam et
        while (kuyruk.Count > 0)
        {
            Cell mevcut = kuyruk.Dequeue();

            // Eğer hedef hücreye ulaşıldıysa, adım sayısını döndür
            if (mevcut.Row == N - 1 && mevcut.Col == N - 1)
            {
                return mevcut.Adim;
            }

            // Dört yönü kontrol et (Yukarı, Aşağı, Sol, Sağ)
            for (int i = 0; i < 4; i++)
            {
                int yeniSatir = mevcut.Row + rowDirection[i];
                int yeniSutun = mevcut.Col + colDirection[i];

                // Yeni konumun geçerli olup olmadığını kontrol et
                if (yeniSatir >= 0 && yeniSatir < N && yeniSutun >= 0 && yeniSutun < N &&
                    labirent[yeniSatir, yeniSutun] == 1 && !ziyaretEdildi[yeniSatir, yeniSutun])
                {
                    // Yeni konumu kuyruğa ekle ve işaretle
                    kuyruk.Enqueue(new Cell(yeniSatir, yeniSutun, mevcut.Adim + 1));
                    ziyaretEdildi[yeniSatir, yeniSutun] = true;
                }
            }
        }

        // Kuyruk boşaldı ve hedefe ulaşılamadıysa "Yol Yok"
        return -1;
    }
}
