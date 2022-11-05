using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProvider<T>
{
    T Get();

}
