using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody targetRb; 
    private GameManager gamemanager;
    private float minspeed=12;
    private float maxspeeed=16;
    private float maxtorque=10;
    private float xrange=4;
    private float yspawnpos=-2;
    public int pointvalue;
    public ParticleSystem explosionParticle; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager= GameObject.Find("Gamemanger").GetComponent<GameManager>();
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
        if (gamemanager.IsGameActive)
        {
            Destroy(gameObject);
            gamemanager.UpdateScore(pointvalue);
            Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad"))
        {
        gamemanager.Gameober();
        }
    }
}
