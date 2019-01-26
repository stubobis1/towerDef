Shader "Custom/SecurityCameraViews"
{
    Properties
    {
        _GridSize ("GridSize", float) = 1.0
        _X ("Seed X", float) = 1.0
        _Y ("Seed Y", float) = 1.0
       _CameraView ("Camera Texture", 2D) = "white" {}
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            float _GridSize = 60.0;
            float _X;
            float _Y;
            
            sampler2D _CameraView;
 
            float4 permute(float4 x)
            {
                return fmod(256.0 * pow(x, 2) + x, 300.0);
            }
 
            float2 fade(float2 t) {
                return 6.0 * pow(t, 5.0) - 15.0 * pow(t, 4.0) + 10.0 * pow(t, 3.0);
            }
 
            float4 taylorInvSqrt(float4 r) {
                return 1.79284291400159 - 0.85373472095314 * r;
            }
 
            #define DIV_289 0.00346020761245674740484429065744f
 
            float mod289(float x) {
                return x - floor(x * DIV_289) * 289.0;
            }
 
            float PerlinNoise2D(float2 P)
            {
                  float4 Pi = floor(P.xyxy) + float4(0.0, 0.0, 1.0, 1.0);
                  float4 Pf = frac (P.xyxy) - float4(0.0, 0.0, 1.0, 1.0);
 
                  float4 ix = Pi.xzxz;
                  float4 iy = Pi.yyww;
                  float4 fx = Pf.xzxz;
                  float4 fy = Pf.yyww;
 
                  float4 i = permute(permute(ix) + iy);
 
                  float4 gx = frac(i / 41.0) * 2.0 - 1.0 ;
                  float4 gy = abs(gx) - 0.5 ;
                  float4 tx = floor(gx + 0.5);
                  gx = gx - tx;
 
                  float2 g00 = float2(gx.x,gy.x);
                  float2 g10 = float2(gx.y,gy.y);
                  float2 g01 = float2(gx.z,gy.z);
                  float2 g11 = float2(gx.w,gy.w);
 
                  float4 norm = taylorInvSqrt(float4(dot(g00, g00), dot(g01, g01), dot(g10, g10), dot(g11, g11)));
                  g00 *= norm.x;
                  g01 *= norm.y;
                  g10 *= norm.z;
                  g11 *= norm.w;
 
                  float n00 = dot(g00, float2(fx.x, fy.x));
                  float n10 = dot(g10, float2(fx.y, fy.y));
                  float n01 = dot(g01, float2(fx.z, fy.z));
                  float n11 = dot(g11, float2(fx.w, fy.w));
 
                  float2 fade_xy = fade(Pf.xy);
                  float2 n_x = lerp(float2(n00, n01), float2(n10, n11), fade_xy.x);
                  float n_xy = lerp(n_x.x, n_x.y, fade_xy.y);
                  return 2.3 * n_xy;
            }
 
      
            fixed4 frag (v2f_img i) : SV_Target
            {
                 float phase = _Time * 30.4;
                float pixelcolor = tex2D(_CameraView, i.uv);
                i.uv *= _GridSize * (phase * .6);
                i.uv += float2(sin(_X * phase) * .50, cos(_Y * phase)*.50);
                float ns = (PerlinNoise2D(i.uv) / 2 + 0.6f) ; 
                float perlincolor = 0.5* (ns +.85);
                float yes = pixelcolor* (perlincolor);
                fixed4 finalcolor = float4(yes,yes,yes,.6);
              
                
                //return float4(finalcolor, finalcolor, finalcolor, 0.10f);
                return finalcolor;
            }
            ENDCG
        }
    }
}