using TMPro;
using UniRx;
using Unity.Collections;
using UnityEngine;

namespace GameAssets.Scripts.UI
{
    public class MoneyDisplay : MonoBehaviour
    {
        [ReadOnly] private TextMeshProUGUI moneyText;
        private float currentMoney;
        private void Awake()
        {
            moneyText = GetComponent<TextMeshProUGUI>();
            
        }

        private void Start()
        {
            currentMoney = MoneySingleton.Instance.currentMoney.Value;
            UpdateDisplayOnMoneyChange();
        }

        private void UpdateDisplayOnMoneyChange()
        {
            MoneySingleton.Instance.currentMoney.Subscribe(newMoney =>
            {
                currentMoney = newMoney;
                moneyText.text = "Money: " + currentMoney;
            }).AddTo(gameObject);
        }
        
    }
}
