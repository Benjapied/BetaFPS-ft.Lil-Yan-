using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFeet : MonoBehaviour
{
    private Player      _player;
    private Vector3     _position;
    private float       _radius;

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();    
        _position = _player.gameObject.transform.position - Vector3.up * 1f;
        _radius = 0.5f;
    }

    private void Update()
    {
        _position = _player.gameObject.transform.position - Vector3.up * 1f;

        Collider[] colliders = Physics.OverlapSphere(_position, _radius);
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.tag == "ground")
            {
                _player.IsGrounded = true;
                return;
            }
        }

        _player.IsGrounded = false;
        return;

    }


}
