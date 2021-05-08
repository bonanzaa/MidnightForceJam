using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class BestButton : MonoBehaviour
    {
        
        public void StartNextScene()
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void GuitGame()
        {
            Application.Quit();
        }

        public void NewRun()
        {
            SceneManager.LoadScene(2);
        }
    }
}
