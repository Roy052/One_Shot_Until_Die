using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetMgr : MonoBehaviour
{
    public static GameObject[] prefabs;

    public static GameObject MakePrefab(string name)
    {
        GameObject ret = null;
        for(int i = 0; i < prefabs.Length; i++)
        {
            if(prefabs[i].name == name)
            {
                ret = Instantiate(prefabs[i]);
            }
        }

        return ret;
    }
}
