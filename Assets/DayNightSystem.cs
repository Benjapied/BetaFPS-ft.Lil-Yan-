using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    Light _sun;
    [SerializeField] float _speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        _sun.transform.Rotate(Vector3.right * _speed *  Time.deltaTime);


    }
}
