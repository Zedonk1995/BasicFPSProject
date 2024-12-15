using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Owner { get; private set; } = null;

    float speed = 35.0f;
    float timeCreated;
    float lifespan = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody myRigidbody;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.velocity = speed * transform.forward;

        timeCreated = Time.time;
    }

    private void FixedUpdate()
    {
        if ( Time.time >= timeCreated + lifespan )
        {
            Destroy( gameObject );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float damage = 5f;
        var otherObject = collision.gameObject;

        if (otherObject == Owner)
        {
            return;
        }
        
        otherObject.GetComponent<IHealth>()?.OnHit(damage);

        if (otherObject.tag != "Bullet" )
        {
            Destroy(gameObject);
        }
    }

    public void SetOwner( GameObject newOwner )
    {
        Owner = newOwner;
    }

}
