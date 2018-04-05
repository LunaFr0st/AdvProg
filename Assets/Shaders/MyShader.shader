Shader "Custom/Basic/FirstShaders"{
	Properties{
		_Texture("Texture", 2D) = "white"{}
		_Colour("Colour", Color) = (1,1,1,1)
		_Emission("Emission", Color) = (1,1,1,1)
		_Range("Range", Range(0,5)) = 1
		_Cube("Cube", CUBE) = ""{}
		_Float ("Float", Float) = 0.5
		_Vector ("Vector", Vector) = (0.5,1,1,1)
	}
	
	SubShader{
		CGPROGRAM
		#pragma surface surf Lambert

		fixed4 _Colour;
		fixed4 _Emission;
		half _Range;
		float4 _Vector;
		sampler2D _Texture;
		samplerCUBE _Cube;
		float _Float;

		struct Input {
			float2 uv_Texture;
			float3 worldRefl;
		};
		
		
		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = (tex2D(_Texture, IN.uv_Texture) * _Colour * _Range).rgb;
			o.Emission = (texCUBE(_Cube, IN.worldRefl) * _Emission).rgb;
		}
		ENDCG
	}

	FallBack "Diffuse"
}