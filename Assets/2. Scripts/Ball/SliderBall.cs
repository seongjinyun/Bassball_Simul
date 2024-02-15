using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBall : MonoBehaviour
{
    public GameObject BaseballPrefab;
    public Transform BallSpawnPoint;
    public Transform CatcherTarget;

    public float throwSpeed = 50;
    public float slowSpeed = 30;
    public float targetHeight = 1.5f;
    public float Angle = 45f;

    public Animator _animator; // 안함
    public bool _isSliderThrowing; // 안함

    public GameObject subCamera;
    public bool SliderBalltrue = false;
    Vector3 initialBallPosi;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _isSliderThrowing = false;
        initialBallPosi = CatcherTarget.transform.position;

    }

    void Update()
    {
        if (!_isSliderThrowing && Input.GetKeyDown(KeyCode.D) && ScrollController.scrolling)
        {
            _isSliderThrowing = true;
            SliderBalltrue = true;
            subCamera.gameObject.SetActive(false); // 서브캠 비활성화

        }
    }

    public void ThrowSliderball()
    {
        if (_isSliderThrowing)
        {
            GameObject ball = Instantiate(BaseballPrefab, BallSpawnPoint.position, BallSpawnPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            Vector3 targetPosition = new Vector3(CatcherTarget.position.x, targetHeight, CatcherTarget.position.z);
            Vector3 direction = (targetPosition - BallSpawnPoint.position).normalized * (throwSpeed - slowSpeed);

            rb.velocity = direction;
            rb.angularVelocity = new Vector3(0, 0, -throwSpeed * 5); // 탑스핀 구질이므로 반시계방 회전


            StartCoroutine(DestCam());
        }
    }
    IEnumerator DestCam()
    {
        yield return new WaitForSeconds(4f);
        _isSliderThrowing = false;

        SliderBalltrue = false;
        CatcherTarget.transform.position = initialBallPosi;

        subCamera.gameObject.SetActive(true); // 서브캠 활성화

    }

    public void SetHeight(float Height)
    {
        targetHeight = Height;
    }
    public bool IsCuvThrowing()
    {
        return _isSliderThrowing;
    }
}
