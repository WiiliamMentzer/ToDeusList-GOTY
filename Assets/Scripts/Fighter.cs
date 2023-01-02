using System;
using UnityEngine;

namespace BattleCore
{
    [CreateAssetMenu]
    public class Fighter : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private Color _color;
        // [SerializeField] private SpellBook _spellbook;
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _totalHealth;
        [SerializeField] private int _attack;
        [SerializeField] private int _healing;

        [SerializeField] private int _burningTimer;

        [SerializeField] private int _enrageTimer;

        [SerializeField] private int _currentMana;

        [SerializeField] private int _totalMana;

        public string Name => _name;
        public int Level => _level;
        public Color Color => _color;
        // public SpellBook SpellBook => _spellbook;
        public int CurrentHealth => _currentHealth;
        public int TotalHealth => _totalHealth;
        public int Attack => _attack;
        public int Healing => _healing;
        public int Burning => _burningTimer;
        public int Enrage => _enrageTimer;
        public int CurrentMana => _currentMana;

        public int TotalMana => _totalMana;

        public bool Damage(int amount)
        {
            _currentHealth = Math.Max(0, _currentHealth - amount);
            return _currentHealth == 0;
        }
        public void ApplyBurn()
        {
            _burningTimer = 3;
        }

        public void ApplyEnrage(int amount)
        {
            _enrageTimer = amount;
        }

        public void EnrageReduction(int amount)
        {
            _enrageTimer -= amount;
            if (_enrageTimer < 0){
                _enrageTimer = 0;
            }
        }


        public void BurnReduction(int amount)
        {
            _burningTimer -= amount;

            if (_burningTimer < 0){
                _burningTimer = 0;
            }
        }

        public void Heal(int amount, int manaAmount)
        {
            _currentHealth += amount;

            _currentMana += 10;

            if (_currentHealth > _totalHealth){
                _currentHealth = _totalHealth;
            }
            if (_currentMana > _totalMana){
                _currentMana = _totalMana;
            }
        }

        public void HealBurn(){
            _burningTimer = 0;

            _currentMana -= 10;
        }

        public void CastSpell(int amount)
        {
                _currentMana -= amount;
        }

        public void StatReset()
        {
            _currentHealth = _totalHealth;
            _currentMana = _totalMana;
            _burningTimer = 0;
        }

        public void ManaReset()
        {
            _currentMana = _totalMana;
        }

        private void OnValidate()
        {
            _currentHealth = Math.Min(_currentHealth, _totalHealth);
        }
    }
}