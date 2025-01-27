using System;

namespace _Game.Scripts.Components
{
    public class Health
    {
        private readonly int _maxValue;
        private int _currentValue;

        public Health(int initialValue)
        {
            _maxValue = initialValue;
            _currentValue = _maxValue;
        }

        public int CurrentValue => _currentValue;

        public event Action<int> Changed;
        public event Action Died;
        
        public void Reset()
        {
            _currentValue = _maxValue;
            Changed?.Invoke(_currentValue);
        }

        public void TakeDamage(int damage)
        {
            switch (damage)
            {
                case < 0:
                    throw new ArgumentException("Damage cannot be negative");
                case 0:
                    return;
            }

            _currentValue -= damage;
            
            if (_currentValue <= 0)
            {
                _currentValue = 0;
                Died?.Invoke();
            }
            
            Changed?.Invoke(_currentValue);
        }

        public void TakeHeal(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Heal cannot be negative and zero");

            _currentValue += value;

            if (_currentValue > _maxValue)
                _currentValue = _maxValue;

            Changed?.Invoke(_currentValue);
        }
    }
}