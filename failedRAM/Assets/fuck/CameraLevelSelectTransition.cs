using System.Collections;
using UnityEngine;

public class CameraLevelSelectTransition : MonoBehaviour
{
    [SerializeField] private Camera transition_Camera;
    [SerializeField] private Camera main_Camera;
    [SerializeField] private UnlockLevel unlockLevel;

    [SerializeField] private GameObject screen_GO;
    [SerializeField] private GameObject secret_GO;
    [SerializeField] private GameObject phone_GO;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target_player;
    [SerializeField] private GameObject target_screen;
    private Transform target;


    [SerializeField] private GameObject[] gameObject_Array;

    [SerializeField] private float Cam_geschwindichkeit = 1f;
    [SerializeField] private string scene_Name;
    private string secret_name = "SampleScene";
    private string start_scene_name = "StartMenueScene";
    private string LevelSelect_name = "LevelSelectScene";

    private void Awake()
    {
        scene_Name = unlockLevel.GetSavedSceneName();
        TeleportObjects();
    }

    private void Start()
    {
        StartCoroutine(MoveToMainCameraPosition(true, screen_GO)); //in diesen fall wird screen_GO spaeter ueberschrieben
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

    IEnumerator MoveToMainCameraPosition(bool zuMainCam, GameObject targetObject)
    {
        GameObject deactivatedcam;
        GameObject activatedcam;
        float offset = 0.5f;
        bool startmoving = false;
        Vector3 initialTransitionCamPosition = Vector3.zero; // Store the initial position

        if (zuMainCam)
        {
            target = main_Camera.transform;
            activatedcam = main_Camera.gameObject;
            deactivatedcam = transition_Camera.gameObject;
        }
        else
        {
            initialTransitionCamPosition = transition_Camera.transform.position; // Store the initial position
            target = screen_GO.transform; // Ziel ist das Transform der transition_Camera
            target.position = targetObject.transform.position + new Vector3(0, offset, 0);

            activatedcam = transition_Camera.gameObject;
            deactivatedcam = main_Camera.gameObject;
            startmoving = true;
        }

        if (startmoving)
        {
            while (transition_Camera.transform.position != target.position)
            {
                activatedcam.SetActive(true);
                deactivatedcam.SetActive(false);
                transition_Camera.transform.position = Vector3.MoveTowards(transition_Camera.transform.position, target.position, Cam_geschwindichkeit * Time.deltaTime);
                yield return null; // Warte auf den nächsten Frame
            }
        }
        else
        {
            while (target.position != transition_Camera.transform.position)
            {
         
                transition_Camera.transform.position = Vector3.MoveTowards(transition_Camera.transform.position, target.position, Cam_geschwindichkeit * Time.deltaTime);
                yield return null; // Warte auf den nächsten Frame
            }
        }

        yield return null;
        // Main Camera ist jetzt aktiv, transition Camera ist deaktiviert
       activatedcam.SetActive(true);
       deactivatedcam.SetActive(false);
        // If transitioning from main_Camera to transition_Camera, reset transition_Camera's position to the initial position
        if (!zuMainCam)
        {
            transition_Camera.transform.position = initialTransitionCamPosition;
        }
    }

    // Added method for camera activation and movement
    public IEnumerator ActivateAndMoveCamera(string destination, float waitTime)
    {
        if (scene_Name == start_scene_name)
        {
            yield return MoveToMainCameraPosition(false, phone_GO);
        }
        else if (destination == secret_name)
        {
            yield return MoveToMainCameraPosition(false, secret_GO);
        }
        else if (destination == LevelSelect_name) //Setting WIP
        {   
            yield return MoveToMainCameraPosition(true, screen_GO);

        }
        else //screen
        {
            yield return MoveToMainCameraPosition(false, screen_GO);
        }

        yield return new WaitForSeconds(waitTime);
    }

}

