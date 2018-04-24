using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    private double _timeLeft;
    public Slider timeBar;
    public GameObject timeBarFill;
    
    [System.NonSerialized]
    public Image fillBar;
    [System.NonSerialized]
    public bool tRun;

    private void Start()
    {
        fillBar = timeBarFill.GetComponent<Image>();
        timeBar.gameObject.SetActive(false);
        tRun = false;
        _timeLeft = 10.0;
        timeBar.value = (float)_timeLeft;
    }

    private void Update()
    {
        if (tRun)
        {
            timeBar.gameObject.SetActive(true);
            _timeLeft -= Time.deltaTime;
            timeBar.value = (float)_timeLeft;
            fillBar.color = Color.HSVToRGB(Mathf.Lerp(0, 0.334f, (float)_timeLeft/10), 1, 1);
            if (_timeLeft <= 0)
            {
                StopTimer();
            }
        }
    }

    public void StopTimer()
    {
        tRun = false;
        timeBar.gameObject.SetActive(false);
    }

    public void StartTimer() {
        tRun = true;
    }

    public void RestartTimer() {
        _timeLeft = 10;
        tRun = false;
    }

    public double GetTimeLeft()
    {
        return _timeLeft;
    }
}