using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClaire : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public int rotationSpeed = 3;
    public bool rotationCam = true;
    public float yHeight = 30.0f;

    void Start()
    {
        offset = new Vector3(transform.position.x - player.transform.position.x, 0, transform.position.z - player.transform.position.z);
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;
        targetPosition.y = yHeight;
        transform.position = targetPosition;

        if (rotationCam)
        {
            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") *
                rotationSpeed, Vector3.up);
            offset = turnAngle * offset;

            transform.LookAt(player.transform);
        }
    }
}
