using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour
{
    
    public MeshRenderer window;

    public Material isOff;
    public Material isOn;

    private ReceiveItem ri;
    private GiveItem gi;

    void Start()
    {
        ri = GetComponent<ReceiveItem>();
        gi = GetComponent<GiveItem>();
    }

    void Update(){
        if(!ri.active && gi.active){
            window.material = isOn;
        } else{
            window.material = isOff;
        }
    }
}
