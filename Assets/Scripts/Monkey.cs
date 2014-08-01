using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {

	private Animator animator;

	private static string STATE_MONKEY = "BaseLayer.Monkey";
	private static string STATE_MONKEYDIE = "BaseLayer.monkeydie";

	private int codeStateMonkey = 0;
	private int codeStateMonkeydie = 0;

//	private Rigidbody2D rigidbodyMonkey;
	private Vector3[] forceAdd;

	private float force;




	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		//rigidbodyMonkey = GetComponent<Rigidbody2D> ();

		codeStateMonkey = Animator.StringToHash (STATE_MONKEY);
		codeStateMonkeydie = Animator.StringToHash (STATE_MONKEYDIE);
		forceAdd = new Vector3[] {Vector3.left,Vector3.right};
	
	}
	
	// Update is called once per frame
	void Update () {

		//rigidbodyMonkey.AddForce (forceAdd[1]*force);
		//rigidbodyMonkey.AddForce (Vector3.down*3);
	}

	void OnTriggerEnter2D(Collider2D colliderInfo)
	{
//		Debug.Log ("!!!!");
		//force = 0;
	}
	

	public void Die ()
	{
		AnimatorStateInfo aniInfo = animator.GetCurrentAnimatorStateInfo (0);
		if (aniInfo.nameHash == codeStateMonkey) {
			animator.SetInteger("state",1);
			animator.Play (codeStateMonkeydie);
			NGUITools.Destroy(this);
		}
	}
}
