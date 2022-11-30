using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour
{
       private bool moveCameraRight = false;
       private bool moveCameraLeft = false;
       private float speed = 5;
       private float posicaoPersonagemX;
       private float posicaoCameraX; 
       Transform posicaoPersonagem;
       Transform posicaoCamera;


    // Start is called before the first frame update
    void Start()
    {
        posicaoPersonagem = GameObject.Find("Judy").GetComponent<Transform>();
        posicaoCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        posicaoPersonagemX = posicaoPersonagem.position.x;
        posicaoCameraX = transform.position.x;

        if(posicaoPersonagemX >= posicaoCameraX + 3.87 && posicaoCameraX <= 1.75)
        {
            posicaoCamera.position = posicaoCamera.position + (Vector3.right * 5 * Time.deltaTime);
        }
        else if(posicaoPersonagemX <= posicaoCameraX - 3.87 && posicaoCameraX >= -2)
        {
            posicaoCamera.position = posicaoCamera.position + (Vector3.left * 5 * Time.deltaTime);
        }
        else
        {
            moveCameraLeft = false;
            moveCameraRight = false;
        }
    }
}
