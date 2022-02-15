using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    [SerializeField] GameObject contacts_effect;

    private void Start()
    {
        contacts_effect = Resources.Load<GameObject>("Contacts_effect");
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag.Equals("Bullet"))
        {
            Destroy(coll.gameObject);
            ShowEffect(coll);
        }
    }

    void ShowEffect(Collision coll)
    {
        ContactPoint _contact = coll.contacts[0];
        GameObject _bullet = Instantiate(contacts_effect);
        _bullet.transform.position = _contact.point;
        _bullet.transform.rotation = Quaternion.FromToRotation(-Vector3.forward, _contact.normal);
        _bullet.transform.Rotate(new Vector3(90, 0, 0));
    }
}
