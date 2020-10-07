using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Deadhole : MonoBehaviour
{
    public float m_Speed = 1;
    public GameObject ReButton;
    public InputField SpeedField;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        transform.DOMoveX(transform.position.x + m_Speed, 1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            ReButton.SetActive(true);
        }
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("00_Prototype");
    }
    public void SetSpeed()
    {
        m_Speed = int.Parse(SpeedField.text);
    }
}
