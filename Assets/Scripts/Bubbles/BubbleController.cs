using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    public GameObject bubblePrefab;     //bubble prefab
    public float timeSpan = 1f;         //time between spawns
    public bool finished = false;
    public bool disponible = true;


    // function to create the bubbles in random positions
    public IEnumerator Bubbling()
    {
        disponible = false;
        float time = 0;
        while (time < 3f)
        { 
            time += Time.deltaTime;
            yield return new WaitForSeconds(timeSpan);
            
            GameObject bubbleInstance = (GameObject)Instantiate(bubblePrefab);
            bubbleInstance.transform.position = new Vector3(Random.Range(-1112, 1112), Random.Range(-500,0), Random.Range(-400, 450));
        }
        finished = true;
        disponible = true;
    }
}
