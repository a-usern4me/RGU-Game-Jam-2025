using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyType : MonoBehaviour
{
    public Rigidbody Enemy;
    private float timer = 10f;
    public bool fire;
    public Material flame;
    public Material frost;
    private MeshRenderer element;

    void Start()
    {
        element.GetComponent<MeshRenderer>();
        element.material = flame;    
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
        }
        else
        {
            Debug.Log("ICE");
        }
    }

    void ChangeType(){
        if (fire == true)
        {
            //fire = false;
            element.material = frost;
            //Object.GetComponent<MeshRenderer>().material = frost;
            //material.SetFloat("_Color", frost);
            //element.GetComponent<MeshRenderer>().material = frost;
        }
        else if (fire == false)
        {
            //fire = true;
            //Object.GetComponent<MeshRenderer>().material = flame;
            //element.GetComponent<MeshRenderer>().material = flame;
            element.material = flame;
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