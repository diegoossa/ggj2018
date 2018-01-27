
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public string currentLanguage;
    public Transform player;


    private void Awake()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
