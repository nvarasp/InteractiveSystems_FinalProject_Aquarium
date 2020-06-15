using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(0, 6f, 0));     //Bubbles movement

        // Destroy GameObject when is on top
        if (transform.position.y > 900)
        {
            Destroy(gameObject);
        }
	}
}
