using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    private Rigidbody _rigidbody;
    private bool _isLaunched = false;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _speed, 
            ForceMode.Impulse);
        Destroy(gameObject, 8.0f / _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageble damageble) && _isLaunched)
        {
            damageble.TakeDamage(100);
            PhotonNetwork.Destroy(gameObject);
        }

        if (_isLaunched == false)
        {
            _isLaunched = true;
        }
    }
}