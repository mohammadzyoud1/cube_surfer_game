using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    BoxCollider box;
    public player_movie mov;
    // Start is called before the first frame update
    void Awake()
    {
        box=gameObject.GetComponent<BoxCollider>();
    mov= GameObject.FindObjectOfType<player_movie>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }



     private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.gameObject.CompareTag("main"))
        { 
            box.isTrigger = true;
            mov.crash(collision.contacts[0].otherCollider.gameObject);
        }
        
        
    }
    
 


}
