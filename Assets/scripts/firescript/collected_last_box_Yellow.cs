using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collected_last_box_Yellow : MonoBehaviour
{
    public GameObject lav5;
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
        //  StartCoroutine(install_lav( place));
        GameObject play = Instantiate(lav5, place, Quaternion.identity);
        Destroy(play, 0.4f);
    }

}
