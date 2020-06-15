using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public GameObject hipR;             //Right Hip
    public GameObject hipL;             //Left Hip
    public GameObject BubbleSpan;       //Bubbles
    public float positionLeft;          //Left limit for the Hip
    public float positionRight;         //Right limit for the Hip
    public AudioSource bubleSource;     //Bubbles Audio

    // Start is called before the first frame update
    void Start()
    {
        bubleSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //when the hip gets over the limits show bubbles
        if ( (hipL.transform.position.x < positionLeft || hipR.transform.position.x > positionRight ) && BubbleSpan.GetComponent<BubbleController>().disponible == true)
        {
            StartCoroutine(BubbleSpan.GetComponent<BubbleController>().Bubbling());
            bubleSource.Play();

        }
    }

}