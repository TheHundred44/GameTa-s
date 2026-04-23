using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void OpenCanvas(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void CloseCanvas(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
