using System.Collections;
using UnityEngine;

public class FastBall : MonoBehaviour
{
    public GameObject BaseballPrefab;
    public Transform BallSpawnPoint;
    public Transform CatcherTarget;

    public float throwSpeed = 50;
    public float targetHeight = 1.5f;

    public Animator _animator; // 안넣
    public bool _isThrowing; // 안넣

    public GameObject subCamera;
    Vector3 initialBallPosi;


    public bool Balltrue = false;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isThrowing = false;
        initialBallPosi = CatcherTarget.transform.position;

    }

    private void Update()
    {
        if (!_isThrowing && Input.GetKeyDown(KeyCode.S) && ScrollController.scrolling)
        {
            _isThrowing = true;
            Balltrue = true;
            subCamera.gameObject.SetActive(false); // 서브캠 비활성화

        }
    }

    public void ThrowBall()
    {
        if (_isThrowing)
        {
            GameObject ball = Instantiate(BaseballPrefab, BallSpawnPoint.position, BallSpawnPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            // 고정된 높이로 설정하지 않고 포수의 위치에서 일정한 높이를 유지하도록 수정
            Vector3 targetPosition = new Vector3(CatcherTarget.position.x, CatcherTarget.position.y + targetHeight, CatcherTarget.position.z);
            Vector3 direction = (targetPosition - BallSpawnPoint.position).normalized;

            // ThrowSpeed를 고려하여 설정
            rb.velocity = direction * throwSpeed;

            // 공에 아래쪽 회전을 추가하여 직구 구현
            rb.angularVelocity = new Vector3(throwSpeed * 5, 0, 0);

            // 공의 리지드바디 drag 값을 0.5로 설정
            rb.drag = 0.5f;


            StartCoroutine(DestCam());
        }
    }

    IEnumerator DestCam()
    {
        yield return new WaitForSeconds(4f);
        _isThrowing = false;

        Balltrue = false;
        CatcherTarget.transform.position = initialBallPosi;
        subCamera.gameObject.SetActive(true); // 서브캠 활성화
    }

    public void SetThrowSpeed(float speed)
    {
        throwSpeed = speed;
    }

    public bool IsThrowing()
    {
        return _isThrowing;
    }
}
