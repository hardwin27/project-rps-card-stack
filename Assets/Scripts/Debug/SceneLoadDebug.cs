using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HaruEru.Debugger
{
    public class SceneLoadDebug : MonoBehaviour
    {
        [SerializeField] private KeyCode _reloadSceneKey;
        
        void Update()
        {
            if (Input.GetKeyDown(_reloadSceneKey))
            {
                ReloadScene();
            }
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
