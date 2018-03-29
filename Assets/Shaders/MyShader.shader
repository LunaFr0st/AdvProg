Shader "Custom/MyShader" {
	Properties{
		_Colour("Colour", Color) = (1,1,1,1)
	}

	SubShader{ // The Shader
		CGPROGRAM // Starts CG Programming language
			#pragma surface surf Lambert 
			struct Input {
				float2 uvMainTex;
			};
			fixed4 _Colour;
			void surf(Input IN, inout SurfaceOutput o) {
				o.Albedo = _color.rgb;
			}
		ENDCG
	}
		FallBack "Diffuse"
}
