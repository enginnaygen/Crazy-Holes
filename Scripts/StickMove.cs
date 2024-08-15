using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMove : MonoBehaviour
{

    [SerializeField]float stickMove=0.1f;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-4f, 1f));
    }

    private void Update()
    {
        Destroy(this.gameObject,3.5f);
        if (Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        StickMoves();
    }

    void StickMoves()
    {
        transform.Translate(new Vector2(stickMove,0));
    }
}
