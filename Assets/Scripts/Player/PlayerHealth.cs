using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public Gradient gradient;
    public Image fill;

    //Audio Variables
    public AudioSource audio;
    public AudioClip damageSFX;
    public AudioClip destroySFX;

    // Start is called before the first frame update
    void Start()
    {
        GameController.playerHealth = 5;
        healthBarSlider.maxValue = GameController.playerHealth;
        healthBarSlider.value = GameController.playerHealth;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Missle")
        {
            //Decrease the health of the player by 1
            GameController.playerHealth--;

            //Adjust the health bar
            healthBarSlider.value = GameController.playerHealth;
            fill.color = gradient.Evaluate(healthBarSlider.normalizedValue);

            //If player is not destoryed
            if (GameController.playerHealth >= 1)
            {
                //Play the take damage SFX
                audio.PlayOneShot(damageSFX);
            }
            //If the enemy doesn't have any health left 
            if (GameController.playerHealth == 0)
            {
                //Play the destruction SFX
                audio.PlayOneShot(destroySFX);
                Destroy(gameObject);

            }

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
    }

}
