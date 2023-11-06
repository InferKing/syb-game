using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed = 20f;
    [SerializeField] private float _minHeight = 20f, _maxHeight = 40f;
    [SerializeField] private float _maxDistancePointX, _maxDistancePointZ;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mw = Input.GetAxis("Mouse ScrollWheel");
        Vector3 movement = new Vector3(-verticalInput, 0f, horizontalInput) * _cameraSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, _minHeight, _maxHeight),
            transform.position.z);
        if (transform.position.y < _minHeight + 0.2f && mw > 0.01f || transform.position.y > _maxHeight - 0.2f && mw < -0.01f)
        {
            mw = 0;
        }
        transform.Translate(transform.forward * mw * _cameraSpeed, Space.World);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -_maxDistancePointX, _maxDistancePointX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -_maxDistancePointZ, _maxDistancePointZ)
            );
    }   

}
