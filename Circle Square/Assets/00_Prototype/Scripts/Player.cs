using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private bool IsMove = false;

    public float MoveDelay;
    public float MovePower;
    public Ease GetEaseMove;

    public float JumpDelay;
    public Ease GetEaseJump;

    public void Go()
    {
        StartCoroutine(Move());
    }

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
            transform.DOMoveY(transform.position.y + 3, JumpDelay).SetEase(GetEaseJump);
        }
    }
}
