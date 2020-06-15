using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour
{
    public GameObject nose;                                         // Nose
    public GameObject fishPrefab;                                   // Fish
    public static int tankSize =2000;                               // Tank size
    static int numFish = 40;                                        // Number of fishes in the banc
    public static GameObject[] allFish = new GameObject[numFish];   // Array of fishes in the banc

    public static Vector3 goalPos = Vector3.zero;                   // Position where banc will go
    public GameObject spawner;                                      // Spawner
    public GameObject outWay;                                       // Out Way
    private bool leave;                                             // Leave

    // Start is called before the first frame update
    void Start()
    {
        nose = GameObject. Find("Nose");
        spawner = GameObject. Find("limitLeft");
        outWay = GameObject. Find("limitRight");
        
        leave = false;
        for(int i=0; i< numFish; i++)
        {
            Vector3 pos = new Vector3(spawner.transform.position.x,
                                      Random.Range(-tankSize, tankSize),
                                      nose.transform.position.z  );
            allFish[i] = (GameObject) Instantiate (fishPrefab, pos,fishPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(leave == false){
            goalPos = nose.transform.position;
        }else{
            goalPos = outWay.transform.position + new Vector3(1000,0,0);
        }    
    }   

    // Function to destroy the banc
    public void DestroyBanc()
    {
        leave = true;
        for(int i=0; i< numFish; i++)
        {
            Destroy(allFish[i],15f);
        }
    }
}
