using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    int currentScore = 0;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = currentScore.ToString();
    }

    public void ScoreHit(int hitPoint)
    {
        currentScore += hitPoint;
    }
}
