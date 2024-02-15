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

        
        curveDirection = new Vector3(-1f,-0.1f,0) * curveStrength; // �����̴�
        Invoke("ApplyCurveForce", 0.4f);
    }
    // �߱� ���� ���� ����Ʈ
    private void ApplyCurveForce()
    {
        rb.AddForce(curveDirection, ForceMode.Impulse);
    }
}
