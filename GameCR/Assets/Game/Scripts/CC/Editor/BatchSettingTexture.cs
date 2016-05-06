using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

namespace CC.Editors
{
	public class BatchSettingTexture : EditorWindow {

		[MenuItem ("CC/批量设置贴图", false, 10)]
		static void ShowWindow () {
			BatchSettingTexture tm = EditorWindow.GetWindow<BatchSettingTexture>("批量设置贴图");
		}

		private string[] platformNames = new string[] {
			"Default",
			"Web",
			"Standalone",
			"iPhone",
			"Android",
			"BlackBerry",
			"FlashPlayer",
		};

		public Texture templateTexture;

		struct PlatformOption
		{
			public bool enable;
			public int maxTextureSize;
			public TextureImporterFormat format;
			public int compressionQuality;


			public override string ToString ()
			{
				return string.Format ("[PlatformOption] enable={0}, maxTextureSize={1}, format={2}, compressionQuality={3}" , enable, maxTextureSize, format, compressionQuality);
			}
		}

		private static PlatformOption GetPlatformOption(TextureImporter importer, string platform)
		{
			int maxTextureSize;
			TextureImporterFormat format;
			int compressionQuality;
			PlatformOption option = new PlatformOption();


			if (importer.GetPlatformTextureSettings(platform, out maxTextureSize, out format, out compressionQuality))
			{
				option.enable = true;
				option.maxTextureSize = maxTextureSize;
				option.format = format;
				option.compressionQuality = compressionQuality;
			}
			else
			{
				option.enable = false;
			}

			if(platform == "Default" && option.enable == false)
			{
				importer.GetPlatformTextureSettings(platform, out maxTextureSize, out format, out compressionQuality);
				option.enable = true;
				option.maxTextureSize = maxTextureSize;
				option.format = format;
				option.compressionQuality = compressionQuality;
			}

			return option;
		}

		void PrintTextureImporterSettings(TextureImporterSettings templateSettings)
		{
			string str = "";
			str += "\n cubemapConvolution=" + templateSettings.cubemapConvolution;
			str += "\n cubemapConvolutionExponent=" + templateSettings.cubemapConvolutionExponent;
			str += "\n cubemapConvolutionSteps=" + templateSettings.cubemapConvolutionSteps;
			str += "\n rgbm=" + templateSettings.rgbm;
			str += "\n spriteAlignment=" + templateSettings.spriteAlignment;
			str += "\n spriteBorder=" + templateSettings.spriteBorder;
			str += "\n spriteExtrude=" + templateSettings.spriteExtrude;
			str += "\n spriteMode=" + templateSettings.spriteMode;
			str += "\n spritePivot=" + templateSettings.spritePivot;
			str += "\n spritePixelsPerUnit=" + templateSettings.spritePixelsPerUnit;

			Debug.Log(str);
		}

		void PrintTextureImporter(TextureImporter ti)
		{
			string str = "";
			str += "\n anisoLevel=" + ti.anisoLevel;
			str += "\n borderMipmap=" + ti.borderMipmap;
			str += "\n compressionQuality=" + ti.compressionQuality;
			str += "\n convertToNormalmap=" + ti.convertToNormalmap;
			str += "\n fadeout=" + ti.fadeout;
			str += "\n filterMode=" + ti.filterMode;
			str += "\n generateCubemap=" + ti.generateCubemap;
			str += "\n generateMipsInLinearSpace=" + ti.generateMipsInLinearSpace;
			str += "\n grayscaleToAlpha=" + ti.grayscaleToAlpha;
			str += "\n heightmapScale=" + ti.heightmapScale;
			str += "\n isReadable=" + ti.isReadable;
			str += "\n lightmap=" + ti.lightmap;
			str += "\n linearTexture=" + ti.linearTexture;
			str += "\n maxTextureSize=" + ti.maxTextureSize;
			str += "\n mipMapBias=" + ti.mipMapBias;
			str += "\n mipmapEnabled=" + ti.mipmapEnabled;
			str += "\n mipmapFadeDistanceEnd=" + ti.mipmapFadeDistanceEnd;
			str += "\n mipmapFadeDistanceStart	=" + ti.mipmapFadeDistanceStart	;
			str += "\n mipmapFilter	=" + ti.mipmapFilter	;
			str += "\n normalmap	=" + ti.normalmap	;
			str += "\n normalmapFilter	=" + ti.normalmapFilter	;
			str += "\n npotScale	=" + ti.npotScale	;
			str += "\n qualifiesForSpritePacking	=" + ti.qualifiesForSpritePacking	;
			str += "\n spriteBorder	=" + ti.spriteBorder	;
			str += "\n spriteImportMode	=" + ti.spriteImportMode	;
			str += "\n spritePackingTag	=" + ti.spritePackingTag	;
			str += "\n spritePivot	=" + ti.spritePivot	;
			str += "\n spritePixelsPerUnit	=" + ti.spritePixelsPerUnit	;
			str += "\n spritesheet	=" + ti.spritesheet	;
			str += "\n textureFormat	=" + ti.textureFormat	;
			str += "\n textureType	=" + ti.textureType	;
			str += "\n wrapMode	=" + ti.wrapMode	;
			Debug.Log(str);
		}

		void CopyTextureImporterForSprite(TextureImporter importer, TextureImporter templateImporter)
		{
			importer.textureType = templateImporter.textureType;
			importer.spriteImportMode = templateImporter.spriteImportMode;
			importer.spritePackingTag = templateImporter.spritePackingTag;
			importer.spritePixelsPerUnit = templateImporter.spritePixelsPerUnit;
			importer.spritePivot = templateImporter.spritePivot;
			
			importer.maxTextureSize = templateImporter.maxTextureSize;
			importer.mipmapEnabled = templateImporter.mipmapEnabled;
			importer.filterMode = templateImporter.filterMode;
		}

		
		void CopyTextureImporter(TextureImporter importer, TextureImporter templateImporter)
		{
			importer.anisoLevel = templateImporter.anisoLevel;
			importer.borderMipmap = templateImporter.borderMipmap;
			importer.compressionQuality = templateImporter.compressionQuality;
			importer.convertToNormalmap = templateImporter.convertToNormalmap;
			importer.fadeout = templateImporter.fadeout;
			importer.filterMode = templateImporter.filterMode;
			importer.fadeout = templateImporter.fadeout;
			importer.generateCubemap = templateImporter.generateCubemap;
			importer.generateMipsInLinearSpace = templateImporter.generateMipsInLinearSpace;
			importer.grayscaleToAlpha = templateImporter.grayscaleToAlpha;
			importer.heightmapScale = templateImporter.heightmapScale;
			importer.isReadable = templateImporter.isReadable;
			importer.lightmap = templateImporter.lightmap;
			importer.linearTexture = templateImporter.linearTexture;
			importer.maxTextureSize = templateImporter.maxTextureSize;
			importer.mipMapBias = templateImporter.mipMapBias;
			importer.mipmapEnabled = templateImporter.mipmapEnabled;
			importer.mipmapFadeDistanceEnd = templateImporter.mipmapFadeDistanceEnd;
			importer.mipmapFadeDistanceStart = templateImporter.mipmapFadeDistanceStart;
			importer.mipmapFilter = templateImporter.mipmapFilter;
			importer.normalmap = templateImporter.normalmap;
			importer.normalmapFilter = templateImporter.normalmapFilter;
			importer.npotScale = templateImporter.npotScale;
			importer.spriteBorder = templateImporter.spriteBorder;
			importer.spriteImportMode = templateImporter.spriteImportMode;
			importer.spritePackingTag = templateImporter.spritePackingTag;
			importer.spritePivot = templateImporter.spritePivot;
			importer.spritesheet = templateImporter.spritesheet;
			importer.textureFormat = templateImporter.textureFormat;
			importer.textureType = templateImporter.textureType;
			importer.wrapMode = templateImporter.wrapMode;
		}

		void CopyTextureImporterSettings(TextureImporterSettings settings , TextureImporterSettings templateSettings)
		{
			settings.cubemapConvolution = templateSettings.cubemapConvolution;
			settings.cubemapConvolutionExponent = templateSettings.cubemapConvolutionExponent;
			settings.cubemapConvolutionSteps = templateSettings.cubemapConvolutionSteps;
			settings.rgbm = templateSettings.rgbm;
			settings.spriteAlignment = templateSettings.spriteAlignment;
			settings.spriteBorder = templateSettings.spriteBorder;
			settings.spriteExtrude = templateSettings.spriteExtrude;
			settings.spriteMode = templateSettings.spriteMode;
			settings.spritePivot = templateSettings.spritePivot;
			settings.spritePixelsPerUnit = templateSettings.spritePixelsPerUnit;
		}


		void OnGUI()
		{
			EditorGUILayout.BeginVertical();
			templateTexture = EditorGUILayout.ObjectField("Template texture", templateTexture, typeof(Texture), false) as Texture;
			if (templateTexture != null)
			{
				if (GUILayout.Button("Reset all textures"))
				{
					foreach(UnityEngine.Object obj in Selection.objects)
					{
						string path = AssetDatabase.GetAssetPath(obj);
						if (Directory.Exists(path))
						{
							string templatePath = AssetDatabase.GetAssetPath(templateTexture);
							TextureImporter templateImporter = TextureImporter.GetAtPath(templatePath) as TextureImporter;
							TextureImporterSettings templateSettings = new TextureImporterSettings();
							templateImporter.ReadTextureSettings(templateSettings);

							PrintTextureImporterSettings(templateSettings);


							List<string> urls = new List<string>();

							PlatformOption[] templateOptions = new PlatformOption[platformNames.Length];
							for (int i = 0; i < platformNames.Length; i++)
							{
								templateOptions[i] = GetPlatformOption(templateImporter, platformNames[i]);
							}

							WalkThroughAssetsInDirectory<Texture>(path, urls);
							int numFiles = urls.Count;

	//						Debug.Log("\ntemplateImporter");
	//						PrintTextureImporter(templateImporter);

							for(int i = 0; i < numFiles; i++)
							{
							
								if (EditorUtility.DisplayCancelableProgressBar("Setting texture", i + "/" + numFiles, (float)i/(float)numFiles))
									break;
							
								string url = urls[i];

								TextureImporter importer = TextureImporter.GetAtPath(url) as TextureImporter;
								if (importer == null)
									continue;



								bool isDirty = false;
								TextureImporterSettings settings = new TextureImporterSettings();
								importer.ReadTextureSettings(settings);

								CopyTextureImporter(importer, templateImporter);
								CopyTextureImporterSettings(settings, templateSettings);
								
	//							Debug.Log("\n " + url);
	//							PrintTextureImporter(importer);
								for (int j = 0; j < platformNames.Length; j++)
								{
									string platform = platformNames[j];
									PlatformOption templateOption = templateOptions[j];
									PlatformOption option = GetPlatformOption(importer, platform);

									if (templateOption.enable != option.enable || 
									    templateOption.maxTextureSize != option.maxTextureSize ||
									    templateOption.format != option.format)
									{
										isDirty = true;
										importer.SetPlatformTextureSettings(platform, templateOption.maxTextureSize, templateOption.format, templateOption.compressionQuality, false);
										Debug.Log(platform + " "+templateOption.maxTextureSize);
										if (!templateOption.enable)
											importer.ClearPlatformTextureSettings(platform);

									}
		//							int maxTextureSize;
		//							TextureImporterFormat textureFormat;
		//							if (templateImporter.GetPlatformTextureSettings(platform, out maxTextureSize, out textureFormat))
		//							{
		//								importer.SetPlatformTextureSettings(platform, maxTextureSize, textureFormat);
		//							}
		//							else
		//								importer.ClearPlatformTextureSettings(platform);
								}

								importer.SetTextureSettings(templateSettings);
								AssetDatabase.ImportAsset(url);
		//						AssetDatabase.SaveAssets();
		//						Resources.UnloadUnusedAssets();
							}
							EditorUtility.ClearProgressBar();

						}
					}




				}
			}
			EditorGUILayout.EndVertical();
		}

		private void WalkThroughAssetsInDirectory<T>(string root, List<string> assets) where T : class
		{
	//		Resources.UnloadUnusedAssets();
			string[] files = Directory.GetFiles(root);
			
			foreach(string file in files)
			{
				//if (CheckAsset<T>(file))
				{
					assets.Add(file);
				}
			}

			string[] subs = Directory.GetDirectories(root);
			foreach(string subDir in subs)
			{
				WalkThroughAssetsInDirectory<T>(subDir, assets);
			}
		}

		private bool CheckAsset<T>(string url)
		{
			UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(url, typeof(T));
			if (asset is T)
			{
				return true;
			}
			else
			{
				return false;
			}
			AssetDatabase.SaveAssets();
			Debug.Log ("Resources.UnloadUnusedAssets() TextureMaster!");
			Resources.UnloadUnusedAssets();
		}
	}
}
