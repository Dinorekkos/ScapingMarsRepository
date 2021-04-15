
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
            weaponOnMe.gameObject.SetActive(true);
            fireShoot = Input.GetButtonDown("Fire1");
            //animComponent.SetBool("Fire" , true);
            if (move2D != Vector2.zero)
            {  
               Debug.Log("Cambiar a animShoot");
              animComponent.SetBool ("Walk",false);
              animComponent.SetBool("Fire" , true);
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
