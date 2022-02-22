using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]GameObject _bullet_prefabs;
    [SerializeField]Transform fire_pos;

    Vector3 recolie_pos;
    Vector3 cur_fire_pos;
    
    [SerializeField]bool isRelaod = false;

    AudioSource audio_source;

    private Gun cur_gun;

    public Gun[] weapones;


    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        cur_fire_pos = fire_pos.position;
        ArmmorCount();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Reload();
        WeaponeChange();
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

    void WeaponeChange()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))//주무기
            SetWeapone(weapones[0]);
        if (Input.GetKeyDown(KeyCode.Alpha1))//보조 무기
            SetWeapone(weapones[1]);
    }

    void Shooting()
    {
        if (!isRelaod)
        {
            if (cur_gun.cur_armmo > 0)
                StartCoroutine(Shot());
        }
    }

    IEnumerator Shot()
    {
        GameObject _bullet = PoolingManager.instance.SetPoolingOn();
        Bullet _tmp = _bullet.GetComponent<Bullet>();
        _tmp.transform.position = fire_pos.position;
        _tmp.transform.rotation = fire_pos.rotation;
        cur_gun.cur_armmo--;
        ArmmorCount();
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
        float cur_recolie_x = Random.Range(cur_gun.min_x_recolie_value, cur_gun.max_recoile_x_value);
        float cur_recolie_y = Random.Range(cur_gun.min_y_recolie_value, cur_gun.max_recoile_y_value);
        recolie_pos.Set(cur_recolie_x, cur_recolie_y, 0.0f);
        fire_pos.position += Vector3.Lerp(fire_pos.position, recolie_pos, 0.4f);
        Debug.Log("fire_pos position"+ fire_pos.position);
        Debug.Log("recolie_value_x: "+cur_recolie_x+ "recolie_value_y: " + cur_recolie_y);
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator Reloading()
    {
        PlaySE();
        isRelaod = true;
        yield return new WaitForSeconds(1.0f);
        cur_gun.cur_armmo = cur_gun.max_armmo;
        ArmmorCount();
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
        {
            cur_gun = _gun;
            ArmmorCount();
        }
        else
            Debug.Log("Not wepone");
    }

    void ArmmorCount()
    {
        UIManager.instance.armmor.text = 
            cur_gun.cur_armmo.ToString() + "/" + cur_gun.max_armmo.ToString();
    }
    
}
