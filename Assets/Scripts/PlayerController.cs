using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	public GameObject left;
	public GameObject right;
	public GameObject start;

	public GameObject[] foreground;
	public GameObject gameController;
	public float scrollSpeed;
	public float tileSizeZ;



	private Rigidbody2D rigidBody;
//	private BoxCollider2D boxCollider;
	private Animator animator;
	private bool forceFlag = true;

	private static string STATE_NIJIA = "BaseLayer.nijia";
	private static string STATE_NIJIARUN = "BaseLayer.nijiarun";
	private static string STATE_NIJIADIE = "BaseLayer.nijiadie";

	private int codeStateNijia = 0;
	private int codeStateNijiarun = 0;
	private int codeStateNijiadie = 0;


	private Vector3 pstart;
	private Vector3 pend;
	private Vector3 pcenter;






	private float forceUp, forceRight;
	private Transform target;//目标位置物体


	// Use this for initialization
	void Start () {
		//player = GameObject.Find("Player");
		animator = player.GetComponent<Animator> ();
		rigidBody = player.GetComponent<Rigidbody2D> ();
//		boxCollider = player.GetComponent<BoxCollider2D> ();

		target = player.GetComponent<Transform> ();
		forceUp = 4f;
		forceRight = 5f;

		codeStateNijia = Animator.StringToHash (STATE_NIJIA);
		codeStateNijiarun = Animator.StringToHash (STATE_NIJIARUN);
		codeStateNijiadie = Animator.StringToHash (STATE_NIJIADIE);



		
	}
	
	// Update is called once per frame
	void Update () {

		AnimatorStateInfo aniInfo = animator.GetCurrentAnimatorStateInfo (0);
	
		if(aniInfo.nameHash == codeStateNijia)
		{

			pcenter = (transform .position + right.transform.position) * 0.5f;
			pcenter -= new Vector3(0, 2, 0);
			if (forceFlag) {
				pstart = transform.position - pcenter;
				pend = right.transform.position - pcenter;
			}
			else{
				pstart = transform.position - pcenter;
				pend = left.transform.position - pcenter;
			}
			float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
			transform.position = Vector3.Slerp(pstart,pend, newPosition);
			transform.position += pcenter;
		}
		else if(aniInfo.nameHash == codeStateNijiarun)
		{
			rigidBody.AddForce(Vector3.up * 0);
			if (Input.GetMouseButtonUp (0)) {
				forceUp = 4f;
				forceRight = 5f;
				forceFlag = !forceFlag;
				animator.SetInteger("state",0);
				animator.Play (codeStateNijia);
			}
		}

	}

	void Die()
	{
//		AnimatorStateInfo aniInfo = animator.GetCurrentAnimatorStateInfo (0);
		//if (aniInfo.nameHash != codeStateNijiadie) {
			animator.SetInteger("state",2);
			animator.Play (codeStateNijiadie);
		//}

		Fgscroller fg0 = foreground[0].GetComponent<Fgscroller> ();
		fg0.Revert ();
		Fgscroller fg1 = foreground[1].GetComponent<Fgscroller> ();
		fg1.Revert ();


		EnemyController em = gameController.GetComponent<EnemyController> ();
		em.Revert ();

		MonkeyController mc = gameController.GetComponent<MonkeyController> ();
		mc.Stop ();

		//NGUITools.Destroy (player);
	}

	void FlyDie()
	{

	}
	void GameOver()
	{
		Fgscroller fg0 = foreground[0].GetComponent<Fgscroller> ();
		fg0.Stop ();
		Fgscroller fg1 = foreground[1].GetComponent<Fgscroller> ();
		fg1.Stop ();

		EnemyController em = gameController.GetComponent<EnemyController> ();
		em.Stop ();
		GameController gc = gameController.GetComponent<GameController> ();
		gc.ShowResult ();

		gameController.SetActive (false);

	}


	void OnTriggerEnter2D(Collider2D colliderInfo)
	{
//		Debug.Log ("OnCollisionEnter2D");
		AnimatorStateInfo aniInfo = animator.GetCurrentAnimatorStateInfo (0);
		if (colliderInfo.gameObject.tag == "monkey") 
		{
			if ( aniInfo.nameHash == codeStateNijia)
			{
				Monkey monkey = colliderInfo.GetComponent<Monkey>();
				monkey.Die();
			}
			else{
				this.Die();
			}
		}
			//Debug.Log (colliderInfo.gameObject.tag);

		else if (colliderInfo.gameObject.tag == "roof" /*&& aniInfo.nameHash != codeStateNijia*/) 
		{

			this.Die();
		
		}


		else if (aniInfo.nameHash == codeStateNijia && colliderInfo.gameObject.tag != "monkey" && colliderInfo.gameObject.tag != "roof") {
			animator.SetInteger("state",1);
			animator.Play (codeStateNijiarun);


		}
		Transform _t = player.GetComponent<Transform> ();
		float _y = forceFlag?180:0;
		_t.localRotation = Quaternion.Euler (0, _y, 0);
		
	}
}
