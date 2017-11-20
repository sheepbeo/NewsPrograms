namespace Client.Data
{
    // TODO unit test
    public class DataHelper
    {
        public static string GetNotEmpty(params string[] input)
        {
            foreach (var s in input)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    return s;
                }
            }

            return "";
        }
    }
}