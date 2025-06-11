using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float offset = 40.0f;
    [SerializeField] List<GameObject> roads;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Excute);
        State.Subscribe(Condition.FINISH, Release);
    }

    void Excute()
    {
        StartCoroutine(Coroutine());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].transform.Translate(Vector3.back * SpeedManager.Instance.Speed * Time.deltaTime);
            }

            yield return null;
        }
    }

    public void InitializePosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(newRoad);
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Excute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
