using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimController : Animation
{

    [SerializeField]PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk(player.get_dir_pos);
        Duck();
        Shootting();
    }

    void Walk(Vector3 dir_pos)
    {
        if(dir_pos.x != 0)
        {
            FloatPlayAnimation("Dir_x", dir_pos.x);
        }
        else if(dir_pos.z != 0)
        {
            FloatPlayAnimation("Dir_z", dir_pos.z);
        }
        else//stop
        {
            FloatPlayAnimation("Dir_x", 0);
            FloatPlayAnimation("Dir_z", 0);
        }
    }

    void Duck()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
            BoolPlayAniamtion("isCrouch", player.get_isCrouch);
    }

    void WeaponeChange(int gun_id = 2)
    {
        IntPlayAnimation("", gun_id);//Weapone Change
    }

    void Shootting()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            BoolPlayAniamtion("", true);
        else
            BoolPlayAniamtion("", false);
    }

    void Reaload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            TriggerAnimation("");
    }



}
