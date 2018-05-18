using System;
using StackExchange.Redis;
using System.Collections.Generic;
using Blog.Models;
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
        private static IDatabase database;
        public static IDatabase GetData()
        {
            if (database == null)
            {
                database = GetConnection().GetDatabase();
            }
            return database;
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

        public static void SetBLog(BLogModel bLog)
        {
            string postCount = GetData().StringIncrement("post:count").ToString();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("title", bLog.title);
            dic.Add("author", bLog.author);
            dic.Add("time", bLog.time.ToString());
            dic.Add("content", bLog.content);

            try
            {
                GetData().HashSet("post:"+postCount, dic.ToHashEntry());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static HashEntry[] ToHashEntry(this Dictionary<string, string> dic)
        {
            List<HashEntry> list = new List<HashEntry>();
            foreach (var item in dic.Keys)
            {
                list.Add(new HashEntry(item, dic[item]));
            }

            return list.ToArray();
        }


        public static bool SetSlugToId(string slug, string id)
        {
            if (!GetData().HashExists("slug.to.id", slug))
            {
                GetData().HashSet("slug.to.id", slug, id);
                return true;
            }
            return false;
        }

    }
}