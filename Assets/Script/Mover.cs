using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector3.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
