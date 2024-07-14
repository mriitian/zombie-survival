using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [HideInInspector]
    public bool bullet_and_BulletFX_Created = false;
    [HideInInspector]
    public bool rocket_Bullet_Created = false;

    void Awake()
    {
        MakeInstance();
    }

    void OnDisable()
    {
        instance = null;
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
