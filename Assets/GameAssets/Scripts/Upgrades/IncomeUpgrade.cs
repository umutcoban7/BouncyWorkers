using UnityEngine;

namespace GameAssets.Scripts.Upgrades
{
    public class IncomeUpgrade : MonoBehaviour
    {
        public void IncreasePassiveIncome()
        {
            MoneySingleton.Instance.passiveIncome++;
        }
    }
}
