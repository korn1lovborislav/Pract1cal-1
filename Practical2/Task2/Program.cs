using System;
using System.Numerics;
using System.Text;

namespace GameDamageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== ІГРОВА СИСТЕМА ОТРИМАННЯ УРОНУ ===\n");

            Player player = new Player(100);
            UIHealthBar ui = new UIHealthBar();
            SoundSystem sound = new SoundSystem();
            AchievementSystem achievements = new AchievementSystem();
            GameLogger logger = new GameLogger();

            player.HealthChanged += ui.OnHealthChanged;
            player.HealthChanged += sound.OnHealthChanged;
            player.HealthChanged += achievements.OnHealthChanged;
            player.HealthChanged += logger.OnHealthChanged;

            Console.WriteLine("1. Наносимо 30 урону:\n");
            player.TakeDamage(30);

            Console.WriteLine("\n2. Наносимо 25 урону:\n");
            player.TakeDamage(25);

            Console.WriteLine("\n3. Наносимо 20 урону:\n");
            player.TakeDamage(20);

            Console.WriteLine("\n4. Наносимо 15 урону:\n");
            player.TakeDamage(15);

            Console.WriteLine("\n5. Наносимо 10 урону (фінальний):\n");
            player.TakeDamage(10);

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}