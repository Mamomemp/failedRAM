using System.Collections;
using UnityEngine;

public class CameraLevelSelectTransition : MonoBehaviour
{
    [SerializeField] private Camera transition_Camera;
    [SerializeField] private Camera main_Camera;
    [SerializeField] private UnlockLevel unlockLevel;

    [SerializeField] private GameObject screen_GO;
    [SerializeField] private GameObject secret_GO;
    [SerializeField] private GameObject phone_GO; // Added phone_GO
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target_player;
    [SerializeField] private GameObject target_screen;

    [SerializeField] private GameObject[] gameObject_Array;

    [SerializeField] private string secret_name;
    [SerializeField] private float Cam_geschwindichkeit = 1f;
    [SerializeField] private string scene_Name;
    [SerializeField] private string start_scene_name; // Added start_scene_name

    private void Awake()
    {
        //scene_Name = unlockLevel.GetSavedSceneName();
        TeleportObjects();
    }

    private void Start()
    {
        StartCoroutine(MoveToMainCameraPosition());
    }

    void TeleportObjects()
    {
        foreach (GameObject obj in gameObject_Array)
        {
            if (obj.name == scene_Name)
            {
                if (scene_Name == secret_name)
                {
                    // Teleport player, target_player, and transition_Camera to the z-transform of secret_GO
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, secret_GO.transform.position.z);
                    target_player.transform.position = new Vector3(target_player.transform.position.x, target_player.transform.position.y, secret_GO.transform.position.z);
                    transition_Camera.transform.position = new Vector3(transition_Camera.transform.position.x, transition_Camera.transform.position.y, secret_GO.transform.position.z);
                }
                else if (scene_Name == start_scene_name)
                {
                    print("yeah it is");
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, obj.transform.position.z);
                    target_player.transform.position = new Vector3(target_player.transform.position.x, target_player.transform.position.y, obj.transform.position.z);
                    // Teleport tran_cam completly to target
                    transition_Camera.transform.position = new Vector3(phone_GO.transform.position.x, phone_GO.transform.position.y, phone_GO.transform.position.z);
                }
                else
                {
                    // Teleport screen_GO, player, target_player, and transition_Camera to the z-transform of the foundObject
                    screen_GO.transform.position = new Vector3(screen_GO.transform.position.x, screen_GO.transform.position.y, obj.transform.position.z);
                    target_screen.transform.position = new Vector3(target_screen.transform.position.x, target_screen.transform.position.y, obj.transform.position.z);
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, obj.transform.position.z);
                    target_player.transform.position = new Vector3(target_player.transform.position.x, target_player.transform.position.y, obj.transform.position.z);
                    transition_Camera.transform.position = new Vector3(transition_Camera.transform.position.x, transition_Camera.transform.position.y, obj.transform.position.z);
                }
                break;
            }
        }
    }

    #region Moveto
    IEnumerator MoveToMainCameraPosition()
    {
        Transform target = main_Camera.transform;

        while (transition_Camera.transform.position != target.position)
        {
            transition_Camera.transform.position = Vector3.MoveTowards(transition_Camera.transform.position, target.position, Cam_geschwindichkeit * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Main Camera is now active, transition Camera is deactivated
        main_Camera.gameObject.SetActive(true);
        transition_Camera.gameObject.SetActive(false);
    }
    #endregion

    // Added method for camera activation and movement
    public void ActivateAndMoveCamera(string destination)
    {
        main_Camera.gameObject.SetActive(false);
        transition_Camera.gameObject.SetActive(true);

        // Check if the scene_name equals start_scene_name
        if (scene_Name == start_scene_name)
        {
            // If true, start at phone_GO
            transition_Camera.transform.position = phone_GO.transform.position;
        }
        else
        {
            // Otherwise, move to screen_GO or secret_GO based on the destination string
            if (destination == "screen")
            {
                transition_Camera.transform.position = screen_GO.transform.position;
            }
            else if (destination == "secret")
            {
                transition_Camera.transform.position = secret_GO.transform.position;
            }
            // You can add more conditions for different destinations if needed
        }
    }
}
