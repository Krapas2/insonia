using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public string nextScene;

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
            SceneManager.LoadScene(nextScene);
        }
    }
}
