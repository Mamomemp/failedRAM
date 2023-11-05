using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnlockleLevel", menuName = "ScriptableObjects/UnlockLevel")]
public class UnlockLevel : ScriptableObject
{
    [SerializeField]
    private bool isUnlocked = false;

    public void Unlock()
    {
        isUnlocked = true;
    }

    public bool getIsUnlocked()
    {
        return isUnlocked;
    }
}
