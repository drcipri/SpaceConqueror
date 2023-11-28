using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipShow : MonoBehaviour
{
    [SerializeField] List<Sprite> shipSprites;
    [SerializeField] float countDown = 1.5f;
    float copyCountDown;
    Image thisImage;
    private void Start()
    {
        copyCountDown = countDown;
        thisImage = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        ShowSpirtes();
    }

    public void ShowSpirtes()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0)
        {
            var randomValue = Random.Range(0, shipSprites.Count);
            thisImage.sprite = shipSprites[randomValue];
            countDown = copyCountDown;
        }
    }
}
