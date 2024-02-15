using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SBOCount : MonoBehaviour
{
    public static int StrikeCount = 0;
    public static int BallCount = 0;
    public static int OutCount = 0;

    public GameObject[] StrikeImg;
    public GameObject[] BallImg;
    public GameObject[] OutImg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Strike();
        Ball();
        Out();
    }

    void Strike()
    {
        switch (StrikeCount)
        {
            case 1:
                if (StrikeCount == 1)
                {
                    StrikeImg[0].gameObject.SetActive(true);
                }
                break;
            case 2:
                if (StrikeCount == 2)
                {
                    StrikeImg[1].gameObject.SetActive(true);
                }
                break;
            case 3:
                if (StrikeCount > 2)
                {
                    StrikeImg[0].gameObject.SetActive(false);
                    StrikeImg[1].gameObject.SetActive(false);
                    StrikeImg[2].gameObject.SetActive(true);

                    BallImg[0].gameObject.SetActive(false);
                    BallImg[1].gameObject.SetActive(false);
                    BallImg[2].gameObject.SetActive(false);

                    StartCoroutine(fourball());

                    StrikeCount = 0;
                    BallCount = 0;
                    OutCount++;
                }
                break;
        }
    }

    void Ball()
    {
        switch (BallCount)
        {
            case 1:
                if (BallCount == 1)
                {
                    BallImg[0].gameObject.SetActive(true);
                }
                break;

            case 2:
                if (BallCount == 2)
                {
                    BallImg[1].gameObject.SetActive(true);
                }
                break;

            case 3:
                if (BallCount == 3)
                {
                    BallImg[2].gameObject.SetActive(true);
                }break;

            case 4:
                if (BallCount > 3)
                {
                    BallImg[0].gameObject.SetActive(false);
                    BallImg[1].gameObject.SetActive(false);
                    BallImg[2].gameObject.SetActive(false);
                    BallImg[3].gameObject.SetActive(true);

                    StrikeImg[0].gameObject.SetActive(false);
                    StrikeImg[1].gameObject.SetActive(false);

                    StartCoroutine(fourball());
                    StrikeCount = 0;
                    BallCount = 0;
                }
                break;
        }
    }
    IEnumerator fourball()
    {
        yield return new WaitForSeconds(1.5f);
        StrikeImg[2].gameObject.SetActive(false);
        BallImg[3].gameObject.SetActive(false);

    }

    void Out()
    {
        switch (OutCount)
        {
            case 1:
                if (OutCount == 1)
                {
                    OutImg[0].gameObject.SetActive(true);
                }
                break;
            case 2:
                if (OutCount == 2)
                {
                    OutImg[1].gameObject.SetActive(true);
                }
                break;
            case 3:
                if (OutCount > 2)
                {
                    OutImg[2].gameObject.SetActive(true);
                    SceneManager.LoadScene("EndScene");

                }
                break;
        }

    }
}
