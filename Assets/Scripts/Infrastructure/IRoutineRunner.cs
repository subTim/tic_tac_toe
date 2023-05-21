using System.Collections;
using UnityEngine;

public interface IRoutineRunner
{
    Coroutine StartCoroutine(IEnumerator coroutine);
}