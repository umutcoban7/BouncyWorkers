using UniRx;
using UnityEngine;

namespace GameAssets.Scripts.Worker
{
    public class WorkerMovement : MonoBehaviour
    {
        private Rigidbody workerRb;
        private Vector3 lastVelocity;
        public float speed;
    
        private void Awake()
        {
            workerRb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            speed = SpeedSingleton.Instance.speed.Value;
            UpdateSpeed();
            AddInitialSpeed();
        }

        private void FixedUpdate()
        {
            lastVelocity = workerRb.velocity;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            Bounce(collision);
        }
        
        private void AddInitialSpeed()
        {
            workerRb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        private void Bounce(Collision collision)
        {
            if(collision.gameObject.CompareTag($"Wall") || collision.gameObject.CompareTag($"Worker"))
            {
                var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
                workerRb.velocity = direction * speed;
            }
        }
        private void UpdateSpeed()
        {
            SpeedSingleton.Instance.speed.Subscribe(newSpeed =>
            {
                speed = newSpeed;
                workerRb.velocity = workerRb.velocity.normalized * speed;
            }).AddTo(gameObject);
        }
        
    }
}
