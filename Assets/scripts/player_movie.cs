using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class player_movie : MonoBehaviour
{

    public TextMeshProUGUI text_gem;
    public GameObject mu;
    public int money;
    public collected_last_box_Blue collected_Last_Box_blue;
    public collected_last_box_Red collected_Last_Box_red;
    public collected_last_box_Green collected_Last_Box_green;
    public collected_last_box_Purbule collected_Last_Box_purbule;
    public collected_last_box_Yellow collected_Last_Box_yellow;
    public float velocityforward;
    public float velocityrightleft;
    private float horizontal;
    public GameObject cube_main;
    public int h;
     public int counter;
    Rigidbody rgb;
    
    public List<GameObject> pirall = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    { 
        money = 0;
        collected_Last_Box_green =GameObject.FindObjectOfType<collected_last_box_Green>();
        collected_Last_Box_blue =GameObject.FindObjectOfType<collected_last_box_Blue>();
        collected_Last_Box_red=GameObject.FindObjectOfType<collected_last_box_Red>();
        collected_Last_Box_purbule=GameObject.FindObjectOfType<collected_last_box_Purbule>();
        collected_Last_Box_yellow=GameObject.FindObjectOfType<collected_last_box_Yellow>(); 
        rgb = GetComponent<Rigidbody>();
        pirall.Add(cube_main);
        counter = pirall.Count;
        h=pirall.Count-1;
        text_gem.text = "gem =" + money;
    }

    // Update is called once per frame
     void Update()
     {
    
     }
    private void FixedUpdate()
    {

        if (pirall[h].layer == 3)
        {
            collected_Last_Box_blue.runner(pirall[h].transform.position);

        }
        else if (pirall[h].layer == 6)
        {
            collected_Last_Box_red.runner(pirall[h].transform.position);
        }
        else if (pirall[h].layer == 7)
        {

            collected_Last_Box_green.runner(pirall[h].transform.position);
        }
        else if (pirall[h].layer == 8)
        {
            collected_Last_Box_purbule.runner(pirall[h].transform.position);
        }
        else if (pirall[h].layer == 9)
        {
            collected_Last_Box_yellow.runner(pirall[h].transform.position);
        }

        else {; }
        if (Input.GetMouseButton(0))
        {
            horizontal = Input.GetAxis("Mouse X");
        }
        else { horizontal = 0; }

        if (transform.position.x + (horizontal * Time.deltaTime * velocityrightleft) < -0.185f && horizontal < 0 || transform.position.x+(horizontal * Time.deltaTime * velocityrightleft) > 0.160 && horizontal > 0) { horizontal = 0; }

        transform.position += new Vector3(horizontal * Time.deltaTime  * velocityrightleft, 0f, velocityforward * Time.deltaTime);
       
        


    }


     private void OnCollisionStay(Collision collision)
   
    {  
      
        float mainpos = pirall.Count*( 0.0436f);
         if (collision.gameObject.CompareTag("cube"))
        {
        
            if (!pirall.Contains(collision.gameObject))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.0436f, transform.position.z);
                collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - mainpos, transform.position.z);
                pirall.Add(collision.gameObject);
                collision.gameObject.transform.SetParent(transform);
                h = pirall.Count - 1;
                counter = pirall.Count;
            }

         }
        
        }



    public void crash(GameObject leaver)
    {
          if (leaver.tag!="main")
         {
            
      //  Debug.Log(leaver.name);            
        pirall.Remove(leaver);
        counter = pirall.Count;
        h = pirall.Count - 1;

        leaver.gameObject.transform.SetParent(null);
         leaver.tag = "Untagged";
            

        }

        else 
        {

         SceneManager.LoadScene("game_over");
            velocityforward = 0;
        }
       

    }
    public void music()
    {
        GameObject muu= Instantiate(mu, transform.position, Quaternion.identity);
        muu.GetComponent<AudioSource>().Play();
        Destroy(muu, 1);
       
    }

    


}
