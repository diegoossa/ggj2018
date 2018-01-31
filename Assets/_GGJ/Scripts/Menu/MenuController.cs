using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject one;
    public GameObject two;

    public void Next()
    {
        one.SetActive(false);
        two.SetActive(true);
    }
}
