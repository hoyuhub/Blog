using System;
namespace Blog.Common
{
    public static class Common
    {
        public static bool IsNullOrEmpty(this string s)
        {
            if (s.Trim().Equals("") || s.Trim() == null)
                return true;
            else
                return false;
        }

        
    }
}