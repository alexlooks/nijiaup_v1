using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject[] startPosition;
	public GameObject[] startAnchor;

	//public GameObject startPositionRight;
	public float waveWait;

	public float scrollSpeed;
	public float tileSizeZ;

	public GameObject[] enemyRoof;
	private Transform startRight;
	private Transform startLeft;
	private GameObject roof;
	private Transform roofTrans;
	private Transform start;
	private Rigidbody2D roofBody;
	private GameObject uiroot;
	private int idx;

	private int flag;


	// Use this for initialization
	void Start () {
		//enemyRoof =  GameObject.FindGameObjectsWithTag("roof");
		uiroot = GameObject.Find ("UI Root");
//		Debug.Log (enemyRoof);
		//startRight = startPositionRight.GetComponent<Transform> ();
		//startLeft = startPositionLeft.GetComponent<Transform>();

		StartCoroutine (SpawnWaves ());
		flag = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (roof != null) {
					
			Transform _t = roof.transform;
	
			float newPosition = Time.deltaTime * scrollSpeed * flag;
			//_t.localRotation = start.localRotation;
			_t.position = _t.position + Vector3.down * newPosition;

			if(idx == 0 && _t.localPosition.x != 70) _t.localPosition = new Vector3(70,_t.localPosition.y,-1000f);
			if(idx == 1 && _t.localPosition.x != -70) _t.localPosition = new Vector3(-70,_t.localPosition.y,-1000f);
			//_t.Translate(Vector3.down * newPosition);
		}
	}

	public void Revert()
	{
		flag = -1;
	}

	public void Stop()
	{
		flag = 0;
	}


	IEnumerator SpawnWaves()
	{
		while (true) {
			Debug.Log ("SpawnWaves....");

			if(roof != null) 
			{
				NGUITools.DestroyImmediate(roof);
				//DestroyObject(roof);
				//Debug.Log (roof);
			}
			idx = Random.Range (0, 2);
//			Debug.Log (idx);
			roof = NGUITools.AddChild (startAnchor[idx], enemyRoof[idx]);
			Transform _t = enemyRoof[idx].transform;
			roof.transform.position = _t.position;
			roof.transform.localScale = _t.localScale;
			roof.transform.localRotation = _t.localRotation;
			roof.SetActive(true);

			yield return new WaitForSeconds (waveWait);
		}
	}
}
