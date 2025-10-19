using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyType : MonoBehaviour
{
    public Rigidbody Enemy;
    private float timer = 10f;
    public bool fire;

    public GameObject Object;

    public GameObject target;

    void Start()
    {
        /*element.GetComponent<MeshRenderer>();
        element.material = flame;*/
        Object.GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        //Enemy.transform.LookAt(target.transform);
        //Enemy.velocity = transform.forward * 10;

        if (timer <= 0)
        {
            ChangeType();
            timer += 10f;
        }

        if (fire == true)
        {
            Debug.Log("FIRE");
            target = GameObject.FindWithTag("PlayerIce");
        }
        else
        {
            Debug.Log("ICE");
            target = GameObject.FindWithTag("PlayerFire");
        }
    }

    void ChangeType(){
        if (fire == true)
        {
            //fire = false;
            //element.material = frost;
            Object.GetComponent<Renderer>().material.color = Color.blue;
            fire = false;
            //Object.GetComponent<MeshRenderer>().material = frost;
            //material.SetFloat("_Color", frost);
            //element.GetComponent<MeshRenderer>().material = frost;
        }
        else if (fire == false)
        {
            //fire = true;
            //Object.GetComponent<MeshRenderer>().material = flame;
            //element.GetComponent<MeshRenderer>().material = flame;
            //element.material = flame;
            Object.GetComponent<Renderer>().material.color = Color.red;
            fire = true;
        }
    }

    void OnCollisionEnter(Collision Collider){
        if (Collider.gameObject.tag == "PlayerFire" && fire == false){
            Destroy(this.gameObject);
        }

        else if (Collider.gameObject.tag == "PlayerIce" && fire == true) {
            Destroy(this.gameObject);
        }
        {
            
        }
        
    }
}