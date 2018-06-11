using System;
using System.Xml;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Blog.Common
{
    public class FileRead
    {
        public void ReadXml()
        {
            XmlDocument doc=new XmlDocument();
            doc.Load(@"c:\Users\89275\Desktop\depts.xml");
            XmlElement root=doc.DocumentElement;
            XmlNodeList list=root.SelectNodes("response/output/departlist/depart");
            List<Dictionary<string,string>> listDic=new List<Dictionary<string, string>>();
            foreach (XmlNode x in list)
            {
                Dictionary<string,string> dic=new Dictionary<string, string>();
                dic.Add("code",x.SelectSingleNode("code").InnerText);
                dic.Add("name",x.SelectSingleNode("name").InnerText);
                dic.Add("pcode",x.SelectSingleNode("pcode").InnerText);
                dic.Add("index",x.SelectSingleNode("index").InnerText);
                listDic.Add(dic);

            }

            foreach(var i in  listDic)
            {
                if(i["pcode"].IsNullOrEmpty())
                {
                    string hosCode="T113001";
                    string key=string.Format("{0}:deptone",hosCode);
                    RedisCommon.GetData().HashSet();
                }
            }
        }
    }
}