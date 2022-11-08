using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collected_last_box_Red : MonoBehaviour
{
    public GameObject lav2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runner(Vector3 place)
    {
       
        GameObject play = Instantiate(lav2, place, Quaternion.identity);
        Destroy(play, 0.4f);
    }

}
