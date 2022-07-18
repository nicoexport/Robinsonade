using UnityEngine;
using System;

namespace Architecture
{
    public static class Bootstrap
    {
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void InitializeBootstrap()
        {
            var bootstrap = UnityEngine.Object.Instantiate(Resources.Load("P_Bootstrap")) as GameObject;
            if (bootstrap == null) throw new ApplicationException();
            UnityEngine.Object.DontDestroyOnLoad(bootstrap);
        }
    }
}
