using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{

    public Transform playerHand;
    public GameObject bedsheets;
    
    private PlayerController pc;
    private LayerManager lm;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        lm = FindObjectOfType<LayerManager>();
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Se o jogador j� n�o estiver segurando um item, pega aquele que foi clicado
        if (!pc.hasItem && Mathf.Abs((pc.transform.position - transform.position).magnitude) < pc.range)
        {
            bedsheets.transform.position = playerHand.position;
            bedsheets.transform.rotation = playerHand.rotation;
            bedsheets.transform.parent = playerHand;
            pc.hasItem = true;
        }
    }
}
