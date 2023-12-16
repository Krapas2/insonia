using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemUp : MonoBehaviour
{
    public Transform hands; // Local onde o objeto vai ficar quando o jogador peg�-lo
    public PlayerController pc;

    public int id; // ID DO ITEM
    public bool unregisterOnDisable = false;

    void Start()
    {
        // M�os do jogador
        hands = GameObject.Find("Hands").transform;
    }

    void OnMouseDown()
    {

        // Se o jogador j� n�o estiver segurando um item, pega aquele que foi clicado
        if (!pc.hasItem && Mathf.Abs((pc.transform.position - transform.position).magnitude) < pc.range)
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = hands.position;
            this.transform.rotation = hands.rotation;
            this.transform.parent = hands;
            pc.hasItem = true;
        }

    }

    private void Update()
    {
        // Se ja tem um item, dropa da mao (Clique botao direito para dropar)
        if (Input.GetMouseButtonDown(1))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;

            if (pc.hasItem)
            {
                pc.hasItem = false;
            }

        }
    }

    // Usado para destruir o objeto na conversa
    void DestroyItem()
    {
        Destroy(gameObject);
    }

}
