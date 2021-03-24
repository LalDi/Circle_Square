using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class EventManager : MonoBehaviour
{
    private GameManager GM = GameManager.Instance;

    private bool StartGame = true;

    private void FixedUpdate()
    {
        Touch tempTouchs;
        Vector3 touchedPos;

        if (Input.touchCount > 0) //터치가 1개 이상이면.
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (EventSystem.current.IsPointerOverGameObject(i) == false) // 터치한 곳이 UI가 아닐 때
                {
                    if (StartGame) // 게임이 진행중일 때
                    {
                        tempTouchs = Input.GetTouch(i);
                        if (tempTouchs.phase == TouchPhase.Began)
                        {    //해당 터치가 시작됐다면.
                            touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position); //get world position.

                            break; //한 프레임(update)에는 하나만.
                        }
                    }
                }
            }
        }
    }


    private IEnumerator MovePlayer()
    {
        if (GM.Player.IsMove)
        {
            GM.Player.IsMove = true;
            GM.Player.gameObject.transform.DOMoveX(transform.position.x + GM.Player.MovePower, GM.Player.MoveDelay).SetEase(GM.Player.EaseMove);
            yield return new WaitForSeconds(GM.Player.MoveDelay);
            GM.Player.IsMove = false;
        }
        yield return 0;
    }

    private void ChangeColor()
    {

    }

}
