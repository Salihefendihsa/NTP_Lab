using System;
using System.Collections.Generic;

class Program
{
    static int[] dx = { -1, 1, 0, 0 }; // Yönler (yukarı, aşağı, sağ, sol)
    static int[] dy = { 0, 0, -1, 1 };
    static int N;

    // BFS yöntemi ile kurtarılan düğümleri say
    static int BFS(int[,] grid, bool[,] visited, int startX, int startY)
    {
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(Tuple.Create(startX, startY));
        visited[startX, startY] = true;
        int count = 1; // Başlangıç düğümü kurtarıldı

        while (queue.Count > 0)
        {
            var position = queue.Dequeue();
            int x = position.Item1;
            int y = position.Item2;

            // 4 komşu yönü kontrol et
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (newX >= 0 && newY >= 0 && newX < N && newY < N && grid[newX, newY] == 1 && !visited[newX, newY])
                {
                    visited[newX, newY] = true;
                    queue.Enqueue(Tuple.Create(newX, newY));
                    count++;
                }
            }
        }

        return count;
    }

    // Robotların kurtardığı düğümleri hesapla
    static List<int> MaxSavedNodes(int[,] grid, List<Tuple<int, int>> robotStartPositions)
    {
        N = grid.GetLength(0);
        bool[,] globalVisited = new bool[N, N]; // Tüm robotlar için global ziyaret durumu
        List<int> savedByEachRobot = new List<int>();

        foreach (var startPosition in robotStartPositions)
        {
            int startX = startPosition.Item1;
            int startY = startPosition.Item2;

            // Robotun başlangıç pozisyonu temizse ve daha önce ziyaret edilmemişse
            if (grid[startX, startY] == 1 && !globalVisited[startX, startY])
            {
                // Sadece globalVisited matrisini kullanarak düğümleri ziyaret ediyoruz
                int saved = BFS(grid, globalVisited, startX, startY);
                savedByEachRobot.Add(saved);
            }
            else
            {
                savedByEachRobot.Add(0); // Eğer robot başlangıç pozisyonu zarar görmüşse veya daha önce ziyaret edildiyse
            }
        }

        return savedByEachRobot;
    }

    static void Main(string[] args)
    {
        // Grid'i düzeltiyoruz
        int[,] grid = {
            { 1, 1, 0, 1 },
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 1, 1 }
        };

        // Robotların başlangıç pozisyonları
        List<Tuple<int, int>> robotStartPositions = new List<Tuple<int, int>>()
        {
            Tuple.Create(0, 0), // Robot 1
            Tuple.Create(2, 2), // Robot 2
            Tuple.Create(3, 3)  // Robot 3
        };

        List<int> result = MaxSavedNodes(grid, robotStartPositions);

        int totalSaved = 0;
        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine("Robot " + (i + 1) + " kurtardığı düğüm sayısı: " + result[i]);
            totalSaved += result[i];
        }

        Console.WriteLine("Toplam kurtarılan düğüm sayısı: " + totalSaved);

        // Konsol ekranının kapanmaması için
        Console.ReadLine();
    }
}
