using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d ;

    private void Awake() {
        rb2d = transform.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate() {
        transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
    }
}
