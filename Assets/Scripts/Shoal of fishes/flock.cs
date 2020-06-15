using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flock : MonoBehaviour
{
    public float speed ;

    float rotSpeed = 3.0f;              // Rotation Speed
    Vector3 averageHeading;             // Average Heading
    Vector3 averagePosition;            // Averages position
    float neighbourDistance = 500.0f;   // Distance between fishes
    bool turning = false;               // Set to true when the fish reaches the edge of the tank

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speed,70f); // Setting for speed
    }

    // Update is called once per frame
    void Update()
    {   
        if(Vector3.Distance(transform.position, Vector3.zero)>= globalFlock.tankSize)
        {
            turning = true;
        }
        else // If not outside the tank, apply the rules
            turning = false;
        
        if(turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,   
                                                   Quaternion.LookRotation(direction),
                                                   rotSpeed*Time.deltaTime);
            speed = Random.Range(speed,70f);
        }
        else
        {
            if(Random.Range(0,5)<1) // Number of times the rules are applyied
            {   
                ApplyRules();
            }   
        }
        transform.Translate(0,0,Time.deltaTime * speed);
    }

    // Function to apply the rules to the Banc
    void ApplyRules(){
        GameObject[] gos;
        gos = globalFlock.allFish;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 6f;                // Group speed

        Vector3 goalPos = globalFlock.goalPos;
        float dist;
        int groupSize = 0;

        foreach(GameObject go in gos)
        {
            if(go!= this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position,this.transform.position);
                if(dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if(dist<1.0f){ //if the fish is very close to the group
                        vavoid = vavoid+ (this.transform.position - go.transform.position);
                    }
                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize>0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp ( transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        rotSpeed * Time.deltaTime);
            }
        }
    }
}
