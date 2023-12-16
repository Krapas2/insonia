using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class Crosshair : MonoBehaviour
{
    public float range;
    public LayerMask interactable;
    public RawImage crosshair;
    
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * range);
        if(Physics.Linecast(transform.position, transform.position + transform.forward * range, interactable))
            crosshair.gameObject.SetActive(true);
        else
            crosshair.gameObject.SetActive(false);
    }
}