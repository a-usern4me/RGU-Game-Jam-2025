using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyType : MonoBehaviour {
    public Rigidbody Enemy;
    private float timer = 10f;
    public bool fire;

    void Start(){

    }

    void Update(){
        timer -= Time.deltaTime;

        if (timer <= 0){
            ChangeType();
            timer += 10f;
        }
        
        if (fire == true){
            Debug.Log("FIRE");
        } else {
            Debug.Log("ICE");
        }
    }

    void ChangeType(){
        if (fire == true){
            fire = false;
        } else {
            fire = true;
        }
    }
}