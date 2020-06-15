using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class infoButton : MonoBehaviour, IPointerClickHandler
{
    // When click the button show the Fishes Info Scene
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("FishesInfo");

    }
}