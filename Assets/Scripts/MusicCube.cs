using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MusicCube : MonoBehaviour
{
    private AudioSource audioSource;
    public int scoreIndex; 
    public float totalPlayTime = 0.0f;

    private float m_LastStartTime;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{audioSource.clip.name} - OnTriggerEnter: {other.GetType().ToString()} - {totalPlayTime.ToString()}");
        if (other.GetType() != typeof(BoxCollider) && !audioSource.isPlaying)
        {
            m_LastStartTime = Time.time;
            audioSource.Play();
            
            ScoreBehavior.AddScore(scoreIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{audioSource.clip.name} - OnTriggerExit: {other.GetType().ToString()} - {totalPlayTime.ToString()}");
        if (other.GetType() != typeof(BoxCollider))
        {
            totalPlayTime += Time.time - m_LastStartTime;
            audioSource.Stop();
            
            ScoreBehavior.AddScore(scoreIndex);
        }
    }
}