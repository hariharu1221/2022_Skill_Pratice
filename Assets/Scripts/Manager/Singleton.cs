using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (isDestroy)
            {
                return null;
            }
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

    private static bool isDestroy = false;
    private void OnDestroy()
    {
        isDestroy = true;
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
            isDestroy = false;
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
            if (isDestroy)
            {
                return null;
            }
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
            }

            return instance;
        }
    }

    private static bool isDestroy = false;
    private void OnDestroy()
    {
        isDestroy = true;
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
            isDestroy = false;
        }
    }
}
