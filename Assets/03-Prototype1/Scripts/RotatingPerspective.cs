using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class RotatingPerspective : MonoBehaviour
{
    public float rotationSpeed = 20;
    public GameObject pivotObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
    }
}
