using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArrow : MonoBehaviour
{
    Button but;

    public Transform Catcher;

    public GameObject[] But;

    FastBall fast;
    CuvBall cuv;
    SliderBall slider;

    GameObject BallPosi;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        GameObject CatcherTr = GameObject.FindGameObjectWithTag("BallPosi");
        Catcher = CatcherTr.GetComponent<Transform>();

        fast = FindAnyObjectByType<FastBall>();
        cuv = FindAnyObjectByType<CuvBall>();
        slider = FindAnyObjectByType<SliderBall>();
        BallPosi = GameObject.FindGameObjectWithTag("BallPosi");

    }

    // Update is called once per frame
    void Update()
    {
        if (ScrollController.scrolling)
        {
            for (int i = 0; i < But.Length; i++)
            {
                But[i].gameObject.SetActive(false); // 4개 버튼 비활성화
                BallPosi.gameObject.SetActive(false);
                material.color = new Color(material.color.r, material.color.g, material.color.b, 0f); // 알파 값을 0.5로 설정합니다.
            }
        }
        if (!fast._isThrowing && !cuv._isCuvThrowing && !slider._isSliderThrowing)
        {
            for (int i = 0; i < But.Length; i++)
            {
                But[i].gameObject.SetActive(true);
                BallPosi.gameObject.SetActive(true);
                material.color = new Color(material.color.r, material.color.g, material.color.b, 0.4f); // 알파 값을 0.5로 설정합니다.

            }
        }
        else
        {
            return;
        }
    }

    public void OnCklickLeft()
    {
        Catcher.Translate(0.1f, 0, 0);
    }

    public void OnCklickRight()
    {
        Catcher.Translate(-0.1f, 0, 0);
    }
    public void OnCklickUp()
    {
        Catcher.Translate(0, 0.1f, 0);
    }

    public void OnCklickDown()
    {
        Catcher.Translate(0, -0.1f, 0);
    }
}
