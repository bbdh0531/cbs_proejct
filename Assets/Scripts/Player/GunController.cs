using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]GameObject _bullet_prefabs;
    [SerializeField] Transform fire_pos;

    float max_recoile_x_value;
    float max_recoile_y_value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Shot());
        else
            StartCoroutine(GunIdle());
    }

    IEnumerator Shot()
    {
        GameObject _bullet = Instantiate(_bullet_prefabs);
        Bullet _tmp = _bullet.GetComponent<Bullet>();
        _tmp.dir_rot = fire_pos.forward;
        _tmp.transform.position = fire_pos.position;
        StopAllCoroutines();
        StartCoroutine(ShotEffect());
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator GunIdle()
    {
        //반동구현
        yield return null;
    }

    IEnumerator ShotEffect()
    {

        yield return new WaitForSeconds(1.0f);
    }
}
