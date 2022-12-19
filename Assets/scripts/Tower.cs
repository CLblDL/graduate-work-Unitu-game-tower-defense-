using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _target;
    private float _distancsFire = 20f;
    private float _speedRotation = 15f;

    public string _enemyTag = "Enemy";
    public Transform _headPrefab;

    void Start()
    {
        
    }

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
        // берется позиция и башня крутится за захваченной целью
        //Lerp должен плавно врашать, но пока это не происходит
        Vector3 direction = _target.position - transform.position;
        Quaternion directionRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_headPrefab.rotation, directionRotation, Time.deltaTime * _speedRotation).eulerAngles;
        _headPrefab.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distancsFire);
    }
}
