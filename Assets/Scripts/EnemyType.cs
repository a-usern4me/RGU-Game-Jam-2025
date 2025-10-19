using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyType : MonoBehaviour{
    public Rigidbody Enemy;
    private float timer = 10f;
    public bool fire;
    public GameObject Object;
    public GameObject target;

    void Start(){
        Object.GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChangeType();
            timer += 10f;
        }

        if (fire == true)
        {
            Debug.Log("FIRE");
            target = GameObject.FindWithTag("PlayerIce");
        } else if (fire == false){

            Debug.Log("ICE");
            //target = GameObject.FindWithTag("PlayerFire");
        }
        Enemy.transform.LookAt(target.transform);
        Enemy.velocity = transform.forward * 10;
    }

    void ChangeType(){
        if (fire == true){
            Object.GetComponent<Renderer>().material.color = Color.blue;
            fire = false;
        }
        else if (fire == false){
            Object.GetComponent<Renderer>().material.color = Color.red;
            fire = true;
        }
    }

    void OnCollisionEnter(Collision Collider){
        if (Collider.gameObject.tag == "PlayerFire" && fire == true){
            Destroy(this.gameObject);
        } else if (Collider.gameObject.tag == "PlayerIce" && fire == false) {
            Destroy(this.gameObject);
        }
    }
}