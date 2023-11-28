using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCrystals : MonoBehaviour
{
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] float timer = 5f;
    GameObject crystal;
    Vector3 targetPos;
    
    
   
    private void Awake()
    {
        crystal = GameObject.FindGameObjectWithTag("CrystalImage");
        
        
    }
    private void Start()
    {
        targetPos = Camera.main.ScreenToWorldPoint(crystal.transform.position);
       
    }
    private void Update()
    {
        CrystalProcess();
       
        
       
    }



    private void CrystalProcess()
    {
        var moveThisFrame = Time.deltaTime * movingSpeed;
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveThisFrame);
            if (transform.position.x == targetPos.x && transform.position.y == targetPos.y)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
