using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamChange : MonoBehaviour
{
    public Button switchViewBtn;
    public Transform frontView;
    public Transform sideView;
    private bool isFrontView;

    void Start()
    {
        isFrontView = true;
        switchViewBtn.onClick.AddListener(SwitchView);
    }

    void SwitchView()
    {
        isFrontView = !isFrontView;
        transform.position = isFrontView ? frontView.position : sideView.position;
        transform.rotation = isFrontView ? frontView.rotation : sideView.rotation;
    }
}
