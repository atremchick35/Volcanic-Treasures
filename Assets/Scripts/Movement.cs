using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
	[FormerlySerializedAs("Speed")][SerializeField] private float speed;
	[FormerlySerializedAs("Jump Force")][SerializeField] private float jumpForce;
	private Rigidbody2D _rigidbody;
	private bool _isContact;

	// Start is called before the first frame update
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Jump") && _isContact)
		{
			_rigidbody.AddForce(new Vector2(0, jumpForce));
			_isContact = false;
		}
	}

	private void FixedUpdate()
	{
		var horizontal = Input.GetAxis("Horizontal");
		_rigidbody.velocity = new Vector2(horizontal * speed, _rigidbody.velocity.y);
		_rigidbody.velocity.Normalize();
	}

	private void OnCollisionEnter2D() => _isContact = true;
}
