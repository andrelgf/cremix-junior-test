using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotation Direction")]
    [SerializeField] private Vector3 dir;
    private float speed;

    void Update()
    {
        transform.Rotate(dir, speed * Time.deltaTime);
    }
    public void SetSpeed(float value){
        this.speed = value;
    }
}
