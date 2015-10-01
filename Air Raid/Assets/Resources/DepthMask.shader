Shader "Masked/Mask" {
 //dont render, only draw to 
  SubShader {
    // draw after all opaque objects (queue = 2001):
    Tags { "Queue"="Geometry+1" }
    Pass {
      Blend Zero One // keep the image behind it using blending
    }
  } 
}