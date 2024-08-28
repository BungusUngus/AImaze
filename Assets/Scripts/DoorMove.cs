using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorMove : MonoBehaviour
{
    public float speed = 5f;
    public bool isOpen = false;
    public bool unlockDoor = false;

    Vector3 _closedPosition = Vector3.zero;
    Vector3 _openPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = transform.position + new Vector3(0f, -4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockDoor == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _openPosition, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, _openPosition) < 0.01f)//can be buggy 
        {
            isOpen = true;
            unlockDoor = false;
        }
    }
}

