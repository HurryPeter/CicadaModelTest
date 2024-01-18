using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Frequencies")]
    public AudioClip lowFreq;
    public AudioClip midFreq;
    public AudioClip highFreq;

    [Header("Resonated")]
    public AudioClip doorSound;
    public AudioClip frogLights;
    public AudioClip enemySound;
    public AudioClip success;
}
