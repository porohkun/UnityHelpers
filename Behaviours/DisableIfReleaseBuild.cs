using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DisableIfReleaseBuild : MonoBehaviour
{
    private bool _isRelese =
#if RELEASE_BUILD
        true;
#else
        false;
#endif

    private void Awake()
    {
        gameObject.SetActive(!_isRelese);
    }
}

