using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorRotateScript : MonoBehaviour
{

    public int rotatingSpeed = 200;
    public Chase scriptchase;
    public Chase Collidedscript;
    public float collisionForce = 500f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (rotatingSpeed, rotatingSpeed, rotatingSpeed) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        
        if (collider.CompareTag("Protectors"))
        {
            Destroy(transform.parent.gameObject);
        }else if (collider.CompareTag("Player"))
        {
            GameObject protectors = GameObject.FindGameObjectWithTag("Protectors");
            Destroy(transform.parent.gameObject);
            if ( protectors != null)
            {
                Destroy(protectors);
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                SceneManager.LoadScene("Main-Prototype 1");
            }
            
        }
        
        
    }
}
