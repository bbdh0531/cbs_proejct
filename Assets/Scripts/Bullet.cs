using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform tr;
    [SerializeField] float bullet_speed;
    
    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    
    private void Update()
    {
        tr.Translate(Vector3.forward * bullet_speed * Time.deltaTime);
    }

    // Update is called once per frame
}
