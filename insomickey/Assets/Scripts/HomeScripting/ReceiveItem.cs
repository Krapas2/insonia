using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour
{

    public Transform playerHand;
    public GameObject item;
    public Transform itemPosition;

    [HideInInspector]
    public bool playerHasItem;
    [HideInInspector]
    public bool active;

    private PlayerController pc;
    private LayerManager lm;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        lm = FindObjectOfType<LayerManager>();
    }

    void Update()
    {
        if(item)
            playerHasItem = item.transform.position == playerHand.transform.position;
        else 
            playerHasItem = false;
        /*if(playerHasItem){ // talvez pesado mas o jeito mais facil que achei sem usar box collider ao invés dos meshes individuais
            lm.SetLayerRecursively(gameObject, gameObject.layer = LayerMask.NameToLayer("Default"));
        } else
            lm.SetLayerRecursively(gameObject, gameObject.layer = LayerMask.NameToLayer("Scene"));*/
    }

    void OnMouseDown()
    {
        // Se o jogador j� n�o estiver segurando um item, pega aquele que foi clicado
        if (playerHasItem && Mathf.Abs((pc.transform.position - transform.position).magnitude) < pc.range && active)
        {
            item.transform.position = itemPosition.position;
            item.transform.rotation = itemPosition.rotation;
            item.transform.parent = itemPosition;
            pc.hasItem = false;
            active = false;
        }
    }
}
