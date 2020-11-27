using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public float speed = 2f;
    public float GOAL_ACCURACY = 0.1f;
    public Transform goal; //position in env

    void LateUpdate() //after physics is calculated
    {
        this.transform.LookAt(goal.position);

        //where to - current pos = vector in straight path to destinaton
        Vector3 direction = goal.position - this.transform.position;
        Debug.DrawRay(this.transform.position, direction, Color.red);
        if (direction.magnitude > GOAL_ACCURACY)
        {
            //"smoother" updates using deltaTime
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    public void Stun()
    {
        StartCoroutine(ReduceSpeedForDuration(7f));
    }

    private IEnumerator ReduceSpeedForDuration(float waitTime)
    {
        speed /= 2f;
        print("Coroutine started.");
        yield return new WaitForSeconds(waitTime);
        print("Coroutine ended: " + Time.time + " seconds");
        speed *= 2f;
    }
}