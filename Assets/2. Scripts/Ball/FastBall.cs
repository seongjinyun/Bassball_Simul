using System.Collections;
using UnityEngine;

public class FastBall : MonoBehaviour
{
    public GameObject BaseballPrefab;
    public Transform BallSpawnPoint;
    public Transform CatcherTarget;

    public float throwSpeed = 50;
    public float targetHeight = 1.5f;

    public Animator _animator; // �ȳ�
    public bool _isThrowing; // �ȳ�

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
            subCamera.gameObject.SetActive(false); // ����ķ ��Ȱ��ȭ

        }
    }

    public void ThrowBall()
    {
        if (_isThrowing)
        {
            GameObject ball = Instantiate(BaseballPrefab, BallSpawnPoint.position, BallSpawnPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            // ������ ���̷� �������� �ʰ� ������ ��ġ���� ������ ���̸� �����ϵ��� ����
            Vector3 targetPosition = new Vector3(CatcherTarget.position.x, CatcherTarget.position.y + targetHeight, CatcherTarget.position.z);
            Vector3 direction = (targetPosition - BallSpawnPoint.position).normalized;

            // ThrowSpeed�� ����Ͽ� ����
            rb.velocity = direction * throwSpeed;

            // ���� �Ʒ��� ȸ���� �߰��Ͽ� ���� ����
            rb.angularVelocity = new Vector3(throwSpeed * 5, 0, 0);

            // ���� ������ٵ� drag ���� 0.5�� ����
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
        subCamera.gameObject.SetActive(true); // ����ķ Ȱ��ȭ
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
