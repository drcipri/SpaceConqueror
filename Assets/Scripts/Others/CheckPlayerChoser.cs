using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerChoser : MonoBehaviour
{
    [SerializeField] PlayerChoser choser;
    [SerializeField] string choserName;

    private void Start()
    {
        choserName = choser.GetPlayerShip().name;
    }
}
