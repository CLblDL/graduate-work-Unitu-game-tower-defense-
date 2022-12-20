using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _target;

    [Header("ттх башни")]

    private float _distancsFire = 20f;
    public float _fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Захват цели")]

    public string _enemyTag = "Enemy";
    public Transform _headPrefab;
    private float _speedRotation = 5f;

    [Header("Для выстрела")]

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
        
        if (_target == null)
        {
            StartCoroutine(UpdateTarget());
            return;
        }

        LockTargetOnEnemy();

        if(_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }
        _fireCountdown -= Time.deltaTime;
        
    }

    private void LockTargetOnEnemy()
    {
        // берется позиция и башня крутится за захваченной целью
        //Lerp должен плавно врашать, но пока это не происходит
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion directionRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _headPrefab.rotation = Quaternion.Lerp(_headPrefab.rotation, directionRotation, Time.deltaTime * _speedRotation);

        //Vector3 rotation = Quaternion.Lerp(_headPrefab.rotation, directionRotation, Time.deltaTime * _speedRotation).eulerAngles;
        //_headPrefab.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
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
