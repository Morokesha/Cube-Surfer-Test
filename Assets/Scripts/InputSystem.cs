using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer
{
    public class InputSystem : MonoBehaviour
    {
        private float _lastFramePosX;
        private float _movementX;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFramePosX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _movementX = Input.mousePosition.x - _lastFramePosX;
                _lastFramePosX = Input.mousePosition.x;
            }
            else
            {
                _movementX = 0;
            }
        }

        public float GetovementX()
        {
            return _movementX;
        }
    }
}

