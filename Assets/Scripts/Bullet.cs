using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private MovementPattern movement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 position, Type pattern)
    {
        this.gameObject.SetActive(true);
        this.transform.position = position;
        this.movement = this.gameObject.AddComponent(pattern) as MovementPattern;
    }

    public void DeleteMovement()
    {
        Destroy(this.movement);
    }
}
