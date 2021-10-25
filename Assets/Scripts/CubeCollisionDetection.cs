using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeCollisionDetection : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacles"))
            {
                CubesContainer.Instance.RemovedList(gameObject.transform);
                _rigidbody.isKinematic = true;
                transform.parent = null;
                Destroy(gameObject, 4f);

            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Lava"))
            {
                CubesContainer.Instance.RemovedList(gameObject.transform);
                Destroy(gameObject);
            }
        }
    }
}

