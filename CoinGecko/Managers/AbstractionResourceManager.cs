using System;
using System.Collections.Generic;
using System.Windows;
using CoinGecko.Pairs;

namespace CoinGecko.Managers;

public abstract class AbstractionResourceManager
{
    protected readonly Application Application;
    protected readonly Dictionary<string, Uri> UriMap = new();
    protected ResourceDictionary? ResourceDictionary;

    protected AbstractionResourceManager(UriPair[] items, Application application)
    {
        Application = application;

        foreach (var item in items) UriMap.Add(item.Key, item.Value);
    }

    protected void ChangeResource(Uri uri)
    {
        var dict = new ResourceDictionary
        {
            Source = uri
        };

        var mergedDictionaries = Application.Resources.MergedDictionaries;
        mergedDictionaries.Insert(0, dict);

        if (ResourceDictionary != null) mergedDictionaries.Remove(ResourceDictionary);

        ResourceDictionary = dict;
    }
}