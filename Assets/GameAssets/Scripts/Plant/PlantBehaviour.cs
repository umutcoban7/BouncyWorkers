using Unity.Collections;
using UnityEngine;

namespace GameAssets.Scripts.Plant
{
    class PlantBehaviour : MonoBehaviour
    {
        private MeshRenderer plantMesh;
        [ReadOnly] private bool isInHarvestMode = false;
        [ReadOnly] private bool isGrown = false;

        private void Awake()
        {
            plantMesh = GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(isInHarvestMode)
                Harvest(other);
            else
                Grow(other);
        }

        private void Grow(Collider other)
        {
            if (other.gameObject.CompareTag("Worker") && !isGrown)
            {
                plantMesh.enabled = true;
                isGrown = true;
                
                MoneySingleton.Instance.currentMoney.Value++;
            }
        }

        private void Harvest(Collider other)
        {
            if (other.gameObject.CompareTag("Worker") && isGrown)
            {
                plantMesh.enabled = false;
                isGrown = false;
                
                MoneySingleton.Instance.currentMoney.Value++;
            }
        }
    }
}
