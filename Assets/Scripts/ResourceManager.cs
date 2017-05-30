using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceManager : MonoBehaviour
{
    public ClickableScript basicClicker;
    public Text idleClicksLabel, levelLabel, tillLevelLabel;

    int clicksPerSecond, level, tillLevel, barrackClicks;

    public void Awake()
    {
        level = 1;
        tillLevel = 1;
        clicksPerSecond = 0;
        basicClicker.clickEvent += BarracksClick;
        StartCoroutine(IdleCoroutine());
    }

    IEnumerator IdleCoroutine () {
        while (true) {
            basicClicker.AddProgress(clicksPerSecond);
            yield return new WaitForSeconds(1f);
        }
    }

    public void Update () {
        idleClicksLabel.text = "Idle Clicks Per Second: " + clicksPerSecond;
        levelLabel.text = "Level: " + level;
        tillLevelLabel.text = "Clicks Until Next Level: " + tillLevel;
    }

    void BarracksClick() {
        tillLevel--;
        if (tillLevel <= 0) {
            clicksPerSecond += 1;
            level++;
            tillLevel = level * level;
        }
    }
}
