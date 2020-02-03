namespace WebApi.Paging
{
    public class PagingReferences
    {
        public PagingReferences()
        {
            PageSize = 10;
            PageNumber = 1;
        }

        private int _pageSize;
        private int _pageNumber;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value > 20) value = 20;
                if (value < 2) value = 2;
                _pageSize = value;
            }
        }
        public int PageNumber
        {
            get => _pageNumber;
            set
            {
                if (value < 1) value = 1;
                _pageNumber = value;
            }
        }
    }
}
