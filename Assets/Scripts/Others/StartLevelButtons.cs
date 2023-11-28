using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelButtons : MonoBehaviour
{
    [SerializeField] LoadSceneAsync loadSceneAsync;
    [SerializeField] ManageScene manageLevels;
    //Map1
    string level1map1 = "Level1Map1";
    string level2map1 = "Level2Map1";
    string level3map1 = "Level3Map1";
    string level4map1 = "Level4Map1";
    string level5map1 = "Level5Map1";
    string level6map1 = "Level6Map1";
    string level7map1 = "Level7Map1";
    string level8map1 = "Level8Map1";
    string level9map1 = "Level9Map1";
    string level10map1 = "Level10Map1";


    //map2
    string level1map2 = "Level1Map2";
    string level2map2 = "Level2Map2";
    string level3map2 = "Level3Map2";
    string level4map2 = "Level4Map2";
    string level5map2 = "Level5Map2";
    string level6map2 = "Level6Map2";
    string level7map2 = "Level7Map2";
    string level8map2 = "Level8Map2";
    string level9map2 = "Level9Map2";
    string level10map2 = "Level10Map2";

    //map3
    string level1map3 = "Level1Map3";
    string level2map3 = "Level2Map3";
    string level3map3 = "Level3Map3";
    string level4map3 = "Level4Map3";
    string level5map3 = "Level5Map3";
    string level6map3 = "Level6Map3";
    string level7map3 = "Level7Map3";
    string level8map3 = "Level8Map3";
    string level9map3 = "Level9Map3";
    string level10map3 = "Level10Map3";

    //map4
    string level1map4 = "Level1Map4";
    string level2map4 = "Level2Map4";
    string level3map4 = "Level3Map4";
    string level4map4 = "Level4Map4";
    string level5map4 = "Level5Map4";
    string level6map4 = "Level6Map4";
    string level7map4 = "Level7Map4";
    string level8map4 = "Level8Map4";
    string level9map4 = "Level9Map4";
    string level10map4 = "Level10Map4";


    //map1
    public void StartLevel1Map1()
    {
        if(manageLevels.GetLevelsCleared() >= 0)
        {
            loadSceneAsync.LoadSceneInSync(level1map1);
        }
    }

    public void StartLevel2Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 1)
        {
            loadSceneAsync.LoadSceneInSync(level2map1);
        }
    }

    public void StartLevel3Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 2)
        {
            loadSceneAsync.LoadSceneInSync(level3map1);
        }
    }

    public void StartLevel4Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 3)
        {
            loadSceneAsync.LoadSceneInSync(level4map1);
        }
    }

    public void StartLevel5Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 4)
        {
            loadSceneAsync.LoadSceneInSync(level5map1);
        }
    }

    public void StartLevel6Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 5)
        {
            loadSceneAsync.LoadSceneInSync(level6map1);
        }
    }

    public void StartLevel7Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 6)
        {
            loadSceneAsync.LoadSceneInSync(level7map1);
        }
    }

    public void StartLevel8Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 7)
        {
            loadSceneAsync.LoadSceneInSync(level8map1);
        }
    }

    public void StartLevel9Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 8)
        {
            loadSceneAsync.LoadSceneInSync(level9map1);
        }
    }

    public void StartLevel10Map1()
    {
        if (manageLevels.GetLevelsCleared() >= 9)
        {
            loadSceneAsync.LoadSceneInSync(level10map1);
        }
    }
    
    //map2
    public void StartLevel1Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 10)
        {
            loadSceneAsync.LoadSceneInSync(level1map2);
        }
    }
    public void StartLevel2Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 11)
        {
            loadSceneAsync.LoadSceneInSync(level2map2);
        }
    }
    public void StartLevel3Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 12)
        {
            loadSceneAsync.LoadSceneInSync(level3map2);
        }
    }
    public void StartLevel4Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 13)
        {
            loadSceneAsync.LoadSceneInSync(level4map2);
        }
    }
    public void StartLevel5Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 14)
        {
            loadSceneAsync.LoadSceneInSync(level5map2);
        }
    }
    public void StartLevel6Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 15)
        {
            loadSceneAsync.LoadSceneInSync(level6map2);
        }
    }
    public void StartLevel7Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 16)
        {
            loadSceneAsync.LoadSceneInSync(level7map2);
        }
    }
    public void StartLevel8Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 17)
        {
            loadSceneAsync.LoadSceneInSync(level8map2);
        }
    }
    public void StartLevel9Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 18)
        {
            loadSceneAsync.LoadSceneInSync(level9map2);
        }
    }
    public void StartLevel10Map2()
    {
        if (manageLevels.GetLevelsCleared() >= 19)
        {
            loadSceneAsync.LoadSceneInSync(level10map2);
        }
    }

    //map3
    public void StartLevel1Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 20)
        {
            loadSceneAsync.LoadSceneInSync(level1map3);
        }
    }

    public void StartLevel2Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 21)
        {
            loadSceneAsync.LoadSceneInSync(level2map3);
        }
    }
    public void StartLevel3Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 22)
        {
            loadSceneAsync.LoadSceneInSync(level3map3);
        }
    }
    public void StartLevel4Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 23)
        {
            loadSceneAsync.LoadSceneInSync(level4map3);
        }
    }
    public void StartLevel5Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 24)
        {
            loadSceneAsync.LoadSceneInSync(level5map3);
        }
    }
    public void StartLevel6Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 25)
        {
            loadSceneAsync.LoadSceneInSync(level6map3);
        }
    }
    public void StartLevel7Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 26)
        {
            loadSceneAsync.LoadSceneInSync(level7map3);
        }
    }
    public void StartLevel8Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 27)
        {
            loadSceneAsync.LoadSceneInSync(level8map3);
        }
    }
    public void StartLevel9Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 28)
        {
            loadSceneAsync.LoadSceneInSync(level9map3);
        }
    }
    public void StartLevel10Map3()
    {
        if (manageLevels.GetLevelsCleared() >= 29)
        {
            loadSceneAsync.LoadSceneInSync(level10map3);
        }
    }

    //map4
    public void StartLevel1Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 30)
        {
            loadSceneAsync.LoadSceneInSync(level1map4);
        }
    }
    public void StartLevel2Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 31)
        {
            loadSceneAsync.LoadSceneInSync(level2map4);
        }
    }
    public void StartLevel3Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 32)
        {
            loadSceneAsync.LoadSceneInSync(level3map4);
        }
    }
    public void StartLevel4Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 33)
        {
            loadSceneAsync.LoadSceneInSync(level4map4);
        }
    }
    public void StartLevel5Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 34)
        {
            loadSceneAsync.LoadSceneInSync(level5map4);
        }
    }
    public void StartLevel6Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 35)
        {
            loadSceneAsync.LoadSceneInSync(level6map4);
        }
    }
    public void StartLevel7Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 36)
        {
            loadSceneAsync.LoadSceneInSync(level7map4);
        }
    }
    public void StartLevel8Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 37)
        {
            loadSceneAsync.LoadSceneInSync(level8map4);
        }
    }
    public void StartLevel9Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 38)
        {
            loadSceneAsync.LoadSceneInSync(level9map4);
        }
    }
    public void StartLevel10Map4()
    {
        if (manageLevels.GetLevelsCleared() >= 39)
        {
            loadSceneAsync.LoadSceneInSync(level10map4);
        }
    }



}
