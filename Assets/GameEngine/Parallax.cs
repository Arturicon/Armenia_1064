using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    private float lastCameraX;
    public Transform cameraTransform;
    bool locker = true;
    void Start()
    {
        StartCoroutine(Delay());
    }

    void Update()
    {
        //��� �������, ��� ������� �������� ���� ��� ��� ��������� ���� �� ����� �� �����������, ������ ��������� ������
        //���������� � ������ �������� ��������. ��� ����� �������� � ��������� ��������� ������
        if (locker) 
            return;

        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * speed);
        lastCameraX = cameraTransform.position.x;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        lastCameraX = cameraTransform.position.x;
        locker = false;
    }
}
