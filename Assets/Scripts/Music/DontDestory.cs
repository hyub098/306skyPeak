using UnityEngine;
using System.Collections;

/**
* DontDestory is used for background music. The music continues when changing different scenes.
*/
public class DontDestory : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {

        DontDestroyOnLoad(gameObject);

    }
}
