Shader "Shader Forge/postBlur" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
			uniform float4 _MainTex_TexelSize;
            
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 TexelSize = _MainTex_TexelSize.rg;
				float2 uvT = float2(i.uv0.x, i.uv0.y + TexelSize.y);
				float2 uvTR = i.uv0 + TexelSize;
				float2 uvR = float2(i.uv0.x + TexelSize.x, i.uv0.y);
				float2 uvBR = float2(i.uv0.x + TexelSize.x, i.uv0.y - TexelSize.y);
				float2 uvB = float2(i.uv0.x, i.uv0.y - TexelSize.y);
				float2 uvBL = i.uv0 - TexelSize;
				float2 uvL = float2(i.uv0.x - TexelSize.x, i.uv0.y);
				float2 uvTL = float2(i.uv0.x - TexelSize.x, i.uv0.y + TexelSize.y);
				float4 colT = tex2D(_MainTex, TRANSFORM_TEX(uvT, _MainTex));
				float4 colTR = tex2D(_MainTex, TRANSFORM_TEX(uvTR, _MainTex));
				float4 colR = tex2D(_MainTex, TRANSFORM_TEX(uvR, _MainTex));
				float4 colBR = tex2D(_MainTex, TRANSFORM_TEX(uvBR, _MainTex));
				float4 colB = tex2D(_MainTex, TRANSFORM_TEX(uvB, _MainTex));
				float4 colBL = tex2D(_MainTex, TRANSFORM_TEX(uvBL, _MainTex));
				float4 colL = tex2D(_MainTex, TRANSFORM_TEX(uvL, _MainTex));
				float4 colTL = tex2D(_MainTex, TRANSFORM_TEX(uvTL, _MainTex));
				float4 col = tex2D(_MainTex, TRANSFORM_TEX(i.uv0, _MainTex));
                float3 emissive = (colT.rgb + colTR.rgb + colR.rgb + colBR.rgb + colB.rgb + colBL.rgb + colL.rgb + colTL.rgb + col) / 9.0;
                float3 finalColor = emissive;
                return fixed4(finalColor, 1);
            }
            ENDCG
        }
    }
}
