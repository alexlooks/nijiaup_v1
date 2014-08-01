using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour {

	public GameObject[] monkey;

	public float waveWait;
	public GameObject[] fg;
	public GameObject[] wall;
	private ArrayList mkRigidbody2D;
//	private Vector3[] forceAdd;
	private Quaternion[] rotation;
	private int idx;
//	private float force;

	private bool flag;
	// Use this for initialization
	void Start () {
		mkRigidbody2D = new ArrayList ();

//		forceAdd = new Vector3[] {Vector3.left,Vector3.right}; 
		rotation = new Quaternion[] {Quaternion.Euler(0,0,-90),Quaternion.Euler(0,180,-90)};
//		force = 10f;
		flag = true;
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (mkRigidbody2D != null) {
				foreach (Rigidbody2D rigidbody in mkRigidbody2D) {
				rigidbody.AddForce (forceAdd[idx]*force);
					rigidbody.AddForce (Vector3.down*3);
				}
		}
*/

	}

	public void Stop()
	{
		flag = false;
	}

	void OnTriggerEnter2D(Collider2D colliderInfo)
	{
				
	}



	IEnumerator SpawnWaves()
	{
		while (flag) {
			//Debug.Log ("Monkey SpawnWaves....");
	
			idx = Random.Range (0, monkey.Length);
			//idx = 1;
			//Debug.Log (idx);
			GameObject _mk = NGUITools.AddChild (fg[idx], monkey[idx]);
			_mk.transform.localScale = monkey[idx].transform.localScale;
			_mk.transform.localRotation = monkey[idx].transform.localRotation;
			//_mk.transform.position = wall[idx].transform.position;


			_mk.transform.localRotation = rotation[idx];
			if(idx == 0 )
				_mk.transform.position = new Vector3(wall[idx].transform.position.x + 0.6f,10,-2);
			else
				_mk.transform.position = new Vector3(wall[idx].transform.position.x - 0.6f,10,-2);
			_mk.SetActive(true);

			//Rigidbody2D rigidbody = _mk.GetComponent<Rigidbody2D>();

			//mkRigidbody2D[mkRigidbody2D.Length] = rigidbody;
			//mkRigidbody2D.Add(rigidbody);



			/*
			Transform _t = enemyRoof[idx].transform;
			roof.transform.position = _t.position;
			roof.transform.localScale = _t.localScale;
			roof.transform.localRotation = _t.localRotation;
			roof.SetActive(true);
			*/
			yield return new WaitForSeconds (waveWait);
		}
	}
}
