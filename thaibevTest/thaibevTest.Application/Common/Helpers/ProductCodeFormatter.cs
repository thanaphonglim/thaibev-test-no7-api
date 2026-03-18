namespace thaibevTest.Application.Common.Helpers
{
    public static class ProductCodeFormatter
    {
        public static string Format(string code)
        {
            return string.Join("-",
                Enumerable.Range(0, code.Length / 5)
                    .Select(i => code.Substring(i * 5, 5)));
        }
    }
}
