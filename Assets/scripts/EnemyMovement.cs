using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//не будет работаь если на компоненте нет типа Enemy

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _wayPointInedx = 0;
    private Enemy _enemy;

    private void Start()
    {
        _target = Waypoints.points[0];

        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy._speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(_target.position, transform.position) <= 0.2f)
        {
            GetWayNextPoint();
        }

        _enemy._speed = _enemy._startSpeed;
    }

    private void GetWayNextPoint()
    {
        if (_wayPointInedx >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStats.TakeAweyLives(1);
            return;
        }

        _wayPointInedx += 1;
        _target = Waypoints.points[_wayPointInedx];
    }
}
