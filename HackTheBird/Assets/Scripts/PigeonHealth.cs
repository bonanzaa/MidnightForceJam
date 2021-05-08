using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpriteGlow;

public class PigeonHealth : MonoBehaviour
{
    public Animator Animation;
    public int Health = 3;
    public bool _canTakeDamage = true;
    private AudioSource squack;


    public List<GameObject> HealthList;

    public void Awake()
    {
        squack = GetComponent<AudioSource>();
    }

    private void Start() {
        
    }
    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene(4);
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
            StartCoroutine(Flashing(2f));
            HealthList[Health].gameObject.SetActive(false);
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

    public void BuffVisualActive(SpriteGlowEffect glow){

        glow.GlowColor = new Color(0,1,0,255);
        glow.GlowBrightness = 0.190f;}

    public void RemoveBuffVisual(Color oldColor, float oldBrightness, SpriteGlowEffect glow){
        glow.GlowColor = oldColor;
        glow.GlowBrightness = oldBrightness;

    }

    public IEnumerator BuffTimerForFireRate(float oldFR, Color oldColor, float oldBrightness, SpriteGlowEffect glow){
            yield return new WaitForSeconds(3);
            RemoveBuffVisual(oldColor, oldBrightness, glow);

        
    }
}
