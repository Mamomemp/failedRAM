using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover2 : MonoBehaviour
{
    [System.Serializable]
    public struct MovementData
    {
        public float time;
        public float movementAmount;
        public float movementDuration;
    }

    public MovementData[] movements;

    private void Update()
    {
        foreach (var movement in movements)
        {
            if (Time.time >= movement.time && Time.time <= movement.time + movement.movementDuration)
            {
                MoveObject(movement.movementAmount);
            }
        }
    }

    private void MoveObject(float amount)
    {
        // Assuming movement is along the Z-axis
        transform.Translate(Vector3.forward * amount * Time.deltaTime);
    }
}
