
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public float speed = 7.5f;
    private Rigidbody rb;
    public float xMove = .35f;
    public float yMove = 1;
    public int direction = 1;
    public float bottomY = -3.5f;
    public float edgeX = -14f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    void Update()
    {
        if (transform.position.y < bottomY && transform.position.x < edgeX)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {

        rb.velocity = new Vector3(xMove, yMove, 0) * speed * direction;
   
    }

    public void speedUp(float newSpeed)
    {
        speed += newSpeed;

        Debug.Log ("IdleSpeed = " + speed);
    }


}
