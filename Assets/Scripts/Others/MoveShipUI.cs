using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShipUI : MonoBehaviour
{
    FlyingShips flyShips;
    [SerializeField]float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        MoveThisShip();
    }

    public void SetFlyShip(FlyingShips flyShip)
    {
        this.flyShips = flyShip;
    }

    public void MoveThisShip()
    {
        var moveThisFrame = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,flyShips.GetFinalPoint().transform.position,moveThisFrame);
        if(transform.position == flyShips.GetFinalPoint().transform.position)
        {
            Destroy(gameObject);
            flyShips.SetInstantiate(true);
        }
    }


}
