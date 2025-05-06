using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponItem : ScriptableObject
{
    public Sprite image;
    public abstract void ConsumeAndLoad();
}
