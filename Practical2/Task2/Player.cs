using System;

namespace GameDamageSystem
{
    public class Player
    {
        private int _health;
        public event Action<int> HealthChanged;

        public int Health
        {
            get { return _health; }
            private set
            {
                if (_health != value)
                {
                    _health = value;
                    HealthChanged?.Invoke(_health);
                }
            }
        }

        public Player(int startHealth)
        {
            _health = startHealth;
        }

        public void TakeDamage(int damage)
        {
            int oldHealth = Health;
            Health = Math.Max(0, Health - damage);
            Console.WriteLine($"\n[Player] Отримано урон: {damage}. HP: {oldHealth} → {Health}");
        }
    }
}