using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _target;

    [Header("��� �����")]

    public float _distancsFire = 20f;
    public float _fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("������ ����")]

    private string _enemyTag = "Enemy";
    public Transform _headPrefab;
    private float _speedRotation = 15f;

    [Header("��� ��������")]

    public GameObject _bulletPrefabs;
    public Transform _firePoint;


    private IEnumerator UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortDistatnce = Mathf.Infinity;
        GameObject nearEnemy = null;
        foreach (GameObject enemi in enemies)
        {
            float distatnsFoEnemy = Vector3.Distance(transform.position, enemi.transform.position);
            if(distatnsFoEnemy < shortDistatnce)
            {
                shortDistatnce = distatnsFoEnemy;
                nearEnemy = enemi;
            }
        }

        if(nearEnemy != null && shortDistatnce <= _distancsFire)
        {
            _target = nearEnemy.transform;
        }
        else
        {
            _target = null;
        }

        yield return new WaitForSeconds(0.5f);
    }

    void Update()
    {
        StartCoroutine(UpdateTarget());

        if (_target == null)
        {
            return;
        }
        // ������� ������� � ����� �������� �� ����������� �����
        //Lerp ������ ������ �������, �� ���� ��� �� ����������
        Vector3 direction = _target.position - transform.position;
        Quaternion directionRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_headPrefab.rotation, directionRotation, Time.deltaTime * _speedRotation).eulerAngles;
        _headPrefab.rotation = Quaternion.Euler(-90f, rotation.y, 0f);

        if(_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }
        _fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(_bulletPrefabs, _firePoint.position, _firePoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();

        if(bullet != null)
            bullet.FindTargetEnemy(_target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distancsFire);
    }
}
