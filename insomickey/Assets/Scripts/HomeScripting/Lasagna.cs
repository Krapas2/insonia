using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasagna : MonoBehaviour
{
    [HideInInspector]
    public bool active = false;

    
    private PlayerController pc;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    void OnMouseDown()
    {
        if(active && Mathf.Abs((pc.transform.position - transform.position).magnitude) < pc.range)
        {
            Destroy(gameObject);
        }
    }
}
