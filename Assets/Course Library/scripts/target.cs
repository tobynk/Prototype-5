using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody targetRb; 
    private float minspeed=12;
    private float maxspeeed=16;
    private float maxtorque=10;
    private float xrange=4;
    private float yspawnpos=-2;
    // Start is called before the first frame update
    void Start()
    {
        targetRb=GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(randomtorque(),randomtorque(),randomtorque(), ForceMode.Impulse);
        transform.position=Randomspawnpos();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minspeed,maxspeeed);
    }
    float randomtorque()
    {
        return Random.Range(-maxtorque,maxtorque);
    }
    Vector3 Randomspawnpos()
    {
        return new Vector3(Random.Range(-xrange,xrange),yspawnpos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
