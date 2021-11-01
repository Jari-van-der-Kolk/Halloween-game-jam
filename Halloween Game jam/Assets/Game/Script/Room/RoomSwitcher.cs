using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class RoomSwitcher : MonoBehaviour
{
    private Camera _camera;
    private Transform current;
    [SerializeField] private Rect boundarie;
    [SerializeField] private Vector2 size;
    private Transform playerPos;
    
    void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        current = GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Ghost").GetComponent<Transform>();
    }
    
    void Update()
    {
        boundarie = new Rect(current.position, size);

        float2 pPos = new float2(playerPos.position.x, playerPos.position.y);
        if (pPos.x >= boundarie.xMax)
        {
            current.position += new Vector3(_camera.orthographicSize * 2, 0) ;
        }
        if (pPos.x <= boundarie.xMin)
        {
            current.position += new Vector3(-_camera.orthographicSize * 2, 0) ;
        }
        if (pPos.y >= boundarie.yMax)
        {
            current.position += new Vector3(0, _camera.orthographicSize * 1.75f) ;           
        }
        if (pPos.y <= boundarie.yMin)
        {
            current.position += new Vector3(0, -_camera.orthographicSize * 1.75f) ;   
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(boundarie.center, boundarie.size);
    }
}
