using UnityEngine;

namespace GameAssets.Scripts.Upgrades
{
    public class SpeedUpgrade : MonoBehaviour
    {
        [SerializeField] private float upgradeCost = 200;
        public void IncreaseWorkerSpeed()
        {
            if (MoneySingleton.Instance.currentMoney.Value > upgradeCost)
            {
                MoneySingleton.Instance.currentMoney.Value -= upgradeCost;
                SpeedSingleton.Instance.speed.Value++;
            }
        }
    }
}
