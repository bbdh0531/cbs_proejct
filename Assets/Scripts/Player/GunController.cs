using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]GameObject _bullet_prefabs;
    [SerializeField]Transform fire_pos;

    Vector3 recolie_pos;
    Vector3 cur_fire_pos;
    
    bool isRelaod = false;

    AudioSource audio_source;

    public float min_x_recolie_value;
    public float min_y_recolie_value;
    public float max_recoile_x_value;
    public float max_recoile_y_value;

    public int cur_ammo;
    public int max_ammo;

    private Gun cur_gun;

    public Gun[] weapones;


    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        cur_fire_pos = fire_pos.position;
        cur_ammo = max_ammo;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Reload();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            Shooting();
        else
            StartCoroutine(GunIdle());
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isRelaod)
            StartCoroutine(Reloading());
    }

    void Shooting()
    {
        if (!isRelaod)
        {
            if (cur_ammo > 0)
                StartCoroutine(Shot());
        }
    }

    IEnumerator Shot()
    {
        GameObject _bullet = PoolingManager.instance.SetPoolingOn();
        Bullet _tmp = _bullet.GetComponent<Bullet>();
        _tmp.dir_rot = fire_pos.forward;
        _tmp.transform.position = fire_pos.position;
        cur_ammo--;
        PlaySE();
        StopAllCoroutines();
        StartCoroutine(Recoil());
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator GunIdle()
    {
        Debug.Log("Idle"+ fire_pos.position);
        fire_pos.position = cur_fire_pos;
        yield return null;
    }

    //�ݵ�����
    IEnumerator Recoil()
    {
        float cur_recolie_x = Random.Range(min_x_recolie_value, max_recoile_x_value);
        float cur_recolie_y = Random.Range(min_y_recolie_value, max_recoile_y_value);
        recolie_pos.Set(cur_recolie_x, cur_recolie_y, 0.0f);
        fire_pos.position += Vector3.Lerp(fire_pos.position, recolie_pos, 0.4f);
        Debug.Log("fire_pos position"+ fire_pos.position);
        Debug.Log("recolie_value_x: "+cur_recolie_x+ "recolie_value_y: " + cur_recolie_y);
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator Reloading()
    {
        isRelaod = true;
        cur_ammo = max_ammo;
        PlaySE();
        yield return new WaitForSeconds(1.0f);
        isRelaod = false;
    }

    void PlaySE(AudioClip _clip = null)
    {
        if (_clip != null)
        {
            audio_source.clip = _clip;
            audio_source.Play();
        }
        else
            Debug.Log("audio clip is null");
    }

    void SetWeapone(Gun _gun)
    {
        if (_gun != null)
            cur_gun = _gun;
        else
            Debug.Log("Not wepone");
    }
}
