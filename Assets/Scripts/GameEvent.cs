﻿using UnityEngine;
using System.Collections;

public class GameEvent : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerEnter2D(Collider2D colliderInfo)
	{
		//if(colliderInfo.gameObject.tag == "moneky")
		Debug.Log (colliderInfo.gameObject.tag);

	}

	public void ResetGame()
	{
		Application.LoadLevel("run");
	}

	public void StartGame()
	{
		Application.LoadLevel("run");
	}

	public void GotoMain()
	{
		Application.LoadLevel("main");
	}


}
