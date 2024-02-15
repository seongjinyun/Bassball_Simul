using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    public Scrollbar scrollbar;
    public FastBall fastBall; // FastBall 스크립트 참조 추가
    public CuvBall cuvBall; // CuvBall 스크립트 추가
    public SliderBall sliderBall;



    public static bool scrolling;

    private void Start()
    {
        scrollbar.gameObject.SetActive(false); // 스크롤바 활성화

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scrolling)
            {
                if (fastBall._isThrowing)
                {
                    scrolling = false;
                    float throwSpeed = Mathf.Lerp(20, 60, scrollbar.value);
                    fastBall.SetThrowSpeed(throwSpeed);
                    fastBall._animator.SetTrigger("Button");
                    scrollbar.gameObject.SetActive(false); // 스크롤바 비활성화
                    scrollbar.value = 0;

                }
                else if (cuvBall._isCuvThrowing)
                {
                    scrolling = false;
                    float Height = Mathf.Lerp(4.0f, 8.0f, scrollbar.value);
                    cuvBall.SetHeight(Height);
                    cuvBall._animator.SetTrigger("Button");
                    scrollbar.gameObject.SetActive(false); // 스크롤바 비활성화
                    scrollbar.value = 0; // Value 초기화

                }
                else if (sliderBall._isSliderThrowing)
                {
                    scrolling = false;
                    float Height = Mathf.Lerp(2.0f, 3.6f, scrollbar.value);
                    sliderBall.SetHeight(Height);
                    sliderBall._animator.SetTrigger("Button");
                    scrollbar.gameObject.SetActive(false); // 스크롤바 비활성화
                    scrollbar.value = 0; // Value 초기화
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) && !scrolling && !fastBall.Balltrue && !cuvBall._isCuvThrowing && !sliderBall._isSliderThrowing)
        {
            scrolling = true;
            scrollbar.gameObject.SetActive(true); // 스크롤바 활성화

        }
        else if (Input.GetKeyDown(KeyCode.A) && !scrolling && !cuvBall.CuvBalltrue && !fastBall._isThrowing && !sliderBall._isSliderThrowing)
        {
            scrolling = true;
            scrollbar.gameObject.SetActive(true); // 스크롤바 활성화
        }
        

        if (scrolling)
        {
            scrollbar.value += Time.deltaTime * 1f;
            if (scrollbar.value >= 1)
            {
                scrollbar.value = 0;
            }
        }

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D) && !scrolling && !sliderBall.SliderBalltrue && !fastBall._isThrowing && !cuvBall._isCuvThrowing)
        {
            scrolling = true;
            scrollbar.gameObject.SetActive(true); // 스크롤바 활성화
        }
    }


}