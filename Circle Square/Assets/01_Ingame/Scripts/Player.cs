using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float MoveDelay { get; } = 0.1f;
    public float MovePower { get; } = 2;
    public Ease EaseMove { get; } = Ease.Unset;

    private float JumpDelay = 0.5f;
    private float JumpPower = 3;
    private Ease EaseJump = Ease.OutSine;

    public bool IsMove { get; set; } = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.DOMoveY(transform.position.y + JumpPower, JumpDelay).SetEase(EaseJump);
        }
    }

    private IEnumerator Move()
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();

        if (!IsMove)
        {
            IsMove = true;
            rig.gravityScale = 0;
            transform.DOMoveX(transform.position.x + MovePower, MoveDelay).SetEase(EaseMove);
            yield return new WaitForSeconds(MoveDelay);
            rig.gravityScale = 1;
            IsMove = false;
        }
        yield return 0;
    }
}
