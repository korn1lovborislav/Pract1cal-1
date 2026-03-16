using System;

namespace GameDamageSystem
{
    public class GameLogger
    {
        public void OnHealthChanged(int health)
        {
            Console.WriteLine($"[Logger] Запис у лог: Поточне HP = {health}");
        }
    }
}