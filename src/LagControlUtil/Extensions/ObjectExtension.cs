namespace LagControlUtil.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNull(this object? obj)
        {
            return obj is null;
        }
    }
}
