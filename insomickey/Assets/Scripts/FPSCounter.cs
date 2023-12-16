using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private int i;
    
    void Start()
    {
        StartCoroutine("Count");
        
    }

    void Update()
    {
        i++;
    }
    
    private IEnumerator Count(){
        yield return new WaitForSeconds(1);
        Debug.Log(i);
        i = 0;
        StartCoroutine("Count");
    }
}
