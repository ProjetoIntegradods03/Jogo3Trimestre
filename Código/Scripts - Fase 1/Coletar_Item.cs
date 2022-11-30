using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletar_Item : MonoBehaviour
{
    public LayerMask playerLayer;
    public float radious;
    bool onRadious;
    bool livro;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((livro == false) && (Input.GetKeyDown(KeyCode.E) && onRadious))
    {
       Destroy(gameObject);
       livro = true;
    }
    }
     
 public void Interact()
   {
      Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

      if(hit != null)
      {
          onRadious = true;
      }
      else{
          onRadious = false;
      }
   }

   private void OnDrawGizmosSelected()
   {
       Gizmos.DrawWireSphere(transform.position, radious);
   }
}
