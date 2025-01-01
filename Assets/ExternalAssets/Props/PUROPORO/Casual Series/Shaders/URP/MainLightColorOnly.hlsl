// Based on the following guidelines by Alex Lindman:
// https://blog.unity.com/technology/custom-lighting-in-shader-graph-expanding-your-graphs-in-2019

void MainLightColorOnly_float(out float3 Color)
{
#ifdef SHADERGRAPH_PREVIEW
    Color = float3(1,1,1);
#else
    Light mainLight = GetMainLight();
    Color = mainLight.color;
#endif
}