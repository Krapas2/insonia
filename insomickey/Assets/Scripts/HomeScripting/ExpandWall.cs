using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandWall /* (EXPAND DONG) */ : MonoBehaviour
{

    public float minPlayerDistance = 3;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        float playerDistance = transform.position.z - player.transform.position.z;

        if(playerDistance < minPlayerDistance){
            transform.position += Vector3.forward * (minPlayerDistance - playerDistance);
        }
    }
}
