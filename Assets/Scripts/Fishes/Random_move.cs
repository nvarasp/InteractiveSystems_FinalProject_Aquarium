using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_move : MonoBehaviour
 {
    public GameObject limLeft;      // Left limit
    public GameObject limRight;     // Right limit
    public GameObject limUp;        // Up limit
    public GameObject limDown;      // Down limit

    public float rotSpeed;          // Rotation speed
    public float movementDuration;  // Movement duration time
    public Vector3 target;          // Target
    public bool hasArrived = false; // bool var to know if fish has arrived

    // Start is called before the first frame update
    private void Start(){
        target = new Vector3(Random.Range(limLeft.transform.position.x,limRight.transform.position.x)
                                                      ,Random.Range(limDown.transform.position.y,limUp.transform.position.y),
                                                       Random.Range(-2,2));
        RotateMPC(target,movementDuration);                                             
    }

    // Update is called once per frame   
    private void Update()
    {
        if( Random.Range(0,1000)< 1 || hasArrived == true)
        {
            target = new Vector3(Random.Range(limLeft.transform.position.x,limRight.transform.position.x)
                                                      ,Random.Range(limDown.transform.position.y,limUp.transform.position.y),
                                                       Random.Range(-10, 10));
            hasArrived = false;
        }

        RotateMPC(target,movementDuration);

        transform.position = Vector3.MoveTowards(transform.position,target,movementDuration * Time.deltaTime);

        if( transform.position.Equals(target)){
            hasArrived = true;
        }
    
    }

    // Function to make the rotation movement
    private void RotateMPC(Vector3 direction, float currentSpeed)
    {
        Vector3 target = this.transform.position - direction;

        Quaternion qto = Quaternion.LookRotation(target);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.Slerp ( transform.rotation,
                                                        qto,
                                                        rotSpeed * Time.deltaTime);
    }
}