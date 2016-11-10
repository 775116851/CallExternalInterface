using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enyim.Caching;
using Enyim.Caching.Memcached;

/// <summary>
///MemcacheDictionary 的摘要说明
/// </summary>
public sealed class MemcacheDictionary<Value>
{
    private static readonly MemcachedClient mc = MemcachedClient.CacheClient;

    public MemcacheDictionary()
    {
        
    }
    public bool Exists(string key)
    {
        return mc.KeyExists(key);
    }

    public Value Get(string key)
    {
        if (key == null)
            return default(Value);
        return mc.Get<Value>(key);
    }

    public List<Value> GetAll(string CacheKeyPrefix)
    {
        List<string> keys = mc.Get_Keys(CacheKeyPrefix);
        List<Value> data = new List<Value>();
        IDictionary<string, object> fromcache = mc.Get_Multi(keys);
        //var fromcache = mc.Get_Multi(keys);
        foreach (string key in keys)
        {
            if (fromcache.ContainsKey(key))
                data.Add((Value)fromcache[key]);
        }
        return data;
    }

    public void Set(string key, Value value)
    {
        mc.Store(StoreMode.Set, key, value);
    }

    public void Set(string key, Value value, DateTime expiresAt)
    {
        mc.Store(StoreMode.Set, key, value, expiresAt);
    }

    public void Set(string key, Value value, TimeSpan validFor)
    {
        mc.Store(StoreMode.Set, key, value, validFor);
    }

    public void Remove(string key)
    {
        mc.Remove(key);
    }

    public void RemoveAll(string CacheKeyPrefix)
    {
        List<string> keys = mc.Get_Keys(CacheKeyPrefix);
        foreach (string key in keys)
        {
            mc.Remove(key);
        }
        //keys.ForEach(key => mc.Remove(key));
    }

}
