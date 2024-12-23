// Based on the following guidelines by Alex Lindman:
// https://blog.unity.com/technology/custom-lighting-in-shader-graph-expanding-your-graphs-in-2019

void MainLight_float(out float3 Direction, out float3 Color)
{
#ifdef SHADERGRAPH_PREVIEW
    Direction = float3(0.5,0.5,0.5);
    Color = float3(1,1,1);
#else
    Light mainLight = GetMainLight();
    Direction = mainLight.direction;
    Color = mainLight.color;
#endif
}