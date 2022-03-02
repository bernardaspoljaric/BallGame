using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject target;
    [Range(0,0.5f)]
    public float speed;
    private void Start()
    {
        speed = 0.1f;
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed) ;
    }
}
