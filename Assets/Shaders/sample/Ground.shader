Shader "Unlit/GroundOriginal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _SubColor ("SubColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            // Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members worldPos)
            //  #pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _SubColor;

            v2f vert(appdata v)
            {
                float3 forward = -UNITY_MATRIX_V._m20_m21_m22; // カメラの前方ベクトル
                float3 campos = _WorldSpaceCameraPos; // カメラのワールド位置
                float center_distance = abs(_ProjectionParams.z - _ProjectionParams.y) * 0.5;
                // near と far から視錐台の中央までの距離を得る
                float3 center = campos + forward * (center_distance + abs(_ProjectionParams.y)); // 平面を移動すべき中心点
                float3 pos = float3(v.vertex.x * center_distance * 0.5 + center.x,
                                    0, // ground level
                                    v.vertex.z * center_distance * 0.5 + center.z); // 移動後の頂点
                v2f o;
                o.vertex = UnityWorldToClipPos(pos); // クリップ座標へ
                o.uv = TRANSFORM_TEX(pos.xz*float2(1.0/16.0, 1.0/16.0), _MainTex);
                //  o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            float4 hash4fast(float2 gridcell)
            {
                const float2 OFFSET = float2(26.0, 161.0);
                const float DOMAIN = 71.0;
                const float SOMELARGEFIXED = 951.135664;
                float4 P = float4(gridcell.xy, gridcell.xy + 1);
                P = frac(P * (1 / DOMAIN)) * DOMAIN;
                P += OFFSET.xyxy;
                P *= P;
                return frac(P.xzxz * P.yyww * (1 / SOMELARGEFIXED));
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float4 off = hash4fast(floor(i.uv));
                off.zw = off.zw >= float2(0.5, 0.5) ? float2(1, 1) : float2(-1, -1);
                float2 fuv = frac(i.uv);
                float2 uv = fuv * off.zw + off.xy;
                float2 dx = ddx(i.uv) * off.zw;
                float2 dy = ddy(i.uv) * off.zw;

                // correct fetch
                fixed4 col = tex2Dgrad(_MainTex, uv, dx, dy);
                if (int(fmod(floor(i.uv.x + 0.5) + floor(i.uv.y + 0.5), 2)) == 0)
                {
                    col.rgb *= _SubColor.rgb;
                }
                else
                {
                    col.rgb *= _Color.rgb;
                }
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}