using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    private string originaleTexte;
    private Text uiText;
    public float delay = 0.05f;
    AudioSource audioSource;
    [SerializeField] GameObject skipText;
    [SerializeField] GameObject continueText;
    [SerializeField] GameObject Main;
    bool isFinished = false;
    private void Awake()
    {
        uiText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        originaleTexte = uiText.text;
        uiText.text = null;
        StartCoroutine(ShowLetterByLetter());
    }

    IEnumerator ShowLetterByLetter()
    {
        for (int i = 0; i < originaleTexte.Length; i++)
        {
            skipText.SetActive(true);
            
            if (Input.GetKey(KeyCode.Space))
            {
                uiText.text = originaleTexte;
                break;
            }
            
            uiText.text = originaleTexte.Substring(0, i + 1);

            if (originaleTexte[i] != ' ')
            {
                audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                audioSource.Play();
            }
            yield return new WaitForSeconds(delay);
        }
        
        skipText.SetActive(false);
        continueText.SetActive(true);
        isFinished = true;
    }

    private void Update()
    {
        if (isFinished && Input.GetButton("Use"))
        { 
            Main.SetActive(false);
        }
    }
}
