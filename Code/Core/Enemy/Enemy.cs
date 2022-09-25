using System;
using Gadget.Core;
using UnityEngine;

[Serializable]
public class Enemy
{
    [Range(1, 1000)] 
    public int Hp = 1;
    public Vector3 Rotation = new(0, 180, 0);
    public Vector3 SpawnOffset;

    [Tooltip("The default value is obtained from prefab, if you want, you can change it."), EnableIf("IsBossFight")]
    public Vector3 Scale;

    [Tooltip("By default, the prefab is already there, if you want, you can change it.")] 
    public GameObject Skin;
        
    [HideInInspector]
    public bool IsBossFight;

    public Enemy(GameObject skin)
    {
        Skin = skin;
        Scale = skin.transform.localScale;
    }
}