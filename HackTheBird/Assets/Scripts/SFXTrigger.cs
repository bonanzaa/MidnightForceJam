using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class SFXTrigger : MonoBehaviour
    {
        private AudioSource clip;

        private void Awake()
        {
            clip = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayClip();
            }
        }
        private void PlayClip()
        {
            clip.Play();
        }
    }
}
