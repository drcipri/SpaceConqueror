using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] List<GameObject> drops;
    [SerializeField] float setDropRate = 0.5f;

  

    public void Drop()
    {
        float dropRate = Random.value;
        int randomItem = Random.Range(0, drops.Count);
        Vector3 dropLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        

        if(dropRate < setDropRate)
        {
            
            Instantiate(drops[randomItem], dropLocation, Quaternion.identity);
        }
        
    }

    

}
