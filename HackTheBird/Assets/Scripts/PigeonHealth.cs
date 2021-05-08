using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PigeonHealth : MonoBehaviour
{
    public int Health = 3;

    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void TakeDamage()
    {
        Health--;
        Debug.Log(Health);
    }
}
