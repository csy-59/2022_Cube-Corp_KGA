using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public GameObject XRotateObejct;
    public GameObject YRotateObejct;

    [SerializeField] private float limitMinX = -80;
    [SerializeField] private float limitMaxX = 50;
    [SerializeField] private float rotateYSpeed = 100;
    [SerializeField] private float rotateXSpeed = 100;
    private float eulerAngleX;
    private float eulerAngleY;

    private PlayerInput input;
    private Rigidbody rigid;

    public void Awake()
    {
        // 마우스 커서 안보이게, 위치 고정
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        UpdateRotate(input.MouseX, input.MouseY);
    }

    private void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotateYSpeed * Time.fixedDeltaTime;
        eulerAngleX -= mouseY * rotateXSpeed * Time.fixedDeltaTime;

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        rigid.MoveRotation(Quaternion.Euler(rigid.rotation * new Vector3(eulerAngleX, eulerAngleY, 0f)));

        //XRotateObejct.transform.rotation = Quaternion.Euler(eulerAngleX, 0f, 0f);
        //YRotateObejct.transform.rotation = Quaternion.Euler(0f, eulerAngleY, 0f);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
