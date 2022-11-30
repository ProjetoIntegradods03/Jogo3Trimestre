using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Move_Judy : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public bool isJumping;
    Animator anim;
    //private AudioSource sound; 

    private float posicaoPersonagemX;

    private float posicaoEstanteX; 

    private float posicaoEstanteY; 

    private double posicaoLivroX = 4.07; 

    private bool EstanteDestruida;

    public bool TextoRecarregar;

    
    Transform posicaoPersonagem;
    Transform posicaoLivro;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //sound = GetComponent < AudioSource > ();

        posicaoPersonagem = GameObject.Find("Judy").GetComponent<Transform>();
        posicaoLivro = GameObject.Find("Estante de livros").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        posicaoPersonagemX = posicaoPersonagem.position.x;

        if(!EstanteDestruida && posicaoPersonagemX >= posicaoLivroX - 0.5 && posicaoPersonagemX <= posicaoLivroX + 0.5)
        {
           if(Input.GetKeyDown(KeyCode.F))
           {
            Destroy(GameObject.Find("Estante de livros"));
            EstanteDestruida = true;
            Thread.Sleep(2000);
            SceneManager.LoadScene(2);
           }
        }
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        //Direita
        if(Input.GetAxis("Horizontal") > 0f) {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
            //sound.Play();
        }

        //Esquerda
        if(Input.GetAxis("Horizontal") < 0f) {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
            //sound.Play();
        }

        //Parado
        if(Input.GetAxis("Horizontal") == 0f) {
            anim.SetBool("run", false);
        }
    }

    void Jump()
    {
        //Debug.Log; 
        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        isJumping = true;
        //anim.SetBool("jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "isJumping")
        {
            //anim.SetBool("jump", false);
            isJumping = false;
        }
    }
}
