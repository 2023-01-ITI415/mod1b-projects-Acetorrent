using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject player;
    public float playerPos = -14f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerSun = Instantiate<GameObject>(player);

        Vector3 pos = Vector3.zero;
        pos.y = playerPos;
        playerSun.transform.position = pos;
    }
}
