// Based on the following guidelines by Alex Lindman:
// https://blog.unity.com/technology/custom-lighting-in-shader-graph-expanding-your-graphs-in-2019

void MainLightShadow_half(float3 WorldPosition, out half3 Direction, out half3 Color, out half DistanceAttenuation, out half ShadowAttenuation)
{
#if SHADERGRAPH_PREVIEW
    Direction = half3(0.5, 0.5, 0.5);
    Color = 1;
    DistanceAttenuation = 1;
    ShadowAttenuation = 1;
#else
#if SHADOWS_SCREEN
    half4 clipPosition = TransformWorldToHClip(WorldPosition);
    half4 shadowCoordinate = ComputeScreenPos(clipPosition);
#else
    half4 shadowCoordinate = TransformWorldToShadowCoord(WorldPosition);
#endif
    Light mainLight = GetMainLight(shadowCoordinate);
    Direction = mainLight.direction;
    Color = mainLight.color;
    DistanceAttenuation = mainLight.distanceAttenuation;
    ShadowAttenuation = mainLight.shadowAttenuation;
#endif
}