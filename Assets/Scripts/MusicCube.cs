using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MusicCube : MonoBehaviour
{
    private AudioSource audioSource;
    private MoveToGoal moveScript;
    public int scoreIndex; 
    public float totalPlayTime = 0.0f;

    private float m_LastStartTime;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        moveScript = gameObject.GetComponent<MoveToGoal>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{audioSource.clip.name} - OnTriggerEnter: {other.GetType().ToString()} - {totalPlayTime.ToString()}");
        if (other.GetType() == typeof(SphereCollider))
        {
            moveScript.Stun();
        } else if (other.GetType() != typeof(BoxCollider) && !audioSource.isPlaying)
        {
            m_LastStartTime = Time.time;
            audioSource.Play();
            
            ScoreBehavior.AddScore(scoreIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{audioSource.clip.name} - OnTriggerExit: {other.GetType().ToString()} - {totalPlayTime.ToString()}");
        if (other.GetType() != typeof(BoxCollider) && other.GetType() != typeof(SphereCollider))
        {
            totalPlayTime += Time.time - m_LastStartTime;
            audioSource.Stop();
            
            ScoreBehavior.AddScore(scoreIndex);
        }
    }
}