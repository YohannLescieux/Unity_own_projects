using UnityEngine;
using System.Collections;

//Class needed to move and activate animations
public class PlayerControllerScript : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Replace input get key droite ou gauche
		float move = Input.GetAxis ("Horizontal");

		//We want to show animation (Abs because don't need -1)
		anim.SetFloat("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		//Flip pour avoir la bonne direction de mouvement
		if (move > 0 && !facingRight)
			ChangeLook ();
		else if (move < 0 && facingRight)
			ChangeLook ();
	}

	void ChangeLook(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
