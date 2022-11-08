using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
  
    public player_movie theplayer;
    // Start is called before the first frame update
    void Start()
    {
      
  
        theplayer = GameObject.FindObjectOfType<player_movie>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("cube") || other.CompareTag("main"))
        {

            theplayer.music();
            theplayer.money += 1;
            theplayer.text_gem.text = "gem=" + theplayer.money;
            Destroy(this.gameObject);
        }

    }
}