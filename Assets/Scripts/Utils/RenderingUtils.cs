using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingUtils
{
	public static void SetRenderingMode(RenderingMode mode, Material mat)
	{
		mat.SetFloat("_Mode", (int)mode);
		switch (mode)
		{
			case RenderingMode.Opaque:
				mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
				mat.SetInt("_ZWrite", 1);
				mat.DisableKeyword("_ALPHATEST_ON");
				mat.DisableKeyword("_ALPHABLEND_ON");
				mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				mat.renderQueue = -1;
				break;
			case RenderingMode.Cutout:
				mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
				mat.SetInt("_ZWrite", 1);
				mat.EnableKeyword("_ALPHATEST_ON");
				mat.DisableKeyword("_ALPHABLEND_ON");
				mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				mat.renderQueue = 2450;
				break;
			case RenderingMode.Fade:
				mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
				mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				mat.SetInt("_ZWrite", 0);
				mat.DisableKeyword("_ALPHATEST_ON");
				mat.EnableKeyword("_ALPHABLEND_ON");
				mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				mat.renderQueue = 3000;
				break;
			case RenderingMode.Transparent:
				mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				mat.SetInt("_ZWrite", 0);
				mat.DisableKeyword("_ALPHATEST_ON");
				mat.DisableKeyword("_ALPHABLEND_ON");
				mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
				mat.renderQueue = 3000;
				break;
		}
	}

	public static void SetAlpha(float alpha, Material mat)
	{
		Color matColor = mat.color;
		matColor.a = alpha;
		mat.color = matColor;
	}
}

public enum RenderingMode
{
	Opaque,
	Cutout,
	Fade,
	Transparent
}
