using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float mMouseSensitivyX;
    [SerializeField] private float mMouseSensitivyY;
    private float mRotationX;
    GameObject GetPlayer() { return transform.parent.gameObject; }
    public float GetMouseSensitivyX() { return mMouseSensitivyX; }
    public float GetMouseSensitivyY() { return mMouseSensitivyY; }

    private void Awake()
    {
        mMouseSensitivyX = 10f;
        mMouseSensitivyY = 10f;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Controller.GetInstance().onMouseX += MoveCameraX;
        Controller.GetInstance().onMouseY += MoveCameraY;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;

        Controller.GetInstance().onMouseX -= MoveCameraX;
        Controller.GetInstance().onMouseY -= MoveCameraY;
    }

    public void MoveCameraX()
    {
        float deltaX = Controller.GetInstance().GetMouseX() * mMouseSensitivyX * Time.deltaTime;

        GetPlayer().transform.Rotate(Vector3.up * deltaX);
    }
    public void MoveCameraY()
    {
        float deltaY = Controller.GetInstance().GetMouseY() * mMouseSensitivyY * Time.deltaTime;

        mRotationX -= deltaY;
        mRotationX = Mathf.Clamp(mRotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(mRotationX, 0, 0);
    }
}
