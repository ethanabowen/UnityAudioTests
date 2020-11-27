﻿using UnityEngine;
 
/// <summary>
/// The class definition for a projectile's trigger
/// </summary>
/// <remarks>
/// Attach this script as a component to any object capable of triggering projectiles
/// The spawn transform should represent the position where the projectile is to appear, i.e. gun barrel end
/// </remarks>
public class ProjectileTrigger : MonoBehaviour
{
    /// <summary>
    /// Public fields
    /// </summary>
    public GameObject m_Projectile;    // this is a reference to your projectile prefab
    public Transform m_SpawnTransform; // this is a reference to the transform where the prefab will spawn
 
    /// <summary>
    /// Message that is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            Instantiate(m_Projectile, m_SpawnTransform.position, m_SpawnTransform.rotation);
        }
    }
}