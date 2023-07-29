/*
 The MIT License (MIT)

Copyright (c) 2013 yamamura tatsuhiko

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    private IFade _fade;
    private float _cutoutRange;

    public void InitializeInSceneTransition(float range, bool isSceneTransition)
    {
        _fade = GetComponent<IFade>();
        if (!isSceneTransition)
        {
            _fade.SetRandomColor();
            _fade.SetRandomMaskTexture();
        }

        _cutoutRange = range;
        _fade.Range = range;
        _fade.SetColor(ProjectCommonData.Instance.fadeInColor, ProjectCommonData.Instance.fadeOutColor);
        _fade.SetMaskTexture(ProjectCommonData.Instance.maskTextureIndex);
    }


    IEnumerator FadeoutCoroutine(float time, System.Action action)
    {
        float endTime = Time.timeSinceLevelLoad + time * (_cutoutRange);
        var endFrame = new WaitForEndOfFrame();

        while (Time.timeSinceLevelLoad <= endTime)
        {
            _cutoutRange = (endTime - Time.timeSinceLevelLoad) / time;
            _fade.Range = _cutoutRange;
            yield return endFrame;
        }

        _cutoutRange = 0;
        _fade.Range = _cutoutRange;

        if (action != null)
        {
            action();
        }
    }

    IEnumerator FadeinCoroutine(float time, System.Action action, bool isTransition)
    {
        if (!isTransition)
        {
            _fade.SetRandomColor();
            _fade.SetRandomMaskTexture();
        }

        float endTime = Time.timeSinceLevelLoad + time * (1 - _cutoutRange);

        var endFrame = new WaitForEndOfFrame();

        while (Time.timeSinceLevelLoad <= endTime)
        {
            _cutoutRange = 1 - ((endTime - Time.timeSinceLevelLoad) / time);
            _fade.Range = _cutoutRange;
            yield return endFrame;
        }

        _cutoutRange = 1;
        _fade.Range = _cutoutRange;

        if (action != null)
        {
            action();
        }
    }

    public Coroutine FadeOut(float time, System.Action action = null)
    {
        StopAllCoroutines();
        return StartCoroutine(FadeoutCoroutine(time, action));
    }

    public Coroutine FadeIn(float time, System.Action action, bool isTransition)
    {
        StopAllCoroutines();
        return StartCoroutine(FadeinCoroutine(time, action, isTransition));
    }

    public Coroutine FadeIn(float time, bool isInitialize)
    {
        return FadeIn(time, null, isInitialize);
    }
}