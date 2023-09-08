﻿using System.Text.Json;

namespace AssetRipper.GUI.Electron;

public readonly record struct CollectionPath(BundlePath BundlePath, int Index)
{
	public string ToJson()
	{
		return JsonSerializer.Serialize(this, PathSerializerContext.Default.CollectionPath);
	}

	public static CollectionPath FromJson(string json)
	{
		return JsonSerializer.Deserialize(json, PathSerializerContext.Default.CollectionPath);
	}
}
