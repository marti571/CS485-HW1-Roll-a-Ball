using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	public Text pauseText;
	private Rigidbody rb;
	private int count;
	public string scene;
	public bool paused;
	//public AudioSource audio;
	public AudioSource effect;
	GameObject[] pauseObjects;
	void Start ()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText();
		winText.text=" ";
		//audio = GetComponent<AudioSource>();
		effect = GetComponent<AudioSource>();
	}

	void Update()
	{
		//uses the P button to pause and unpause game.
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
				//onClick();
			}
			else if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	public void pauseControl()
	{
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
			paused=true;
		}
		else if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
			paused=false;
		}
	}
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
		rb.AddForce (movement*speed);
	} 
	void OnTriggerEnter(Collider other)
	{   //Instead of destroying we are setting the active tag to false
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText();
			effect.Play();
		}
	}
	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
		if(count >= 15)
		{
			winText.text = "You win!";
			//scene = "menu";
			//SceneManager.LoadScene (scene+"");
		}
	}
	
}
