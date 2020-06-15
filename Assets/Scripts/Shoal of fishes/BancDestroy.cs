using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancDestroy : MonoBehaviour
{
    public SpawnGroupFishes Spawner;    // Spawner for the Banc
    private GameObject Manager;         // Banc manager
    public int CurrentLoads = 0;        // Loads counter

    public GameObject[] Manager_List = new GameObject[100];     // List of managers

    // Function to update the Manager List
    public void Actualize_List(){
         Manager_List = GameObject.FindGameObjectsWithTag("banc_manager");
    }

    // Function to show banc when collide with the nose
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("nose"))
        {
            for(int i=0;i< Manager_List.Length;i++){
                Manager = Manager_List[i];
                if(Manager.GetComponent<globalFlock> () != null){
                    Manager.GetComponent<globalFlock> ().DestroyBanc();
                    Destroy(Manager,20f);
                }
            }
        }    
    }
}
