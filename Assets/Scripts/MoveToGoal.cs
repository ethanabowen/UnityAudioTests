using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour {

    public float speed = 2f;
    public float GOAL_ACCURACY = 0.1f;
    public Transform goal; //position in env
    void Start() {
        
    }

    void LateUpdate() //after physics is calculated
    {
        this.transform.LookAt(goal.position);

        //where to - current pos = vector in straight path to destinaton
        Vector3 direction = goal.position - this.transform.position;
        Debug.DrawRay(this.transform.position, direction, Color.red);
        if (direction.magnitude > GOAL_ACCURACY) {
            //"smoother" updates using deltaTime
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
