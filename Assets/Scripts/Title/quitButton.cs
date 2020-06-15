
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class quitButton : MonoBehaviour, IPointerClickHandler
{
    // When click this button End the Application
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}

