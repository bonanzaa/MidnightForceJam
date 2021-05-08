using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PigeonHealth : MonoBehaviour
{
    public Animator Animation;
    public int Health = 3;
    public bool _canTakeDamage = true;
    private AudioSource squack;

    public void Awake()
    {
        squack = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void TakeDamage()
    {
        if (_canTakeDamage)
        {
            squack.Play();
            Health--;
            Debug.Log(Health);
            Animation.SetBool("Hit", true); // ADD NEW ANIMATION AND ANIMATOR, TRANSITION FOR FLASHING HIT = TRUE
            _canTakeDamage = false;
            StartCoroutine(Flashing(1f));
        }
    }
    public IEnumerator Flashing(float duration)
    {
        while (duration > 0)
        {
            yield return null;
            duration -= Time.deltaTime;
        }
        Animation.SetBool("Hit", false); //TRANSITION FOR FLASHING HIT = FALSE
        _canTakeDamage = true;
    }
}
