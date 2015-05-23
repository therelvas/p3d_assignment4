Shader "Sphere Mapping Assignment 4" {
   Properties {
      _BaseMap ("Base Map", 2D) = "gray" {}
   }
   
   SubShader {
      Pass {	
        
        GLSLPROGRAM
 
        // User-specified properties
        uniform vec4 _BaseMap_ST;
        uniform sampler2D _BaseMap;
 
 		uniform mat4 _Object2World; // model matrix
        uniform mat4 _World2Object; // inverse model matrix
 
 		uniform vec3 _WorldSpaceCameraPos;
        uniform vec4 _WorldSpaceLightPos0; // direction to or position of light source
        uniform vec4 _LightColor0; // color of light source (from "Lighting.cginc")
 	
 		//Data out/in
 		varying vec4 dataTexCoord; 
        varying vec2 dataSphereCoord;
       
        #ifdef VERTEX
 
        void main()
        {				
        	vec3 e = vec3(gl_ModelViewMatrix * gl_Vertex); // Eye
        	vec3 n = normalize(gl_NormalMatrix * gl_Normal); // Normal
        	dataTexCoord = gl_MultiTexCoord0;
        	
 			vec3 reflected = reflect(normalize(e), n);
 			float m = 2.0 * sqrt(reflected.x * reflected.x + reflected.y * reflected.y + (reflected.z + 1.0) * (reflected.z + 1.0)); 
 			dataSphereCoord.s = reflected.x / m + 0.5;
 			dataSphereCoord.t = reflected.y / m + 0.5;
 
        	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
        }
 
        #endif
 
        #ifdef FRAGMENT
 
        void main()
        {
    		vec4 sphereTexture = texture2D(_BaseMap, _BaseMap_ST.xy * dataTexCoord.xy + _BaseMap_ST.zw);
            gl_FragColor = sphereTexture;
         }
 
         #endif
 
         ENDGLSL
      } 
   } 
}