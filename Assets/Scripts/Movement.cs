using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _swipeSpeedX;
        private InputSystem _inputSystem;
       
        private float _swipeX;
        private float _borderSwipeX = 2.0f;

        private void Start()
        {
            _inputSystem = GetComponent<InputSystem>();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (GameManager.Instance.state == GameManager.State.Movement)
            {
                _swipeX = _swipeSpeedX * _inputSystem.GetovementX() * Time.deltaTime;
                Vector3 localPosX = new Vector3(Mathf.Clamp(transform.localPosition.x + _swipeX, -_borderSwipeX, _borderSwipeX), transform.localPosition.y, 0);
                transform.localPosition = localPosX;
            }            
        }
    }
}

