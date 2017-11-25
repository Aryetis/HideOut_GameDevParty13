using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFolderBehavior : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
