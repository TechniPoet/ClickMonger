using UnityEngine;

public class MortalScript : MonoBehaviour
{
    bool hasHealthBar;
    bool dead = false;
    
    // Health
    public float health;
    float healthBarCachedY;
    float healthBarMaxX;
    float healthBarMinX;
    [Tooltip("Maximum and starting health of the game object")]
    public float maxHealth;
    public RectTransform healthBar;

    public void Awake()
	{
        SetUpHealthBar();
	}


    public void SetUpHealthBar () {
        hasHealthBar = healthBar != null;
        // Health bar setup
        if (hasHealthBar) {
            healthBarCachedY = healthBar.anchoredPosition.y;
            healthBarMaxX = healthBar.anchoredPosition.x;
            healthBarMinX = healthBar.anchoredPosition.x - healthBar.rect.width;
        }
    }

    public void Update () {
        if (hasHealthBar) {
            healthBar.anchoredPosition = new Vector2(healthBarMinX + ((health / maxHealth) * healthBar.rect.width), healthBarCachedY);
        }
    }


    public void TakeDamage(float amt) {
        health -= amt;
        if (health <= 0) {
            health = 0;
            dead = true;
        }
    }
}
