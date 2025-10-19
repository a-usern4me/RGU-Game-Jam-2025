using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour {
    [Header("Variables")]
    public Rigidbody playerCharacter;
    //public GameObject enemy;
    private float speed;
    private float slowDown = 0f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public GameObject projectile;
    public Animator anim;

    [Header("Boolean Conditions")]
    public bool worldSpace;
    public bool isGrounded;
    private float attackFrames = 1.0f;
    private float MP;
    private bool fire;
    private bool ice;
    public bool attacking = false;
    public GameObject Object;

    [Header("Health Bar")]
    public int playerHealth = 5;
    //public Slider playerHealthBar;

    void Start()
    {
        playerCharacter = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        speed = 15f;
        jump = new Vector3(0.0f, 5.0f, 0.0f);
        Object.GetComponent<Renderer>().material.color = Color.red;
        GameStateManager.instance.SetMaxHealth(playerHealth);
        GameStateManager.instance.SetMaxHealth(5);
    }

    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("TitleScreen");
        }
        //playerHealthBar.value = GameStateManager.instance.GetPlayerHealth();

        MP = attackFrames;
        MP = Mathf.Round(MP * 10.0f) * 0.1f;

        if (Input.GetKey("w") && attacking == false){
            attackFrames += 0.001f;
        }
        if (attacking = false){
            attackFrames += Time.deltaTime;
        }
    
    }

    void FixedUpdate() {
        if ((attackFrames) <= 0f){
            attackFrames = 0f;
        }

        if ((attackFrames) >= 1f){
            attackFrames = 1f;
        }

        if (Input.GetKey("p")){
            anim.SetBool("Running", false);
            anim.SetBool("Heavy Attack", true);
            attacking = true;
            ice = true;
            Object.GetComponent<Renderer>().material.color = Color.blue;
            attackFrames -= Time.deltaTime;
            anim.Play("Golf Drive");
            playerCharacter.tag = "PlayerIce";
            playerCharacter.velocity = transform.forward * 0;
        
        } else {
            attacking = false;
        }

        if (Input.GetKey("l")){
            anim.SetBool("Running", false);
            anim.Play("Smash");
            fire = true;
            Object.GetComponent<Renderer>().material.color = Color.red;
            playerCharacter.tag = "PlayerFire";
            playerCharacter.velocity = transform.forward * 0;
        } else {
            anim.SetBool("Smash", false);
        }

        //Gravity
        if (isGrounded == false){
            playerCharacter.AddForce(Physics.gravity * 0.5f, ForceMode.Force);
        }

        //Camera
        if (Input.GetKey("a")) {
            transform.Rotate(new Vector3(0, -8, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey("d")) {
            transform.Rotate(new Vector3(0, 8, 0) * Time.fixedDeltaTime * speed, Space.World);
        }

        //Movement
        if (slowDown > 0) {
            slowDown -= Time.deltaTime;
        }

        if (isGrounded == true) {
            if (Input.GetKey("w") && attacking == false) {
                playerCharacter.velocity = transform.forward * speed;
                anim.SetBool("Running", true);
                slowDown = 0.5f;

            } else {
                anim.SetBool("Running", false);
                playerCharacter.velocity = transform.forward * 0;

                if (slowDown <= 0){
                    playerCharacter.velocity = transform.forward * 0;

                }
            }

            if (Input.GetKey("s")){
                playerCharacter.velocity = -transform.forward * 5f;
            }
        }

        //Actions
        if (Input.GetKey("space") && (isGrounded == true)) {
            playerCharacter.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionStay(Collision Collider){
        if (Collider.gameObject.tag == "Terrain"){
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision Collider){
        if (Collider.gameObject.tag == "Terrain"){
            isGrounded = false;
        }
    }

}