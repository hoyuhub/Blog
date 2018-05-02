using System;
using StackExchange.Redis;
using System.Collections.Generic;
namespace Blog.Common
{
    public static class RedisCommon
    {

        private static ConnectionMultiplexer redis;

        public static ConnectionMultiplexer GetConnection()
        {
            if (redis == null)
            {
                redis = ConnectionMultiplexer.Connect("localhost");

            }
            return redis;
        }

        public static Dictionary<string, string> ToDic(this HashEntry[] hash)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (hash.Length == 0)
                return dic;
            foreach (var item in hash)
            {
                dic.Add(item.Name, item.Value);
            }
            return dic;
        }
    }
}