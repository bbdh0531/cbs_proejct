using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    protected Animator anim;

    protected void IntPlayAnimation(string name, int animation_id)
    {
        anim.SetInteger(name, animation_id);
    }

    protected void BoolPlayAniamtion(string name, bool value)
    {
        anim.SetBool(name, value);
    }

    protected void FloatPlayAnimation(string name, float value)
    {
        anim.SetFloat(name, value);
    }

    protected void IdleAnimation()
    {
        anim.SetInteger("id", 0);
    }

    protected void TriggerAnimation(string name)
    {
        anim.SetTrigger(name);
    }

}
