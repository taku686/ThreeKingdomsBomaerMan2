using System;
using System.Linq;
using Common.Data;
using UnityEngine;

public class AnimationPlayBackUseCase : IDisposable
{
    public void RandomPlayBack(Animator animator, AnimationStateType animationStateType)
    {
        var parameters = animator.parameters;
        var candidateParameters = parameters.Where(parameter => parameter.name.Contains(animationStateType.ToString())).ToArray();
        var randomIndex = UnityEngine.Random.Range(0, candidateParameters.Length);
        var candidateParameter = candidateParameters[randomIndex];
        animator.SetTrigger(candidateParameter.name);
    }


    public void Dispose()
    {
        // TODO release managed resources here
    }
}