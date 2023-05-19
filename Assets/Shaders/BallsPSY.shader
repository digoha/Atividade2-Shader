Shader "Unlit/BallsPSY"
{
    Properties{
         _MainTex("Texture", 2D) = "white" {}
         _Tint("Tint", Color) = (1, 1, 1, 1)
         _Distortion("Distortion", Range(0.0, 1.0)) = 0.1
         _Speed("Speed", Range(-1.0, 1.0)) = 0.1
         _Brightness("Brightness", Range(0.0, 1.0)) = 1.0
         _Detail("Detail", Range(0.0, 1.0)) = 0.5
         _Scale("Scale", Range(0.1, 10.0)) = 1.0
    }

        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Opaque"}
            LOD 100

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _Tint;
                float _Distortion;
                float _Speed;
                float _Brightness;
                float _Detail;
                float _Scale;

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };


                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv * _Scale;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
    
                    float2 distortedUV = i.uv + (_Distortion * (_Detail + 1.0) * sin(i.uv.yx * _Detail + _Time.y * _Speed));

                    fixed4 texColor = tex2D(_MainTex, distortedUV);

                    fixed4 fireColor = lerp(_Tint * texColor, _Tint * texColor * 2.0, texColor.r);
                    fireColor *= _Brightness;

                    return fireColor;
                }
                ENDCG
            }
         }     
}
