using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour
{

    public Transform playerHand;
    public GameObject Item;

    [HideInInspector]
    public bool active;
    
    private bool wasActive;

    private PlayerController pc;
    private LayerManager lm;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        lm = FindObjectOfType<LayerManager>();
    }
/*
    void Update()
    {
        if(wasActive ^= active){
            if(active){ // talvez pesado mas o jeito mais facil que achei sem usar box collider ao invés dos meshes individuais
                lm.SetLayerRecursively(gameObject, gameObject.layer = LayerMask.NameToLayer("Default"));
            } else 
                lm.SetLayerRecursively(gameObject, gameObject.layer = LayerMask.NameToLayer("Scene"));
        }
        wasActive = active;
    }
*/
    void OnMouseDown()
    {
        // Se o jogador j� n�o estiver segurando um item, pega aquele que foi clicado
        if (!pc.hasItem && Mathf.Abs((pc.transform.position - transform.position).magnitude) < pc.range && active)
        {
            Item.transform.position = playerHand.position;
            Item.transform.rotation = playerHand.rotation;
            Item.transform.parent = playerHand;
            pc.hasItem = true;
            active = false;
        }
    }
}
