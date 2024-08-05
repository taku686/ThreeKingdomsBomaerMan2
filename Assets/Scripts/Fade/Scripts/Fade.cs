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
using System.Threading;
using Cysharp.Threading.Tasks;

public class Fade : MonoBehaviour
{
    private IFade fade;
    private float cutoutRange;
    private CancellationTokenSource cts;

    public void InitializeInSceneTransition(float range, bool isSceneTransition)
    {
        cts = new CancellationTokenSource();
        fade = GetComponent<IFade>();
        if (!isSceneTransition)
        {
            fade.SetRandomColor();
            fade.SetRandomMaskTexture();
        }

        cutoutRange = range;
        fade.Range = range;
        fade.SetColor(ProjectCommonData.Instance.fadeInColor, ProjectCommonData.Instance.fadeOutColor);
        fade.SetMaskTexture(ProjectCommonData.Instance.maskTextureIndex);
    }


    private async UniTask FadeoutAsync(float time, System.Action action, CancellationToken token)
    {
        float endTime = Time.timeSinceLevelLoad + time * (cutoutRange);

        while (Time.timeSinceLevelLoad <= endTime)
        {
            cutoutRange = (endTime - Time.timeSinceLevelLoad) / time;
            fade.Range = cutoutRange;
            await UniTask.Yield(token);
        }

        cutoutRange = 0;
        fade.Range = cutoutRange;

        if (action != null)
        {
            action();
        }
    }

    private async UniTask FadeinAsync(float time, System.Action action, bool isTransition, CancellationToken token)
    {
        if (!isTransition)
        {
            fade.SetRandomColor();
            fade.SetRandomMaskTexture();
        }

        float endTime = Time.timeSinceLevelLoad + time * (1 - cutoutRange);

        while (Time.timeSinceLevelLoad <= endTime)
        {
            if (fade == null)
            {
                return;
            }

            cutoutRange = 1 - ((endTime - Time.timeSinceLevelLoad) / time);
            fade.Range = cutoutRange;
            await UniTask.Yield(token);
        }

        cutoutRange = 1;
        fade.Range = cutoutRange;

        if (action != null)
        {
            action();
        }
    }

    public async UniTask FadeOut(float time, System.Action action = null)
    {
        Cancel();
        await FadeoutAsync(time, action, cts.Token);
    }

    public async UniTask FadeIn(float time, System.Action action, bool isTransition)
    {
        Cancel();
        await FadeinAsync(time, action, isTransition, cts.Token);
    }

    private void Cancel()
    {
        if (cts == null)
        {
            return;
        }

        cts.Cancel();
        cts.Dispose();
        cts = null;
        cts = new CancellationTokenSource();
    }
}