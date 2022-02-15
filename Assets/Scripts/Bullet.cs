using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform tr;
    [SerializeField] float bullet_speed;
    public Vector3 dir_rot;
    
    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        tr.Translate(dir_rot * bullet_speed * Time.deltaTime);
    }

    // Update is called once per frame
}
