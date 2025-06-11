using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;

    [SerializeField] float time;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int microsecond;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Excute);
        State.Subscribe(Condition.FINISH, Release);
    }

    private void Start()
    {
        StartCoroutine(Measure());
    }

    void Excute()
    {
        StartCoroutine (Measure());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    public IEnumerator Measure()
    {
        while (true)
        {
            time += Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            microsecond = (int)(time * 100) % 100;

            timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, microsecond);

            yield return null;
        }
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Excute);
        State.Unsubscribe(Condition.FINISH, Release);
    }

}
