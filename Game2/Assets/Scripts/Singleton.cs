using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance {  get { return instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)FindAnyObjectByType(typeof(T));
        }
        else
        {
            Destroy(gameObject);

            return; // DontDestroyOnLoad 까지 실행되는걸 방지하기 위함. (return이 없어도 크게 문제는 없음.)
        }

            DontDestroyOnLoad(instance.gameObject);
    }
}
