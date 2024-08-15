using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]GameObject[] obstacles;
    [SerializeField]Transform spawner;
    float _currentTime;
    

    void Update()
    {
        _currentTime += Time.deltaTime;
       
        if(_currentTime>1.8f)
        {
            Instantiate(obstacles[Random.Range(0, 8)], spawner);
            _currentTime = 0;
        }       
    }
}
