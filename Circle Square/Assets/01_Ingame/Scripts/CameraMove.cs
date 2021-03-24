using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;

    public float distX;
    public float distY;

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        dir += new Vector3(distX, distY, 0);
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
