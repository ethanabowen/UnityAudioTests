using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    private static Text[] _texts;
    private static float[] _scores;

    void Start()
    {
        _texts = this.GetComponentsInChildren<Text>();
        _scores = new float[_texts.Length];
    }

    public static void AddScore(int scoreIndex)
    {
        Debug.Log($"Adding Score to {scoreIndex}");
        _scores[scoreIndex] += 500;
        _texts[scoreIndex].text = $"Score: {_scores[scoreIndex].ToString()}";

        CheckScore(scoreIndex);
    }

    private static void CheckScore(int scoreIndex)
    {
        if (_scores[scoreIndex] >= 3000)
        {
            Debug.Log($"WINNER - {scoreIndex.ToString()}");
            //win
            QuitGame();
        }
    }

    //TODO: Consider game state management, don't expose this as static
    public static void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}