using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceController : MonoBehaviour
{
    public static int CurrentScore = 0;
    public static int HighScore = 0;
    [SerializeField] private TMP_Text Tracker;

    void Update()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }

        Tracker.SetText("Current Score: " + CurrentScore + "\nHigh Score: " + HighScore);
    }
}
