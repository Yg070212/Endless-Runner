using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] float speed = 30.0f;

    static SpeedManager instance;

    public static SpeedManager Instance {  get { return instance; } }

    public float Speed {  get { return speed; } }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
    }
}
