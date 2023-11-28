using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ChosePlayer")]
public class PlayerChoser : ScriptableObject
{
   [SerializeField]GameObject player;

    
    public void SetPlayerShip(GameObject player)
    {
        this.player = player;
    }

    public GameObject GetPlayerShip()
    {
        return player;
    }

}
