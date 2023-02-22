using UnityEngine;

namespace GameAssets.Scripts.Upgrades
{
    public class WorkerUpgrade : MonoBehaviour
    {
        [SerializeField] private GameObject workerPrefab;
        [SerializeField] private float upgradeCost = 200;
    
        public void AddWorker()
        {
            if (MoneySingleton.Instance.currentMoney.Value > upgradeCost)
            {
                MoneySingleton.Instance.currentMoney.Value -= upgradeCost;
                Instantiate(workerPrefab, new Vector3(Random.Range(5,-5), 0.6f, Random.Range(-25,-30)), Quaternion.Euler(0,Random.Range(0,360), 0));
            }
            
        }
    }
}
