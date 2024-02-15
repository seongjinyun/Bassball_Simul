using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuvBall : MonoBehaviour
{
    public GameObject BaseballPrefab;
    public Transform BallSpawnPoint;
    public Transform CatcherTarget;

    public float throwSpeed = 50;
    public float slowSpeed = 30;
    public float targetHeight = 1.5f;
    public float Angle = 45f;

    public Animator _animator; // ����
    public bool _isCuvThrowing; // ����

    public GameObject subCamera;
    public bool CuvBalltrue = false;
    Vector3 initialBallPosi;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _isCuvThrowing = false;
        initialBallPosi = CatcherTarget.transform.position;

    }

    void Update()
    {
        if (!_isCuvThrowing && Input.GetKeyDown(KeyCode.A) && ScrollController.scrolling)
        {
            _isCuvThrowing = true;
            CuvBalltrue = true;
            subCamera.gameObject.SetActive(false); // ����ķ ��Ȱ��ȭ

        }
    }

    public void ThrowCurveball()
    {
        if (_isCuvThrowing)
        {
            GameObject ball = Instantiate(BaseballPrefab, BallSpawnPoint.position, BallSpawnPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            Vector3 targetPosition = new Vector3(CatcherTarget.position.x, targetHeight, CatcherTarget.position.z);
            Vector3 direction = (targetPosition - BallSpawnPoint.position).normalized * (throwSpeed - slowSpeed);

            rb.velocity = direction;
            rb.angularVelocity = new Vector3(0, 0, -throwSpeed * 5); // ž���� �����̹Ƿ� �ݽð�� ȸ��


            StartCoroutine(DestCam());
        }
    }
    IEnumerator DestCam()
    {
        yield return new WaitForSeconds(4f);
        _isCuvThrowing = false;

        CuvBalltrue = false;
        CatcherTarget.transform.position = initialBallPosi;

        subCamera.gameObject.SetActive(true); // ����ķ Ȱ��ȭ

    }

    public void SetHeight(float Height)
    {
        targetHeight = Height;
    }
    public bool IsCuvThrowing()
    {
        return _isCuvThrowing;
    }
}
