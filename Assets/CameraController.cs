using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	public AudioSource audio1;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		audio1 = GetComponent<AudioSource>();
	}
	
	// ULate Update is called once per frame, good for camera 
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}