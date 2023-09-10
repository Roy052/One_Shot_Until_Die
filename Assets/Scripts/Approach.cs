using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : MonoBehaviour
{
    public static AssetManager AssetManager;

    private IEnumerator Start()
    {
        while (AssetManager == null)
            yield return null;
    }
}
