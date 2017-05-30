using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtbox : MonoBehaviour {
    public MortalScript mortal;
    public bool player;

    public void TakeDamage(float amt) {
        mortal.TakeDamage(amt);
    }
}
