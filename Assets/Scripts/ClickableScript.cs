using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableScript : MonoBehaviour {
    public int Cnt {
        get {
            return cnt;
        }
        set {
            if (value < cntMax) {
                cnt = value;
            }
        }
    }
    int cnt = 0;
    public float progress;
    public float Progress {
        get {
            return progress;
        }
        set {
            progress = value;
            if (progress >= fullProgress) {
                progress -= fullProgress;
                Cnt++;
            }
        }
    }


    public int cntMax = 20;
    public Text counter;

    public delegate void VoidClick();
    public event VoidClick clickEvent;

    bool hasProgressBar;
    
    float progressBarCachedY;
    float progressBarMaxX;
    float progressBarMinX;
    [Tooltip("Maximum and starting health of the game object")]
    float fullProgress = 20;
    public RectTransform progressBar;

    public void Awake() {
        SetUpProgresshBar();
    }


    public void SetUpProgresshBar() {
        hasProgressBar = progressBar != null;
        // progress bar setup
        if (hasProgressBar) {
            progressBarCachedY = progressBar.anchoredPosition.y;
            progressBarMaxX = progressBar.anchoredPosition.x;
            progressBarMinX = progressBar.anchoredPosition.x - progressBar.rect.width;
        }
    }

    // Update is called once per frame
    void Update () {
        counter.text = Cnt + "/" + cntMax;
        if (hasProgressBar) {
            progressBar.anchoredPosition = new Vector2(progressBarMinX + ((Progress / fullProgress) * progressBar.rect.width), progressBarCachedY);
        }
	}

    public void AddProgress(int i) {
        Progress += i;
    }

    public void Click() {
        Progress++;
        if (clickEvent != null) {
            clickEvent();
        }
    }
}
