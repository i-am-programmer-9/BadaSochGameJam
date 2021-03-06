﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health,maxHealth;
    public TextMeshProUGUI healthText,maxHealthText;
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        
        anim = gameObject.GetComponentInChildren<Animator>();
        
        InvokeRepeating("decreaseHealth", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0 || maxHealth <= 0)
        //Player Dies
        {
            Debug.Log("Die");
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponentInChildren<CharacterController>().detectCollisions = false;
            gameObject.GetComponentInChildren<Gun>().enabled = false;
            maxHealthText.text = "0";
            healthText.text = "0";
            anim.SetBool("run", false);
            anim.SetTrigger("Die");
            Invoke("destroy", 1f);

        }
    }

    void destroy() {
        gameObject.GetComponentInChildren<LoadScene>().loadScene("Retry");
    }
        void decreaseHealth()
         { 

        if (health > 0)
        {
            maxHealthText.text = maxHealth.ToString();

            if (anim.GetBool("run") && health > 0)
            {
                health -= 3;

            }
            else if (health < maxHealth)
            {
                health++;


            }
            healthText.text = health.ToString();
        }
            else if (health <= 0 || maxHealth <= 0)
            //Player Dies
            {
                Debug.Log("Die");
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                gameObject.GetComponentInChildren<CharacterController>().detectCollisions = false;
             gameObject.GetComponentInChildren<Gun>().enabled = false;
                maxHealthText.text = "0";
                healthText.text = "0";
                anim.SetBool("run", false);
                anim.SetTrigger("Die");
                Invoke("destroy", 1f);

            }
        
         }
    
}
