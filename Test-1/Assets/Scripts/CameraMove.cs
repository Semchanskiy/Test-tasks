using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.position = new Vector3(_player._transform.position.x,_transform.position.y,_transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        _transform.position = new Vector3(_player._transform.position.x, _transform.position.y, _transform.position.z);
    }
}
