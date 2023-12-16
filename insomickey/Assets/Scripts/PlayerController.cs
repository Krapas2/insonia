using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[SelectionBaseAttribute]
public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float jumpForce = 10f;
    public float range;

    public float gravity = 10f;
    public Transform groundDetection;
    public LayerMask ground;
    
    private bool grounded;
    private Vector3 velocity;

    private CharacterController controller;

    public bool hasItem;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        hasItem = false;
    }

    void Update()
    {

        Vector3 move = transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical"); //detectar inputs de movimentos
        controller.Move(move.normalized * Time.deltaTime * speed); //mexer jogador

        Debug.DrawLine(groundDetection.position,groundDetection.position - groundDetection.up * 0.1f);
        grounded = Physics.CheckSphere(groundDetection.position,0.1f,ground); //checa se o jogador esta no chão

        //aplica gravidade se o jogador esta no chão e reseta velocidade de queda se não esta
        //sem resetar a velocidade o jogador fica caindo rapidão
        if(grounded)
            if(Input.GetButtonDown("Jump"))
                velocity.y = jumpForce;
            else
                velocity.y = 0;
        else
            velocity.y -= gravity * Time.deltaTime; 

        
    }

    void LateUpdate(){
        controller.Move(velocity * Time.deltaTime);
    }

    //Pega o id do item e compara com o id requerido pelo npc
    public bool GetItemID(double requiredID)
    {
        PickItemUp pickup = gameObject.GetComponentInChildren<PickItemUp>();
        if (pickup != null)
        {
            if (hasItem && pickup.id == requiredID)
            {
                return true;
            }
        }

        return false;
    }

    private void OnEnable()
    {
        Lua.RegisterFunction("GetItemID", this, SymbolExtensions.GetMethodInfo(() => GetItemID((double)0)));
    }

}
 