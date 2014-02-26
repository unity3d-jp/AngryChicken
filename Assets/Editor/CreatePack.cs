using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreatePack
{
	static readonly string[] packagePath =
	{
		"Effect",
		"Slingshot",
	};

	[MenuItem("Export/ExportPackage")]
	static void ExportPackage()
	{
		foreach (var path in packagePath)
		{
			string inFilePath = "Assets/" + path;
			string exportFilePath = "Assets/" + path + ".unitypackage";

			AssetDatabase.ExportPackage(inFilePath, exportFilePath, ExportPackageOptions.Recurse);
		}

		AssetDatabase.Refresh(ImportAssetOptions.Default);
	}
}