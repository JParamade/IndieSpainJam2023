using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NightDayController : MonoBehaviour
{
    //variables
    [SerializeField]
    private GameObject TowerDefenseGO;
    [SerializeField]
    private GameObject CountText;


    [SerializeField]
    private int DayTime = 100;
    private int dayTimeLeft;

    //If totalRounds = 0 game is infinite
    [SerializeField]
    private int totalRounds = 0;
    private int currentRound = 0;
    bool isInfinite = false;

    [SerializeField]
    private string textStart = "Time until night: ";


    //The night countdown starts when the gameobject with this script is re-enabled
    private void OnEnable()
    {
        //checks if the game is infinite or if there is a limit round number
        if (totalRounds == 0)
        {
            isInfinite = true;
            DayStart();
        }
        else if (currentRound > totalRounds)
        {
            //do whatever to finish game here
        }
        else
        {
            DayStart();
        }
    }
    
    void Start()
    {
        
    }


    //Starts the day
    void DayStart()
    {
        StartCoroutine(Timer(DayTime));
        currentRound++;
        Debug.Log(totalRounds);
    }


    //method that calls the script that start the Tower Defense mode (uncomment and rewrite with correct names)
    void ChangeToNight()
    {
        //TowerDefenseGO.GetComponent<ScriptName>().PlayMethod;




        //auto disable until next time
        this.gameObject.SetActive(false);
    }

    //needed to know the seconds left to night
    private void SetDayTimeLeft(int timeLeft)
    {
        dayTimeLeft = timeLeft;
        //this will be for showing users the updated timer
        CountText.GetComponent<Text>().text = textStart + timeLeft;
        
    }

    void SetDayTimeTo(int newTime)
    {
        DayTime = newTime;
    }

    void resetRounds(int roundsNumber)
    {
        currentRound = 0;
        totalRounds = roundsNumber;
    }
    void IncrementRounds(int extraRounds)
    {
        totalRounds += extraRounds;
    }


    //Coroutine that acts as a timer and calls the method that start night phase, also calls the method that updates the visual timer
    IEnumerator Timer(int DayTime)
    {
        int time = DayTime;
        SetDayTimeLeft(time);
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            SetDayTimeLeft(time);
            Debug.Log(time);
        }
        ChangeToNight();
        yield return null;
        
    }
}
