using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer
{
    public class GameManager : MonoBehaviour
    {
        #region Singlton
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        #endregion
        public enum State
        {
            Stand,
            Movement,
        }

        public State state;

        private bool _isStartGame;

        private void Start()
        {
            state = State.Stand;
            _isStartGame = true;
            CubesContainer.Instance.OnListEmpty += Instance_OnListEmpty;    
        }

        private void OnDisable()
        {
            CubesContainer.Instance.OnListEmpty -= Instance_OnListEmpty;
        }

        private void Instance_OnListEmpty()
        {
            state = State.Stand;
        }

        private void Update()
        {
            CheckToStartGame();
        }

        private void CheckToStartGame()
        {
            if (_isStartGame == true)
            {
                if (Input.GetMouseButton(0))
                {
                    state = State.Movement;
                    _isStartGame = false;
                }
            }
        }
    }
}

