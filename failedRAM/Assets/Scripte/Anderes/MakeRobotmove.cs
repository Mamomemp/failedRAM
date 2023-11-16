using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover22 : MonoBehaviour
{

    public void MoveObject()
    {
        
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0f, 0f, 2.65f);
        StartCoroutine(MoveObjectCoroutine(targetPosition, 0.6f)); // 0.6 seconds duration
    }

    private System.Collections.IEnumerator MoveObjectCoroutine(Vector3 end, float duration)
    {
        float startTime = Time.time;
        Vector3 start = transform.position;

        while (Time.time - startTime < duration)
        {
            
            float t = (Time.time - startTime) / duration;

            
            transform.position = Vector3.Lerp(start, end, t);

           
            yield return null;
        }

       
        transform.position = end;
    }
}
