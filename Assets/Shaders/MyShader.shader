Shader "Custom/Basic/FirstShaders"{
	Properties{
		_Texture("Texture", 2D) = "white"{}
		_Normal("Normal", 2D) = "bump"{}
		_Cube("Cube", CUBE) = ""{}
		_Colour("Colour", Color) = (1,1,1,1)
		_Emission("Emission", Color) = (1,1,1,1)
		_Range("Range", Range(0,5)) = 1
	}
	
	SubShader{
			Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Lambert

		fixed4 _Colour;
		fixed4 _Emission;
		half _Range;
		float4 _Vector;
		sampler2D _Texture;
		sampler2D _Normal;
		samplerCUBE _Cube;
		float _Float;

		struct Input {
			float2 uv_Texture;
			float2 uv_Normal;
			float3 worldRefl;
		};
		
		
		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = (tex2D(_Texture, IN.uv_Texture) * _Colour * _Range).rgb;
			o.Emission = (texCUBE(_Cube, IN.worldRefl) * _Emission).rgb;
		}
		void waves(Input IN, inout SurfaceOutput o) {
			o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Normal));
		}
		ENDCG
	}

	FallBack "Diffuse"
}