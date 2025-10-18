using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Cinemachine;

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
    /*public bool dashing = false;
    public bool attacking = false;
    public bool accessibility {get;set;}
    public bool won = false;

    [Header("Health Bar")]
    public int playerHealth = 5;
    public Slider playerHealthBar;

    [Header("Fuel Gauge")]
    private float fuel = 2.0f;
    private float percentage = 0.0f;
    public Slider fuelGauge;
    
    [Header("Particles")]
    public ParticleSystem particle;
    public ParticleSystem dirt;

    [Header("UI")]
    public TMP_Text scoreText;
    //public TMP_Text fuelText;
    public GameObject chainRanking;
    public Sprite burning;
    public Sprite blazing;
    public TMP_Text objective;
   
    [Header("Camera")]
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;

    [Header("Audio")]
    public AudioSource kevinBangers;
    public AudioClip bg;
    public AudioClip victory;*/

    void Start() {
        playerCharacter = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        speed = 15f;
        jump = new Vector3(0.0f, 5.0f, 0.0f);
        /*GameStateManager.instance.SetMaxHealth(5);
        //fuelText.text = GameStateManager.instance.GetFuel().ToString();
        GameStateManager.instance.Refuel(fuel);
        camera1 = GameObject.Find("Follow Camera").GetComponent<CinemachineVirtualCamera>();
        camera2 = GameObject.Find("Victory Camera").GetComponent<CinemachineVirtualCamera>();
        kevinBangers.clip = bg;
        //kevinBangers.Play();*/
    }

    void Update(){
        /*camera1.GetComponent<CinemachineVirtualCamera>().enabled = true;
        camera2.GetComponent<CinemachineVirtualCamera>().enabled = false;

        if (GameStateManager.instance.enemiesLeft() <= -1){
            won = true; 
        }

        if (won == false){
            playerHealthBar.value = GameStateManager.instance.GetPlayerHealth();
            if (GameStateManager.instance.GetFuel() <= 0f){
                percentage = 0f;

            } else if (GameStateManager.instance.GetFuel() >= 2.0f) {
                percentage = 100f;
            } else {
                percentage = GameStateManager.instance.GetFuel()/fuel * 100;
            }
            //fuelText.text = Mathf.Round(percentage).ToString() + "%";
            scoreText.text = GameStateManager.instance.GetChain().ToString();
            fuelGauge.value = percentage;

            if (GameStateManager.instance.GetChain() <= 10){
                chainRanking.SetActive(false);

            } else {
                chainRanking.SetActive(true);

                if (GameStateManager.instance.GetChain() >= 20){
                    chainRanking.GetComponent<Image>().overrideSprite = blazing;
                }
            }

            //Accessibility
            if (Input.GetKeyDown("q")){
                if (accessibility == false){
                    accessibility = true;

                } else {
                    accessibility = false;
                }
            }

            //Instantiation
            GameObject sp;
            Rigidbody body;
        
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.LeftShift) && GameStateManager.instance.GetFuel() > 0){
                sp = Instantiate(projectile, playerCharacter.transform.position + (transform.forward * 2) + (transform.up * 2), Quaternion.identity);
			    body = sp.AddComponent (typeof (Rigidbody)) as Rigidbody;
			    body.AddRelativeForce (playerCharacter.transform.forward.normalized * 2000);
                GameStateManager.instance.expendFuel(1.5f);
		    }

        } else {
            //Victory Screen
            if (kevinBangers.clip == bg){
                kevinBangers.clip = victory;
                kevinBangers.Play();
            }
            camera1.GetComponent<CinemachineVirtualCamera>().enabled = false;
            camera2.GetComponent<CinemachineVirtualCamera>().enabled = true;
            anim.SetBool("Victory", true);
            anim.Play("Victory");
        }*/
    }

    void FixedUpdate() {
        /*if (won == false){*/
        GameObject sp;
        Rigidbody body;

        if (Input.GetKey("p")){
            anim.Play("Golf Drive");
            playerCharacter.velocity = transform.forward * 0;

            sp = Instantiate(projectile, playerCharacter.transform.position + (transform.forward * 2) + (transform.up * 2), Quaternion.identity);
            body = sp.AddComponent(typeof(Rigidbody)) as Rigidbody;
            body.AddRelativeForce(playerCharacter.transform.forward.normalized * 2000);
            //GameStateManager.instance.expendFuel(1.5f);

        }

        if (Input.GetKey("f")){
            anim.Play("Goalkeeper Diving Save");
            playerCharacter.velocity = transform.forward * 0;
            playerCharacter.AddForce(Vector3.right * 2000);
            
        }

        else{
            anim.SetBool("Heavy Attack", false);
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
            if (Input.GetKey("w")) {
                //anim.SetBool("Heavy Attack", false);
                playerCharacter.velocity = transform.forward * speed;
                anim.SetBool("Running", true);
                slowDown = 0.5f;

            } else {
                anim.SetBool("Running", false);
                playerCharacter.velocity = transform.forward * 0;

                if (slowDown <= 0){
                    playerCharacter.velocity = transform.forward * 0;

                } /*else {
                    dirt.Play();
                }*/
            }

            if (Input.GetKey("s")){
                playerCharacter.velocity = -transform.forward * 5f;
            }

            /*//Dash
            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftShift) && GameStateManager.instance.GetFuel() > 0){
                GameStateManager.instance.expendFuel(Time.deltaTime);
                playerCharacter.velocity = transform.forward * 0;
                particle.Play();

                if (accessibility == true){
                    enemy = GameObject.FindWithTag("Enemy");
                    playerCharacter.transform.LookAt(enemy.transform);

                }

                anim.SetBool("Running", true);
                dirt.Play();
                this.GetComponent<AudioSource>().Play();
                playerCharacter.AddForce(transform.forward.normalized * 2000);
                dashing = true;

            } else {
                dashing = false;
                particle.Stop();
            }*/

        }

        //Actions
        if (Input.GetKey("space") && (isGrounded == true)) {
            playerCharacter.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            /*anim.SetBool("Jumping", true);*/
            /*dirt.Stop();*/
        }

        /*if (Input.GetKey(KeyCode.Mouse0) && dashing == false){
            anim.Play("Attack1");
            attacking = true;
            particle.Play();

        } else {
            attacking =  false;
        }*/
    }
    void OnCollisionStay(Collision Collider){
        if (Collider.gameObject.tag == "Terrain"){
            isGrounded = true;
            /*anim.SetBool("Jumping", false);*/
        }
    }
    
    //Attacks
    void OnCollisionEnter(Collision Collider){
        /*if (Collider.gameObject.tag == "Enemy" && dashing == true){
            anim.SetBool("Attacking", true);
            
        } else {
            anim.SetBool("Attacking", false);
        }*/
    }

    void OnCollisionExit(Collision Collider){
        if (Collider.gameObject.tag == "Terrain"){
            isGrounded = false;
        }
    }

}