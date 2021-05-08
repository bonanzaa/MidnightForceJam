using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class ExpositionWriter : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _SFX;
        [SerializeField]
        private TextMeshProUGUI analisysText;
        [SerializeField]
        private float charDelay = .05f;
        [SerializeField]
        private string targetText =
            "Hello friend,\n" +
            "\n" +
            "\n" +
            "Thank you for reaching out to us,\n" +
            "your skillset would be of great use in our struggle\n" +
            "\n" +
            "\n" +
            "your first task will be to 'repossess' one of the street drones and deliver it back to our lab.\n" +
            "watch out, the second you hack it the rest of the flock will be on high allert.\n" +
            "\n" +
            "happy hunting... \n"; 
           

        private int charIndex = 0;
        private float timer = 0;

        [SerializeField]
        private Button button;

        [HideInInspector]
        public bool WriteComplete = false;

        private void Awake()
        {
            StartCoroutine(JuicyWrite(analisysText, targetText, charDelay));
        }

        private void Update()
        {
            if (WriteComplete)
            {
                button.gameObject.SetActive(true);
            }
        }

        IEnumerator JuicyWrite(TextMeshProUGUI uiText, string targetText, float charDelay)
        {
            while (charIndex < targetText.Length)
            {
                WriteComplete = false;
                string text = targetText.Substring(0, charIndex);
                charIndex++;
                uiText.text = text;
                _SFX.Play();
                yield return new WaitForSeconds(charDelay);
                if (charIndex >= targetText.Length)
                {
                    WriteComplete = true;
                    yield return null;
                }
            }


        }

    }
}
