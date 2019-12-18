using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 싱글턴 전용 부모 클래스 
/// </summary>
/// <typeparam name="T">싱글턴으로 사용할 Monobehavior 타입</typeparam>
public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isQuit = false;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                    Debug.LogError(string.Format("There is no attached script which type is [{0}] in scene.", typeof(T)));
            }

            return _instance;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _isQuit = true;
        StopAllCoroutines();
    }
}