using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {
    public GameObject spell;

    void Start(){

    }

    void Update(){

    }

    void OnCollisionEnter(Collision Collider){
        if (Collider.gameObject.tag == "Terrain"){
            Destroy(this.gameObject);
        }

        /*if (Collider.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
        }*/
    }
}