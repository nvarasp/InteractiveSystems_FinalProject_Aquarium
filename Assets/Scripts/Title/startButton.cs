using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour, IPointerClickHandler
{
    //When click on this button show aquarium Scene
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("aquarium");
    }
}

