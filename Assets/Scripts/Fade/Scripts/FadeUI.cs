﻿/*
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
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(Mask))]
public class FadeUI : MonoBehaviour, IFade
{
    [SerializeField, Range(0, 1)] private float cutoutRange;

    public float Range
    {
        get { return cutoutRange; }
        set
        {
            cutoutRange = value;
            UpdateMaskCutout(cutoutRange);
        }
    }

    public void SetRandomColor()
    {
    }

    public void SetRandomMaskTexture()
    {
    }

    public void SetColor(Color fadeInColor, Color fadeOutColor)
    {
    }

    public void SetMaskTexture(int index)
    {
    }

    [SerializeField] Material mat = null;
    [SerializeField] RenderTexture rt = null;

    [SerializeField] Texture texture = null;

    private void UpdateMaskCutout(float range)
    {
        mat.SetFloat("_Range", range);

        UnityEngine.Graphics.Blit(texture, rt, mat);

        var mask = GetComponent<Mask>();
        mask.enabled = false;
        mask.enabled = true;
    }
}