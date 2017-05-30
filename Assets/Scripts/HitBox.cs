using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public float damage;
    public bool player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D col) {
        print("hit");
        hurtbox obj = col.gameObject.GetComponent<hurtbox>();
        if (obj != null && player != obj.player) {
            obj.TakeDamage(damage);
        }
    }
}
