using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public Random_move rm;      // Random movement
    private float old_velocity; // Old speed

    // Start is called before the first frame update
    void Start()
    {
        old_velocity = rm.movementDuration;
        InvokeRepeating("Relax", 0f, 4f);
    }

    // Update is called once per frame   
    private void OnTriggerEnter (Collider other) // 1
    {
        if (other.CompareTag("Arm"))
        {
            rm.movementDuration = 300f;
            rm.target = (-1)*(this.transform.position - other.transform.position); 
        }
    }

    // Relas fish after speed up
    private void Relax(){
        rm.movementDuration = old_velocity;
    } 

}
