using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public bool facingRight = true;
	public float MovementSpeed = 1;
	public float JumpForce = 1;
	Animator anim;

	private Rigidbody2D _rigidBody;

	private void Start() 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	
	private void Update()
    {
		var movement = Input.GetAxis("Horizontal");
		if (movement != 0)
		{
			transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
			anim.SetTrigger("run");
		}

		if (!Mathf.Approximately(0, movement))
			transform.rotation = movement < 0 ? Quaternion.Euler(0, 200, 0) : Quaternion.identity;

		if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidBody.velocity.y) < 0.001f)
        {
			_rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
