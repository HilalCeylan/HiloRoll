using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceMultiplier;

    private float _moveHorizontal;
    private float _moveVertical;

    private Rigidbody _rigidbody;
    private bool _isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& !_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(x: 0, y: 5f, z: 0, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _isJumping = false;
    }
    
    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * forceMultiplier;
        _moveVertical = Input.GetAxis("Vertical") * forceMultiplier;

        _rigidbody.AddForce(x: _moveHorizontal, y: 0, z: _moveVertical, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("coins"))
            GameObject.Destroy(other.gameObject);
    }
}
