using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCanvas : MonoBehaviour
{
    public static float Score;
    public TextMeshProUGUI DisplayText;
    public static float Distancee;
    public TextMeshProUGUI DistanceDisplayText;
    public TextMeshProUGUI DistanceDisplayText1;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0f;
        Distancee = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText.text = Score.ToString();
        if(Distancee != 0f)
        {
            DistanceDisplayText.text = Distancee.ToString() + "m";
            DistanceDisplayText1.text = "Distance:";
        }
        else
        {
            DistanceDisplayText.text = " ";
            DistanceDisplayText1.text = "Is Loading";
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Application.Quit();
            // SceneManager.LoadScene(0);
        }
    }


}
