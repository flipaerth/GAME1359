using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    public List<Timer> timers = new List<Timer>();

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Timer t in timers)
        {
            if (!t.finished)
            {
                t.Update();
            }
        }
    }
}

// Creating a brand new variable type
public delegate void TimerFunction();
public class Timer
{
    public float duration = 1.0f;
    private float elapsed = 0.0f;

    public bool finished = false;
    public TimerFunction onTimer;

    // Constructor
    public Timer(float d, TimerFunction t)
    {
        duration = d;
        onTimer = t;
    }

    public void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= duration && !finished)
        {
            finished = true;

            if (onTimer != null)
            {
                onTimer();
            }
        }
    }
}
