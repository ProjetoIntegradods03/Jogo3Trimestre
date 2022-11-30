using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao_robô : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("mov"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        //Direita
        if(Input.GetAxis("mov") > 0f) {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        //Esquerda
        if(Input.GetAxis("mov") < 0f) {
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        //Parado
        if(Input.GetAxis("mov") == 0f) {
        }
    }

    void Jump()
    {
        //Debug.Log; 
        if(Input.GetButtonDown("Fire1") && isJumping == false)
        {
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "isJumping")
        {
            isJumping = false;
        }
    }
}