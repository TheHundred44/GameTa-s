using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public GameObject[] skins;
    public static int indexCharacter;

    void Start()
    {
        int index = SelectCharacter.Number;

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(i == index);
            indexCharacter = i;
        }
        Time.timeScale = 1.0f;
    }
}
