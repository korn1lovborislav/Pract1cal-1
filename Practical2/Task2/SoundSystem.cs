using System;

namespace GameDamageSystem
{
    public class SoundSystem
    {
        public void OnHealthChanged(int health)
        {
            Console.WriteLine($"[Sound] Відтворено звук отримання урону");

            if (health <= 20 && health > 0)
            {
                Console.WriteLine($"[Sound] Відтворено звук КРИТИЧНОГО СТАНУ! HP: {health}");
            }
        }
    }
}