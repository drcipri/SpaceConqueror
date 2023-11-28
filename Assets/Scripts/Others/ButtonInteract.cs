using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteract : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] float countDown = 0.1f;
    float copyCountDown;
    bool buttonPressed = false;
    bool buttonUnpressed = false;


    private void Start()
    {
        copyCountDown = countDown;
    }

    private void Update()
    {
        StartCountDown();

    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {

        buttonUnpressed = true;
        
    }


    private void StartCountDown()
    {
        
        if(buttonUnpressed == true)
        {
            
            countDown -= Time.deltaTime;
            if(countDown < 0f)
            {
                buttonPressed = false;
                buttonUnpressed = false;
                countDown = copyCountDown;
            }
        }
    }


    public bool GetButtonPressed()
    {
        return buttonPressed;
    }
  

}
