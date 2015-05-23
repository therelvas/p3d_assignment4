Shader "Cube Mapping Assignment 4" {
   Properties {
      _BaseMap ("Base Map", 2D) = "gray" {}
      _CubeMap("Cube Map", Cube) = "gray" {}
      _ReflectFactor ("Reflect Factor", Float) = 0.6
   }
   
   SubShader {
      Pass {	
        
        GLSLPROGRAM
 
        // User-specified properties
        uniform vec4 _BaseMap_ST;
        uniform samplerCube _CubeMap; 
        uniform sampler2D _BaseMap;
        uniform float _ReflectFactor;
        
         
 		uniform mat4 _Object2World; // model matrix
        uniform mat4 _World2Object; // inverse model matrix
 
 		uniform vec3 _WorldSpaceCameraPos;
        uniform vec4 _WorldSpaceLightPos0; // direction to or position of light source
        uniform vec4 _LightColor0; // color of light source (from "Lighting.cginc")
 	
 		//Data out/in
 		varying vec4 dataTexCoord; 
        varying vec3 dataReflected;
       
        #ifdef VERTEX
 
        void main()
        {				
        	vec3 e = vec3(gl_ModelViewMatrix * gl_Vertex); // Eye
        	vec3 n = normalize(gl_NormalMatrix * gl_Normal); // Normal
        	dataTexCoord = gl_MultiTexCoord0;
        	
 			vec3 reflected = reflect(normalize(e), n);
 			float m = 2.0 * sqrt(reflected.x * reflected.x + reflected.y * reflected.y + (reflected.z + 1.0) * (reflected.z + 1.0)); 
 			
 			mat4 viewMatrix = gl_ModelViewMatrixInverse * _World2Object;
 			dataReflected = vec3(viewMatrix * vec4(vec3(reflected.x, reflected.yz), 0.0));
 
        	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
        }
 
        #endif
 
        #ifdef FRAGMENT
 
        void main()
        {
        	vec4 baseTexture = texture2D(_BaseMap, _BaseMap_ST.xy * dataTexCoord.xy + _BaseMap_ST.zw);
        	vec4 cubeTexture = textureCube(_CubeMap, dataReflected);
            gl_FragColor = mix(baseTexture, cubeTexture, _ReflectFactor);
         }
 
         #endif
 
         ENDGLSL
      } 
   } 
}