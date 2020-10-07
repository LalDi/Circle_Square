using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private bool IsMove = false;

    public float MoveDelay;
    public float MovePower;
    public Ease GetEaseMove;

    public float JumpDelay;
    public float JumpPower;
    public Ease GetEaseJump;

    public Dropdown MoveDrop;
    public Dropdown JumpDrop;

    public InputField JumpPowerField;
    public InputField JumpDelayField;
    public InputField MovePowerField;
    public InputField MoveDelayField;
    public InputField GravityField;

    private void Start()
    {
        SetDropdownExample();
    }

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
            transform.DOMoveY(transform.position.y + JumpPower, JumpDelay).SetEase(GetEaseJump);
        }
    }

    void SetDropdownExample()
    {
        MoveDrop.options.Clear();
        JumpDrop.options.Clear();
        for (Ease i = 0; i < Ease.INTERNAL_Zero; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = i.ToString();
            MoveDrop.options.Add(option);
            JumpDrop.options.Add(option);
        }
    }

    public void SetEaseJump()
    {
        Ease ease = (Ease)JumpDrop.value;
        GetEaseJump = ease;
        print("Jump Ease Graph : " + GetEaseJump.ToString());
    }

    public void SetEaseMove()
    {
        Ease ease = (Ease)MoveDrop.value;
        GetEaseMove = ease;
        print("Move Ease Graph : " + GetEaseMove.ToString());
    }

    public void SetJumpPower()
    {
        JumpPower = int.Parse(JumpPowerField.text);
    }
    public void SetJumpDelay()
    {
        JumpDelay = int.Parse(JumpDelayField.text);
    }
    public void SetMovePower()
    {
        MovePower = int.Parse(MovePowerField.text);
    }
    public void SetMoveDelay()
    {
        MoveDelay = int.Parse(MoveDelayField.text);
    }
    public void SetGravityScale()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = int.Parse(GravityField.text);
    }
}
