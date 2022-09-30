using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5;
    public float mousespeed = 60;
    public Camera main;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        if(main.transform.position.x + h * Time.deltaTime * speed > -55f && main.transform.position.x + h * Time.deltaTime * speed < -10f)
        {
            transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime * speed, Space.World);
        }
        if (main.transform.position.z + v * Time.deltaTime * speed > -15f && main.transform.position.z + v * Time.deltaTime * speed < 45f)
        {
            transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * speed, Space.World);
        }
        if (main.transform.position.y - mouse * Time.deltaTime * speed * mousespeed > 5f && main.transform.position.y - mouse * Time.deltaTime * speed * mousespeed < 25f)
        {
            transform.Translate(new Vector3(0, -mouse * mousespeed, 0) * Time.deltaTime * speed, Space.World);
        }


    }
}
