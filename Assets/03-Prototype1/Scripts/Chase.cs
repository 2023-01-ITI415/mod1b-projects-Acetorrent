
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed = 9.5f;
    public GameObject target;
    private Rigidbody rb;
    public SpawningScript spawningScript;
    public ScoreControl difficulty;
    public float rate = 0.5f;
    private bool isReady = true;

    void Start()
    {
        Invoke("readyUp", 2.5f * Time.deltaTime);
        difficulty = FindObjectOfType<ScoreControl>();
        spawningScript = FindObjectOfType<SpawningScript>();
        rb = GetComponent<Rigidbody>();

    }


    // Start is called before the first frame update
    void FixedUpdate()
    {

        target = GameObject.FindGameObjectWithTag("Player");

        var deltas = target.transform.position - this.transform.position;

        var distance = deltas.magnitude;
        var direction = deltas / distance;

        if (speed <= 16 && isReady) {
            speedUp(difficulty.getDifficultyNum());
            isReady = false;


        }



        rb.velocity = direction * speed;
    }

    void OnDestroy()
    {
        spawningScript.removeDestroyed(this.gameObject);
    }

    public void speedUp(float newSpeed)
    {
        speed = 9.5f + newSpeed * rate;

        Debug.Log("NEW_ChaseSpeed = " + speed);
    }

    private void readyUp()
    {
        isReady = true;

    }



}
