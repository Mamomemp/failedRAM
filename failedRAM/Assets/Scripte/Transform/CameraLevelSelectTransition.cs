using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelSelectTransition : MonoBehaviour
{
    [SerializeField] private Camera transition_Camera;
    [SerializeField] private Camera main_Camera;
    [SerializeField] private UnlockLevel unlockLevel;

    [SerializeField] private GameObject[] gameObject_Array;

    private float Cam_geschwindichkeit = 1f;
    private string scene_Name;

    private void Awake()
    {
        scene_Name = unlockLevel.GetSavedSceneName();
    }

    private void Start()
    {
        FindTransformBySceneName();
    }

    void FindTransformBySceneName()
    {
        foreach (GameObject obj in gameObject_Array)
        {
            if (obj.scene.name == scene_Name)
            {
                transition_Camera.transform.position = obj.transform.position;
                transition_Camera.transform.rotation = obj.transform.rotation;

                break;
            }
        }
    }


    #region MoveTowards
    void Update()
    {
        Transform target = main_Camera.transform;
        while (transition_Camera.transform.position != main_Camera.transform.position)
        {
            transition_Camera.transform.position = Vector3.MoveTowards(transition_Camera.transform.position, target.transform.position, Cam_geschwindichkeit * Time.deltaTime);
        }
    }
    #endregion
}
/*
 * tran cam
 * main cam
 * array positons
 * get old scene
 * 
 * transform from array pos to main cam
 */