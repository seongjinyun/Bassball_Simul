using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool isTriggerProcessed = false;
    bool st;
    bool ba;

     Animator UmpireAnim;
    private void Awake()
    {
        UmpireAnim = GameObject.FindGameObjectWithTag("AnimUm").GetComponent<Animator>();
    }
    private void Start()
    {
        st = false;
        ba = false;
    }
    private void Update()
    {

    }

    // 땅예 공이 닿았을 때 대처해야함. - 어케하징..


    private void OnCollisionEnter(Collision collision)
    {
/*        if (collision.gameObject.CompareTag("Ground") && !ba && !st)
        {
            SBOCount.BallCount++;
            Destroy(gameObject);
            Debug.Log("(Ground)Ball");

        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Strike_Z"))
        {
            if (!isTriggerProcessed && !ba)
            {
                SBOCount.StrikeCount++;
                UmpireAnim.SetTrigger("Go");
                Debug.Log("Strike~~!");
                Destroy(gameObject);

                isTriggerProcessed = true;
                st = true;

            }

        }
        if (other.gameObject.CompareTag("Ball_Z"))
        {
            if (!isTriggerProcessed && !st)
            {
                SBOCount.BallCount++;
                Debug.Log("Ball");
                Destroy(gameObject);

                isTriggerProcessed = true;
                ba = true;
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        isTriggerProcessed = false;
    }
}
