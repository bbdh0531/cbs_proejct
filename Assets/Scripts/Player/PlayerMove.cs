using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float move_speed;
    public float rotate_speed;

    public Transform player_cam;

    Transform tr;
    //Move
    Vector3 dir_pos;
    //rotation
    Vector3 player_rot;
    Vector3 camera_rot;

    float t_x, t_y;

    bool isCrouch = false;

    public Vector3 get_dir_pos
    {
        get
        {
            return dir_pos;
        }
    }

    public bool get_isCrouch
    {
        get
        {
            return isCrouch;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        float m_x = Input.GetAxisRaw("Horizontal");
        float m_z = Input.GetAxisRaw("Vertical");

        dir_pos.Set(m_x, 0, m_z);

        tr.Translate(dir_pos * move_speed * Time.deltaTime);
    }

    void Turn()
    {
        float _t_x = Input.GetAxisRaw("Mouse Y");
        float _t_y = Input.GetAxisRaw("Mouse X");

        t_x += rotate_speed * _t_x * Time.deltaTime * 100.0f;
        t_y += rotate_speed * _t_y * Time.deltaTime * 100.0f;

        t_x = Mathf.Clamp(t_x, -80.0f, 80.0f);

        camera_rot.Set(-t_x, 0 , 0);
        player_rot.Set(0, t_y, 0);

        player_cam.localEulerAngles = camera_rot;
        tr.localEulerAngles = player_rot;

        //player_cam.eulerAngles = dir_rot;
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouch = !isCrouch;
        }
    }

}
