
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class changeColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model;  // Model
    public Color normalColor;   // Default colo
    public Color hoverColor;    // Color when click

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    // Change color when click
    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    // Change color to the normal one after clicking 
    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColor;
    }

}


