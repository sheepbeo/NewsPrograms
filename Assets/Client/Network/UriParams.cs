namespace Client.Network
{
    public class UriParams
    {
        public static UriParams Default = new UriParams();

        private string _searchParam = "";

        public void SetSearchParam(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                _searchParam = "&q=" + searchText;
            }
            else
            {
                _searchParam = "";
            }
        }

        public override string ToString()
        {
            return _searchParam;
        }
    }
}