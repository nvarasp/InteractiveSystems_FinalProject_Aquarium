using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroupFishes : MonoBehaviour
{
    public globalFlock GetFlock;    // Get Flock
    public GameObject Manager;      // Manager
    public GameObject Destroyer;    // Destroyer

    // When nose collide destroy banc
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("nose"))
        {
            if(Destroyer.GetComponent<BancDestroy> ()!=null)
            {
                Destroyer.GetComponent<BancDestroy>().Actualize_List();
                if(Destroyer.GetComponent<BancDestroy>().Manager_List.Length <1)
                {
                    Instantiate(Manager,new Vector3(0,0,0),Quaternion.identity);
                    Destroyer.GetComponent<BancDestroy>().Actualize_List();
                }
            }
        }
    }
}
