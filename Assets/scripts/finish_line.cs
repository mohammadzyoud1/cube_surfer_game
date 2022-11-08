using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_line : MonoBehaviour
{
    public AudioSource sound;
    public ParticleSystem fire;
    // Start is called before the first frame update
    void Start()
    {

        

        sound= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(nextlevel());
        if (other.CompareTag("cube") || other.CompareTag("main")) {
            fire.Play();
            sound.Play();
            
                    
        } 
    }
    IEnumerator nextlevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

