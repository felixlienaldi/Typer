using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(destroyDelay());
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0f);
	}

    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
