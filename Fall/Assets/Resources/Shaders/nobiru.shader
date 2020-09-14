Shader "Custom/nobiru"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Angle("angle",Range(0,10)) = 0
	}
		SubShader
		{
				Tags { "RenderType" = "Opaque" }
			Pass
			{
				CGPROGRAM
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
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float _Angle;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
				float angle = _Angle;

			float sinAngle = sin(angle);
			float cosAngle = cos(angle);

			float2x2 rotMatrix = float2x2(cosAngle, -sinAngle, sinAngle, cosAngle);
			//float uv = mul(i.uv, rotMatrix);
			float h = float2(0.5, 0.5);
			//float2 uv = mul(i.uv - h, rotMatrix) + h;
			float2 uv = i.uv * _MainTex_ST.xy + (_MainTex_ST.zw );
			uv = frac(uv);
			uv = mul(uv - h, rotMatrix) + h;
					fixed4 col = tex2D(_MainTex, uv);

					return col;
				}
				ENDCG
		}
	}
}
