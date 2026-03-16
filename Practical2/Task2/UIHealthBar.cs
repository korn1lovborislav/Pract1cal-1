using System;

namespace GameDamageSystem
{
    public class UIHealthBar
    {
        public void OnHealthChanged(int health)
        {
            Console.WriteLine($"[UI] Шкала здоров'я оновлено: {health} HP");
        }
    }
}