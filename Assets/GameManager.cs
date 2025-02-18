using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text t;

    public void Update()
    {
        if(score == 0)
        {
            //t.text = "You Win!";
        }
    }
    //im too tired to make actual darts...
    public void UpdateScore(string AmtToSub)
    {
        // if(score >= AmtToSub)
        //{
        //score -= AmtToSub;
        StartCoroutine(FlashText());    
        //t.text = AmtToSub;
       // }
        //else
       // {
       //     score = 300;
       //     t.text = "Womp Womp! Score: 300";
        //}
    }
    private IEnumerator FlashText()
    {

        t.text = "BULLSEYE!";
        yield return new WaitForSeconds(1f);
        t.text = "";
    }
}
