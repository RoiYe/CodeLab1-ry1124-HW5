using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    public Text highScoreText;

    string highScoreTemplate = 
        "Game clear!!!\n\n" +
        "Your Time \n" + 
        "<score>\n\n" +
        "Shortest Time\n" +
        "<highScores>";

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.UpdateHighScores();

        string displayText = highScoreTemplate.Replace("<score>", (int)GameManager.instance.timer + "");

        string highScoreString = "";

        List<string> hsNames = GameManager.instance.highScoreNames;
        List<float>  hsNums  = GameManager.instance.highScoreNums;

        for (int i = 0; i < hsNames.Count; i++){
            highScoreString += hsNames[i] + " " + (int)hsNums[i] + "\n";
        }

        displayText = displayText.Replace("<highScores>", highScoreString);

        Debug.Log("displayText: " + displayText);

        highScoreText.text = displayText;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            GameManager.instance.Reset();
            SceneManager.LoadScene("Level1");
        }
    }
}
