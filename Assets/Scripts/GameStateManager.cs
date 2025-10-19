using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    public static GameStateManager instance = null;
    public int _playerHealth;

    void Start(){

    }

    void Update(){
    
    }
    
    private void Awake(){
        if (instance == null){
        instance = this;

        } else if (instance != this){
            Destroy(gameObject); 
        }
    }

    //Player Health
    public void SetMaxHealth(int val){
        _playerHealth = val;
    }

    public void PlayerDamage(){
        _playerHealth--;
    }

    public int GetPlayerHealth(){
        return _playerHealth;
    }

}