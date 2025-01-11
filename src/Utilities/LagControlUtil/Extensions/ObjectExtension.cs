namespace LagControlUtil.Extensions
{
    public static class ObjectExtension
    {
        public static bool ENull(this object? obj)
        {
            return obj is null;
        }
    }
}
