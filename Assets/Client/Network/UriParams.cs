namespace Client.Network
{
    // TODO unit test
    public class UriParams
    {
        private string _searchParam = "";
        private string _queryLimit = "";

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

        public void SetLimit(int queryLimit)
        {
            _queryLimit = "&limit=" + queryLimit;
        }

        public override string ToString()
        {
            return _searchParam;
        }

        public void SetOffset(int offset)
        {
            
        }
    }
}