using UnityEngine;
using UnityEngine.UI;

namespace BattleCore
{
    public class Nameplate : MonoBehaviour
    {
        [SerializeField] private Text nameLabel;
        [SerializeField] private Text levelLabel;
        [SerializeField] private Text healthExactLabel;

        [SerializeField] private Image fillHealthImage;

        [SerializeField] private Image fillManaImage;

        [SerializeField] private Text manaExactLabel;

        private Fighter _fighter;

        public void Initialize(Fighter fighter)
        {
            _fighter = fighter;
            nameLabel.text = _fighter.Name;
            levelLabel.text = _fighter.Level.ToString();
            healthExactLabel.text = $"{_fighter.CurrentHealth.ToString()} / {_fighter.TotalHealth.ToString()}";
            manaExactLabel.text = $"{_fighter.CurrentMana.ToString()} / {_fighter.TotalMana.ToString()}";
        }

        public void Update()
        {
            UpdateHealthBar();
            UpdateManaBar();
        }
        
        private void UpdateHealthBar()
        {
            if (_fighter.CurrentHealth == 0)
            {
                fillHealthImage.fillAmount = 0;
            }
            else
            {
                fillHealthImage.fillAmount = (float) _fighter.CurrentHealth / _fighter.TotalHealth;
                healthExactLabel.text = $"{_fighter.CurrentHealth.ToString()} / {_fighter.TotalHealth.ToString()}";
            }
        }
        private void UpdateManaBar()
        {
            if (_fighter.CurrentMana == 0)
            {
                fillManaImage.fillAmount = 0;
            }
            else
            {
                fillManaImage.fillAmount = (float) _fighter.CurrentMana / _fighter.TotalMana;
                manaExactLabel.text = $"{_fighter.CurrentMana.ToString()} / {_fighter.TotalMana.ToString()}";
            }
        }
        
    }
}