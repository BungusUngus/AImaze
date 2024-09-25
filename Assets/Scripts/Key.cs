using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Key : MonoBehaviour
{
    float _angle = 0f;
    public float rotationSpeed = 40f;
    public float frequency = 1f;
    public float magnitude = 1f;

    public DoorMove[] door;

    private MoveToClick _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<MoveToClick>();
    }

    // Update is called once per frame
    void Update()
    {
        _angle *= rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);

        float yOffset = Mathf.Cos(Time.time * frequency) * magnitude;

        transform.position += new Vector3(0, yOffset, 0) * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == _player.gameObject)
        {
            this.gameObject.SetActive(false);


            for (int i = 0; i < door.Length; i++)
            {
                door[i].CheckDoor();
            }
        }
        
    }
}
