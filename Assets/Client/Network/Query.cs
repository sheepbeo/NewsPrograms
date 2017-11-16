using System.Text;

namespace Client.Network
{
    // TODO unit test
    public class Query
    {
        private readonly int _queryLimit;
        private readonly string _searchText;

        private int _offset;

        public Query(int queryLimit, string searchText)
        {
            _searchText = searchText;
            _offset = 0;
            _queryLimit = queryLimit;
        }

        public string GetParams()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(_searchText))
            {
                stringBuilder.Append("&q=").Append(_searchText);
            }

            stringBuilder.Append("&limit=").Append(_queryLimit);
            stringBuilder.Append("&offset=").Append(_offset);

            return stringBuilder.ToString();
        }

        public void Increment()
        {
            _offset += _queryLimit;
        }
    }
}