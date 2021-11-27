using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayer : MonoBehaviour
{
    [SerializeField]private float angelSpeed;
    [SerializeField]private float movementSpeed;
    [SerializeField]private GameObject rocket;
    [SerializeField]private Transform spawnRocket;
    // Start is called before the first frame update
    Rigidbody2D rb;
    
    void Start()
    {
        Debug.Log("test");
        rb = this.transform.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad0)){
            Debug.Log("terekid");
            Instantiate(rocket,spawnRocket.position,spawnRocket.rotation);
        }
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition( rb.position + (Vector2)(transform.up * Time.deltaTime * movementSpeed) );
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(  rb.position + (Vector2)(-transform.up * Time.deltaTime) * movementSpeed );
        }

        
        if (Input.GetKey(KeyCode.D))
        {
            rb.MoveRotation(rb.rotation + -angelSpeed * Time.fixedDeltaTime);
        }else if (Input.GetKey(KeyCode.A))
        {
             rb.MoveRotation(rb.rotation + angelSpeed * Time.fixedDeltaTime);
        }
    }
}
