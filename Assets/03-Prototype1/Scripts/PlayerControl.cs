using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public float speed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.localPosition.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        transform.position = Vector3.Lerp (transform.position, mousePos3D, speed * Time.deltaTime);

    }
}
