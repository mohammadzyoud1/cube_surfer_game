using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class ScrollingUVs_Layers : MonoBehaviour
{

	public AudioSource fire_sound;
	public ParticleSystem smoke;

	public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
	public string textureName = "_MainTex";
    public player_movie mov;
    Vector2 uvOffset = Vector2.zero;
	private void Awake()
	{	
		
		fire_sound = GetComponent<AudioSource>();
        mov = GameObject.FindObjectOfType<player_movie>();
    }
	void LateUpdate()
	{
		uvOffset += (uvAnimationRate * Time.deltaTime);
		if (GetComponent<Renderer>().enabled)
		{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset(textureName, uvOffset);
		}
	}



	private void OnTriggerStay(Collider other)

	{
		if (!other.CompareTag("main"))
		{

            fire_sound.Play();
            smoke.Play();
			Vector3 pre = new Vector3(other.GetComponent<BoxCollider>().size.x, other.GetComponent<BoxCollider>().size.y, other.GetComponent<BoxCollider>().size.z);
			Vector3 next = new Vector3(0,0,0);
			Vector3 past = new Vector3(other.GetComponent<Transform>().localScale.x, other.GetComponent<Transform>().localScale.y,
			other.GetComponent<Transform>().localScale.z);
			Vector3 later = new Vector3(0, 0, 0);
            other.GetComponent<Transform>().localScale = Vector3.Lerp(past, later, Time.deltaTime * 50f);
            other.GetComponent<BoxCollider>().size = Vector3.Lerp(pre, next, Time.deltaTime*50f );
			other.GetComponent<Transform>().parent=null;
            	mov.pirall.Remove(other.gameObject);
            	mov.h = mov.pirall.Count - 1;
            	mov.counter = mov.pirall.Count;
            Destroy(other.gameObject);

        }
		else
		{
			SceneManager.LoadScene("game_over");
			mov.velocityforward = 0;
		}
	}

}