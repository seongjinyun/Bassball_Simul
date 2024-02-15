using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderballController : MonoBehaviour
{
    public float curveStrength = 5f;
    private Vector3 curveDirection;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        curveDirection = new Vector3(-1f,-0.1f,0) * curveStrength; // 슬라이더
        Invoke("ApplyCurveForce", 0.4f);
    }
    // 야구 구종 설명 사이트
    private void ApplyCurveForce()
    {
        rb.AddForce(curveDirection, ForceMode.Impulse);
    }
}
