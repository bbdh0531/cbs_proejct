using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{

    public List<GameObject> pooling_list = new List<GameObject>();
    public List<GameObject> off_list = new List<GameObject>();
    public List<GameObject> on_list = new List<GameObject>();
    
    [SerializeField]private int pooling_size;

    [SerializeField]private GameObject pooling_target;

    public Transform off;
    public Transform on;

    private float turn_speed;

    public static PoolingManager instance;

    GameObject Create()
    {
        if(pooling_target == null)
            return null;
        GameObject _bullet = Instantiate(pooling_target);
        _bullet.transform.SetParent(off);
        _bullet.gameObject.SetActive(false);
        off_list.Add(_bullet);
        pooling_list.Add(_bullet);
        return _bullet;
    }

    void InitObjcet()
    {
        for(int i = 0; i < pooling_size; i++)
            Create();
        Debug.Log("current pooling size : "+pooling_size);
    }

    GameObject PoolingActive(GameObject _pooling_obj, bool isActive)
    {
        if(isActive)
        {
            GameObject _kim = off_list.Find(o=>o==_pooling_obj);
            if(_kim == null)
                return null;
            _kim.transform.SetParent(on);
            off_list.Remove(_pooling_obj);
            on_list.Add(_pooling_obj);
            return _kim;
        }
        else
        {
            GameObject _kim = off_list.Find(o=>o==_pooling_obj);
            if(_kim == null)
                return null;
            _kim.transform.SetParent(off);
            on_list.Remove(_pooling_obj);
            off_list.Add(_pooling_obj);
            return _kim;
        }
    }

    GameObject PoolingActive(bool _isActive)
    {
        if(_isActive)
        {
            GameObject _bullet = off_list[0];
            _bullet.transform.SetParent(on);
            _bullet.gameObject.SetActive(true);
            off_list.Remove(_bullet);
            on_list.Add(_bullet);
            return _bullet;
        }
        else
        {
            GameObject _bullet = on_list.Find(o=>o==gameObject.activeSelf);
            _bullet.transform.SetParent(off);
            _bullet.gameObject.SetActive(true);
            off_list.Add(_bullet);
            on_list.Remove(_bullet);
            return _bullet;
        }
    }

    public void SetPoolingOn()
    {
        PoolingActive(true);
    }

    public void SetPoolingOff()
    {
        PoolingActive(false);
    }

    public GameObject SetPoolingOff(GameObject _bullet)
    {
        return PoolingActive(_bullet, false);
    }

    public GameObject SetPoolingOn(GameObject _bullet)
    {
        return PoolingActive(_bullet, false);
    }

    // Start is called before the first frame update
    {
        if(instance == null)
            instance = this;
        InitObjcet();
    }
}
