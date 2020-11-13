using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private float MoveDelay = 0.1f;
    private float MovePower = 2;
    private Ease GetEaseMove = Ease.Unset;

    private float JumpDelay = 0.5f;
    private float JumpPower = 3;
    private Ease GetEaseJump = Ease.OutSine;

    private bool IsMove = false;


    private IEnumerator Move()
    {
        if (!IsMove)
        {
            IsMove = true;
            transform.DOMoveX(transform.position.x + MovePower, MoveDelay).SetEase(GetEaseMove);
            yield return new WaitForSeconds(MoveDelay);
            IsMove = false;
        }
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.DOMoveY(transform.position.y + JumpPower, JumpDelay).SetEase(GetEaseJump);
        }
    }

}
