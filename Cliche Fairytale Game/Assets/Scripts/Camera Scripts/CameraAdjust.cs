using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    private CameraController _camera;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;

    private void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _camera.YMaxValue = yMax;
            _camera.YMinValue = yMin;
            _camera.XMaxValue = xMax;
            _camera.XMinValue = xMin;
        }
    }
}
