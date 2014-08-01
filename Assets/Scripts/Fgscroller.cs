using UnityEngine;
using System.Collections;

public class Fgscroller : MonoBehaviour {

	public float scrollSpeed;
	public float startpos;
	public float endPos;
	public float tileSizeZ;

	private int flag;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		flag = 1;
		startPosition = transform.position;
	}


	public void Revert()
	{
		flag = -1;
		//scrollSpeed = 2;
	}

	public void Stop()
	{
		flag = 0;
		//scrollSpeed = 2;
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (transform.localPosition.y);

		if( transform.position.y < endPos ) transform.position = startPosition;
		float newPosition = Time.deltaTime * scrollSpeed * flag;
		transform.position = transform.position + Vector3.down * newPosition;	
	}

}
