
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float speedMovPlayer = 1.5f;
    private Animator animComponent;
    private Rigidbody2D rbPlayer;
    private Vector2 move2D;
    private bool fireShoot;
    [SerializeField] private GameObject weaponOnGround;
    [SerializeField] private GameObject weaponOnMe;



    void Awake()
    {
        InicializeComponents();
    }

    void InicializeComponents()
    {
        animComponent = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rbPlayer.MovePosition(rbPlayer.position + move2D * speedMovPlayer * Time.deltaTime);
    }

    void Update()
    {
        move2D = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        fireShoot = Input.GetButtonDown("Fire1");
        
        if (move2D != Vector2.zero)
        {
            animComponent.SetFloat ("movX",move2D.x);
            animComponent.SetFloat ("movY",move2D.y);
            animComponent.SetBool ("Walk",true);  
        }
        else
        {
            animComponent.SetBool ("Walk",false);
           
        }

        if ( weaponOnGround.activeInHierarchy == false )
        {
            
              Debug.Log("Cambiar a animShoot");
              animComponent.SetBool ("Walk",false);
              animComponent.SetBool("Fire" , true);
            if (rbPlayer.transform.x != rbPlayer.transform.y)
            {  
              
              
            }  
            else 
            {
                 animComponent.SetBool("Fire",false);
            }       
        }
           
       

    }   

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Weapon1"))
        {
            Debug.Log("PlayerTocaArma");
            weaponOnGround.gameObject.SetActive(false);
        }
    }

    
}
