using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer
{
    public class CollectorCube : MonoBehaviour
    {
        public event Action OnAddedCube;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out TriggerCube triggerCube))
            {
                OnAddedCube?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}

