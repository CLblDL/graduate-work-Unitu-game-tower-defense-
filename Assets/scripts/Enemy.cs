using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 10f;

    private Transform _target;
    private int _wayPointInedx = 0;

    private void Start()
    {
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(_target.position, transform.position) <= 0.2f)
        {
            GetWayNextPoint();
        }
    }

    private void GetWayNextPoint()
    {
        if(_wayPointInedx >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStats.TakeAweyLives(1);
            return;
        }

        _wayPointInedx += 1;
        _target = Waypoints.points[_wayPointInedx];
    }
}
