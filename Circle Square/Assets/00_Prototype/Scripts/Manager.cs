using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Manager : MonoBehaviour
{
    public GameObject Player_Square;
    public GameObject Player_Circle;

    public GameObject Grid_Square;
    public GameObject Grid_Circle;

    public Dropdown MoveDrop;
    public Dropdown JumpDrop;

    private bool SquareMode = true;

    private void Start()
    {
        //SetDropdownExample();
    }

    public void ChangeMode()
    {
        SquareMode = !SquareMode;

        Player_Square.SetActive(SquareMode);
        Grid_Square.SetActive(SquareMode);

        Player_Circle.SetActive(!SquareMode);
        Grid_Circle.SetActive(!SquareMode);
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
}
