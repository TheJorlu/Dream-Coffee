using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(AudioSource))]
public class SoundEffector : MonoBehaviour
{
    [System.Serializable]
    public struct SoundInfo
    {
        public string name;
        public AudioClip clip;
    }

    public SoundInfo[] clips;

    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    [YarnCommand("callAudio")]
    public void CallAudio(string audioName)
    {
        AudioClip a = null;
        foreach (var info in clips)
        {
            if (info.name == audioName)
            {
                a = info.clip;
                break;
            }
        }

        if (a == null)
        {
            Debug.LogErrorFormat("Can't find audioClip named {0}!", audioName);
            return;
        }

        audioSrc.PlayOneShot(a);
    }
}
