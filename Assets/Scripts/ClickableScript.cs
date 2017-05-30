using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableScript : MonoBehaviour {
    public int cnt = 0;
    public Text counter;

    public delegate void VoidClick();
    public event VoidClick clickEvent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter.text = "Clicks: " + cnt;
	}

    public void Click() {
        cnt++;
        if (clickEvent != null) {
            clickEvent();
        }
    }
}
