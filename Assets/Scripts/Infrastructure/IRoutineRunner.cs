using System.Collections;
using Infrastructure.Services;
using UnityEngine;

public interface IRoutineRunner : IService
{
    Coroutine StartCoroutine(IEnumerator coroutine);
}