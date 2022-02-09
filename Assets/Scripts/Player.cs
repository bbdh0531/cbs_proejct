using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float move_speed;
    public float rotate_speed;

    public Transform player_cam;

    Transform tr;

    Vector3 dir_pos;
    Vector3 dir_rot;

    float m_x, m_z;
    float t_x, t_y;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerTurn();
    }

    void PlayerMove()
    {
        m_x = Input.GetAxisRaw("Horizontal");
        m_z = Input.GetAxisRaw("Vertical");

        dir_pos.Set(m_x, 0, m_z);

        tr.Translate(dir_pos * move_speed * Time.deltaTime);
    }

    void PlayerTurn()
    {
        float _t_x = Input.GetAxisRaw("Mouse Y");
        float _t_y = Input.GetAxisRaw("Mouse X");

        t_x += rotate_speed * _t_x * Time.deltaTime * 100.0f;
        t_y += rotate_speed * _t_y * Time.deltaTime * 100.0f;

        t_x = Mathf.Clamp(t_x, -80.0f, 80.0f);

        dir_rot.Set(-t_x, t_y, 0);

        tr.eulerAngles = dir_rot;
       // player_cam.eulerAngles = dir_rot;
    }

}