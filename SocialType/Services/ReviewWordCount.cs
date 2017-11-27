using System;

namespace SocialType.Services
{
    // TODO kimutis : should be moved to another location
    public static class ReviewWordCount
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}