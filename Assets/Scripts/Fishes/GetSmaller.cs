using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSmaller : MonoBehaviour
{
    private Collider myCollider;    // Collider
    private Rigidbody myRigidbody;  // RigidBody
    private bool touch;             // bool var to know when fish has been touched
    public float maxSize;           // maximum size
    public float growFactor;        // Factor of grouth
    public float waitTime;          // Wait time to get fish to normality
    public GameObject armR;         // Right Arm
    public GameObject armL;         // Left Arm

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] arms_list = GameObject.FindGameObjectsWithTag("Arm");  // List with arms

        if (arms_list.Length > 2)
        {
            Debug.Log("Failed loading arms!");
        }

        armR = arms_list[0];
        armL = arms_list[1];
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
        touch = false;
    }

    // When arms touch fish
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arm") && touch == false)
        {
            float arm_dif_x = armL.transform.position.x - armR.transform.position.x; //Compute the distances between the arms
            if(arm_dif_x < 0){
                arm_dif_x = (-1)*arm_dif_x;
            }

            float arm_dif_y = armL.transform.position.y - armR.transform.position.y;
            if(arm_dif_y < 0){
                arm_dif_y = (-1)*arm_dif_y;
            }

            // If fish touched with the two arms change size
            if(arm_dif_x< 200 && arm_dif_y < 200)
            {
                touch = true;
                StartCoroutine(Scale());
            }
        }
    }

    // Functon to change fish size
    IEnumerator Scale()
    {
        float timer = 0;

        while (touch)
        {
            // Decrease size
            while (maxSize < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime); // Wait waitTime and increase
            timer = 0;  // Reset timer

            // Increase size
            while (1 > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            touch = false;
            yield return new WaitForSeconds(waitTime);
        }
    }
}

