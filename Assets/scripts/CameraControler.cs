using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private readonly float _moveSpeed = 30f;
    private readonly float _scrollSpeed = 10f;
    private readonly float _minPositionCameraByY = 10f;
    private readonly float _maxPositionCameraByY = 80f;
    private Vector3 _defaultCameraPosition;
    private Vector3 direction;

    private void Start()
    {
        _defaultCameraPosition = transform.position;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BackCameraToDefaultPosition(transform.position);
        }

        transform.Translate(direction * Time.deltaTime * _moveSpeed, Space.World);

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(-verticalMove, 0, horizontalMove) * Time.deltaTime * _moveSpeed, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 750 * _scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, _minPositionCameraByY, _maxPositionCameraByY);
        transform.position = pos;
    }

    private void BackCameraToDefaultPosition(Vector3 cameraPosition)
    {
        //direction = _defaultCameraPosition - transform.position;
        //transform.Translate(direction * Time.deltaTime * _moveSpeed, Space.World);
        transform.position = Vector3.Lerp(cameraPosition, _defaultCameraPosition, 1);
    }
}
