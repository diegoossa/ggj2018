using UnityEngine;

/// <summary>
/// Clase generica Singleton
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    /// <summary>
    /// Singleton design pattern
    /// </summary>
    /// <value>La instancia</value>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// En el Awake, verificamos si hay una copia de este objeto en la escena. Si la hay entonces lo destruimos
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            //Soy la primera instancia, hazme tu Singleton
            _instance = this as T;
        }
        else
        {
            //Si un Singleton ya existe y encontramos otra instancia en la escena, la destruimos
            if (this != _instance)
            {
                Destroy(gameObject);
            }
        }
    }
}
