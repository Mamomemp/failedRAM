using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doUnlock : MonoBehaviour // doUnlock = Destroy On Unlock
{
    [SerializeField] private UnlockLevel unlockLevel;
    public bool test;
    private void Awake()
    {
        if (unlockLevel.getIsUnlocked() || test)
        {
            DestroyThis();
        }
    }
    private void DestroyThis()
    {
        GameObject.Destroy(gameObject, 0);
    }
}
