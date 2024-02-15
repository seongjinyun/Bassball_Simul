using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveballController : MonoBehaviour
{
    public float curveStrength = 5f;
    private Vector3 curveDirection;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        curveDirection = Vector3.down * curveStrength; // 이거를 이용해서 왼쪽대각선으로 떨어지게 하는 슬라이더 등등 가능
        //curveDirection = new Vector3(-0.8f,-0.5f,0) * curveStrength; // 슬라이더
        Invoke("ApplyCurveForce", 0.5f);
    }
    //https://adipo.tistory.com/entry/%EC%95%BC%EA%B5%AC-%EA%B5%AC%EC%A2%85-%EA%B6%A4%EC%A0%81-%EA%B7%B8%EB%A6%BD-%ED%8F%AC%EC%8B%AC-%ED%88%AC%EC%8B%AC-%EC%BB%A4%ED%84%B0-%EC%B2%B4%EC%9D%B8%EC%A7%80%EC%97%85-%ED%8F%AC%ED%81%AC-%EC%8A%AC%EB%9D%BC%EC%9D%B4%EB%8D%94-%EC%8A%A4%ED%94%8C%EB%A6%AC%ED%84%B0
    // 야구 구종 설명 사이트
    private void ApplyCurveForce()
    {
        rb.AddForce(curveDirection, ForceMode.Impulse);
    }
}
