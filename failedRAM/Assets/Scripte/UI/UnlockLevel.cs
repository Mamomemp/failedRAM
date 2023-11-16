using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "UnlockleLevel", menuName = "ScriptableObjects/UnlockLevel")]
public class UnlockLevel : ScriptableObject
{
    [SerializeField] private bool isUnlocked = false;
    private string savedSceneName;

    public void Unlock()
    {
        isUnlocked = true;
    }

    public bool getIsUnlocked()
    {
        return isUnlocked;
    }

    public void SaveCurrentSceneName()
    {
        savedSceneName = SceneManager.GetActiveScene().name;
    }

    public string GetSavedSceneName()
    {
        return savedSceneName;
    }
}
