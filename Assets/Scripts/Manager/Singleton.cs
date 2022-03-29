using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    public void SetInstance()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }

        if (instance == null)
        {
            instance = FindObjectOfType(typeof(T)) as T;
            if (instance == null)
                instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }
}

public class DestructibleSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
            }

            return instance;
        }
    }

    public void SetInstance()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }

        if (instance == null)
        {
            instance = FindObjectOfType(typeof(T)) as T;
            if (instance == null)
                instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
        }
    }
}