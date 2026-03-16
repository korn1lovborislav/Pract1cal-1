using System;

namespace GameDamageSystem
{
    public class AchievementSystem
    {
        private bool _halfHealthAchievement = false;
        private bool _deathAchievement = false;

        public void OnHealthChanged(int health)
        {
            if (health <= 50 && health > 0 && !_halfHealthAchievement)
            {
                Console.WriteLine($"[Achievement] Отримано досягнення: 'Half Health' (50 HP)");
                _halfHealthAchievement = true;
            }

            if (health <= 0 && !_deathAchievement)
            {
                Console.WriteLine($"[Achievement] Отримано досягнення: 'First Death'");
                _deathAchievement = true;
            }
        }
    }
}