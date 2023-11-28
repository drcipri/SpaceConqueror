using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShips : MonoBehaviour
{
    [SerializeField] List<GameObject> flyingShips;
    [SerializeField] GameObject finalPoint;
    
    bool instantiate = true;
   
    private void Start()
    {
       StartCoroutine(FlyShips());
    }
   

    IEnumerator FlyShips()
    {
        while (true)
        {
            GameObject ship = Instantiate(flyingShips[Random.Range(0, flyingShips.Count)], transform.position, Quaternion.identity);
            ship.GetComponent<MoveShipUI>().SetFlyShip(gameObject.GetComponent<FlyingShips>());
            instantiate = false;
            yield return new WaitUntil(() => instantiate == true);
        }
        


    }



    public void SetInstantiate(bool instantiate )
    {
        this.instantiate = instantiate;
    }
    public GameObject GetFinalPoint()
    {
        return finalPoint;
    }
}
