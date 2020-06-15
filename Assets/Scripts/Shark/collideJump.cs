using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class collideJump : MonoBehaviour
{
    public GameObject shark;            // Shark game object
    private float runSpeed;             // Shark speed
    public GameObject[] fishes;         // Array of fishes to destroy
    private int timetodestroy = 8;      // Destroy fishes after this time
    public GameObject BancDestroy;

    private bool canDestroy = true;     // Var to destroy fishes
    bool onJump = false;                // Bool var to know if you have jumped
    public GameObject fishes_present;   // Actual Fishes in the aquarium

    public AudioSource SharkSound;      // Shark Audio Sound
    bool soundon = false;               // Bool var to know if shark sound is on

    // Start is called before the first frame update
    void Start()
    {
        SharkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // When jump, emit sound and shark appears
        if (onJump == true)
        {
            if (soundon == false)
            {
                SharkSound.Play();
                soundon = true;
            }

            if ((shark.transform.position.z >= -700))//if the shark is still getting closer, continue with the movement and sound
            {
                if(fishes.Length < 3)
                    runSpeed = 150;
                else
                {
                    runSpeed = 170;
                }
                shark.transform.Translate(new Vector3(0, 0, runSpeed * Time.deltaTime));
            }
            else//if the shark is too close, bring it to the original position and stop the sound
            {
                shark.transform.position = new Vector3(0, -100, 900);
                onJump = false;
                canDestroy = true;
                SharkSound.Pause();
                soundon = false;
            }
        }
    }

    // Function to make all the fishes fall down after shark appears
    private void objectsFall()
    {
        fishes = GameObject.FindGameObjectsWithTag("fish");                        // Create array with all fishes
        GameObject[] managers = GameObject.FindGameObjectsWithTag("banc_manager"); // To destroy load of fishes

        for(int i=0;i< fishes.Length;i++)
        {
            if(fishes[i].GetComponent<Random_move>()!=null)                        //other two fishes cases
                fishes[i].GetComponent<Random_move>().enabled = false;
            if(fishes[i].GetComponent<flock>()!= null)                             // clown fish case
                fishes[i].GetComponent<flock>().enabled = false;
            if (fishes[i].GetComponent<GetSmaller>() != null)                             // yellow fish case
                fishes[i].GetComponent<GetSmaller>().enabled = false;
            if (fishes[i].GetComponent<BoxCollider>() != null)                             // yellow fish case
                fishes[i].GetComponent<BoxCollider>().enabled = false;

            fishes[i].GetComponent<Rigidbody>().isKinematic = false;
            fishes[i].GetComponent<Rigidbody>().useGravity = true;
        }
        DestroyFishes();

        //Destroy the reference to the shoal of fishes
        BancDestroy.GetComponent<BancDestroy>().Manager_List = new GameObject[0];
        
        for (int j =0 ;j< managers.Length;j++){
            Destroy(managers[j],timetodestroy);
        }

        if(fishes_present.GetComponent<FishSpawner>() != null)
        {
            fishes_present.GetComponent<FishSpawner>().DestroyAllFish();
        }
    }

    //Destroy all fishes in the aquarium after timetodestroy
    public void DestroyFishes()
    {
        if (canDestroy == true) {
            foreach (GameObject fish in fishes)
            {
                Destroy(fish,timetodestroy);
                for(int i =0; i < fishes.Length; i ++)
                {
                        Destroy(fishes[i],timetodestroy);
                        fishes[i] = null;
                }
            }
            canDestroy = false;
        }
    }

    // Function to detect when person jumps
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("knee"))
        {
            if (onJump == false)
            {
                objectsFall();
                onJump = true;
            }
        }
    }
}