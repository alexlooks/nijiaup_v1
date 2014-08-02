using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private int distance;
	public GameObject[] scoreObj;

	public GameObject resultPanel;
	private Sprite[] mySprite;
	// Use this for initialization
	void Start () {
		scoreObj = GameObject.FindGameObjectsWithTag("score");
	    mySprite = Resources.LoadAll<Sprite> ("Images/number");
	}
	
	// Update is called once per frame
	void Update () {
		distance = (int)(Time.time);
		//Debug.Log (distance); 
		intToPic (distance);
	}

	private void intToPic (int num)
	{
	
		string s = num.ToString ();
		char[] ss = s.ToCharArray ();
		char[] set = new char[]{'0','0','0'}; 
//		string r = "";

		for (int i=set.Length; i>=0; i--) {
			if(i >= ss.Length) continue;
			set[i] = s[ss.Length - i - 1];
		}
//		r = set [2].ToString() + set [1].ToString() + set [0].ToString();
		//Debug.Log (r);
		this.setPicNum (set);



	}

	private void setPicNum(char[] num)
	{

		for (int i =0; i<num.Length; i++) {
			SpriteRenderer render = scoreObj [num.Length - i - 1].GetComponent<SpriteRenderer> ();
			render.sprite = mySprite [int.Parse(num[i].ToString())];
		}

	}

	public void ShowResult()
	{
		resultPanel.SetActive (true);
	}



}
