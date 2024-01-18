using JetBrains.Annotations;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoBehavior : MonoBehaviour
{
    public enum FreqRange { high, medium, low};
    public FreqRange setFreq;
    public GameObject prefab;
    public Animator anim;
    public bool blip, isActivated = false;
    public AudioSource AudioSource, playerAudSource;
    public AudioManager AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        AudioManager = GameObject.Find("Manager/Player").GetComponent<AudioManager>();
        playerAudSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SonarBehavior sonarBehavior;
        float curFreq;

        sonarBehavior = other.GetComponent<SonarBehavior>();
        curFreq = sonarBehavior.curFreq;
        Debug.Log("hit, frequency is"+curFreq);


        if (setFreq == FreqRange.high&&isActivated==false)
        {
            if(AudioSource.isPlaying==false)
            { 
                AudioSource.PlayOneShot(AudioManager.highFreq);
            }
            if(curFreq>=20f)
            {
                SetInteractable();
                isActivated = true;
            }

        }
        else if (setFreq == FreqRange.medium && isActivated == false)
        {
            if (AudioSource.isPlaying == false)
            {
                AudioSource.PlayOneShot(AudioManager.midFreq);
            }
            if (curFreq>=10f)
            {
                SetInteractable();
                isActivated = true;
            }
        }
        else if (setFreq == FreqRange.low && isActivated == false)
        {
            if (AudioSource.isPlaying == false)
            {
                AudioSource.PlayOneShot(AudioManager.lowFreq);
            }
            if (curFreq >= 5f)
            {
                SetInteractable();
                isActivated = true;
            }
        }


    }

    void SetInteractable()
    {
        if(transform.gameObject.CompareTag("Light"))
        {
            anim.CrossFade("Glow", 0f);
            AudioSource.PlayOneShot(AudioManager.frogLights);
            playerAudSource.PlayOneShot(AudioManager.success);
           
        }

        if(transform.gameObject.CompareTag("Door"))
        {
            anim.CrossFade("Open", 0f);
            AudioSource.PlayOneShot(AudioManager.doorSound);
            playerAudSource.PlayOneShot(AudioManager.success);
        }

        if (transform.gameObject.CompareTag("Enemy"))
        {
            anim.CrossFade("EnemyGlow", 0f);
            AudioSource.PlayOneShot(AudioManager.enemySound);
            playerAudSource.PlayOneShot(AudioManager.success);
        }
    }
}
