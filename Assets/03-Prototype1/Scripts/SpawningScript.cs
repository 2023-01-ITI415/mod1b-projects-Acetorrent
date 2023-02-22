using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject meteorChase;
    public GameObject meteorSpawn;

    public float delayTimerChaser = 4.5f;
    public float delayTimerIdle = .5f;

    public float min_XSpawn = -14f;
    public float max_XSpawn = 15f;

    public float min_YSpawn = 10f;
    public float max_YSpawn = 20f;

    public int maxOnScreenChaser = 2;

    public Chase Chase;
    public EnemyMov Idle;

    static public List<GameObject> MeteorsChase = new List<GameObject>();

    void Awake()
    {
        delayTimerChaser = 4.5f;
        delayTimerIdle = .5f;

        min_XSpawn = -14f;
        max_XSpawn = 15f;

        min_YSpawn = 10f;
        max_YSpawn = 20f;

        maxOnScreenChaser = 2;
}

    // Start is called before the first frame update
    void Start()
    {



        Invoke("spawnMeteor", delayTimerChaser);
        Invoke("spawnIdleMeteor", delayTimerIdle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void spawnMeteor()
    {
        float xPos = Random.Range(min_XSpawn, max_XSpawn);
        float yPos = Random.Range(min_YSpawn, max_YSpawn);

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject enemy = Instantiate<GameObject>(meteorChase);

            enemy.transform.position = new Vector3(xPos, yPos, 0);

            if (MeteorsChase.Count < maxOnScreenChaser)
            {
                MeteorsChase.Add(enemy);
            }
            else
            {
                ClearAllChase();
                MeteorsChase.Add(enemy);
            }



            Invoke("spawnMeteor", delayTimerChaser);
        }

        

    }

    void spawnIdleMeteor()
    {
        float xPos = Random.Range(min_XSpawn, max_XSpawn);
        float yPos = Random.Range(min_YSpawn, max_YSpawn);

        GameObject enemy = Instantiate<GameObject>(meteorSpawn);

        enemy.transform.position = new Vector3(xPos, yPos, 0);        

        Invoke("spawnIdleMeteor", delayTimerIdle);
    }

    static public void ClearAllChase()
    {
        foreach (GameObject enemy in MeteorsChase)
        {

            Destroy(enemy.gameObject);

        }

        MeteorsChase.Clear();
    }

    public void removeDestroyed(GameObject destroyed)
    {
        MeteorsChase.Remove(destroyed);
    }

    public void increaseSpawn()
    {

        if (delayTimerChaser > 1.5f)
        {
            delayTimerChaser += -.75f;
        }

        if (delayTimerIdle > 1)
        {
            delayTimerIdle += -.5f;
        }
        
        if (delayTimerChaser <= 1.5f) 
        {
            maxOnScreenChaser++;
        }


    }


}
