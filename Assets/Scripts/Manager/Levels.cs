using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] ManageScene managelevels;
    [SerializeField] List<GameObject> levels;
    [SerializeField] int howManyToUnlock = 10;
    [SerializeField] int countClearedLevels = 0;




    private void Start()
    {
        SetLevels();
    }
    private void SetLevels()
    {
        for (int index = 0; index < levels.Count - 1; index++)
        {
            if (countClearedLevels < managelevels.GetLevelsCleared())
            {
                levels[index].transform.GetChild(1).GetComponent<Image>().color = Color.white;
                levels[index].transform.GetChild(2).GetComponent<Text>().text = "Clear!";
                levels[index + 1].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                if (countClearedLevels < howManyToUnlock)
                {
                    countClearedLevels++;
                }
            }

        }


    }
}
