using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CubeSurfer
{
    public class RestartBtnUI : MonoBehaviour
    {
        [SerializeField] private CollectorCube _collectorCube;

        private Button _restartBtn;
        private void Start()
        {
            _restartBtn = GetComponent<Button>();
            _restartBtn.gameObject.SetActive(false);
            CubesContainer.Instance.OnListEmpty += RestartLevel;
        }

        private void OnDisable()
        {
            CubesContainer.Instance.OnListEmpty -= RestartLevel;
        }

        private void RestartLevel()
        {
            _restartBtn.gameObject.SetActive(true);
            _restartBtn.onClick.AddListener(() => { SceneManager.LoadScene(0); });
        }        
    }
}

