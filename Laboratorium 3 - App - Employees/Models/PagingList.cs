namespace Laboratorium_3___App___Employees.Models
{
    public class PagingList<T>
    {
        public IEnumerable<T> Data { get; }
        public int Page { get; }
        public int Size { get; }
        public int TotalPages { get; }
        public int TotalItems { get; }
        public bool IsPrevious { get; }
        public bool IsNext { get; }

        private static int CalcTotalPages(int totalItem, int size)
        {
            return totalItem / size + (totalItem % size == 0 ? 0 : 1);
        }

        private PagingList(IEnumerable<T> data, int page, int size, int totalItems)
        {
            this.Data = data;
            this.Page = page;
            this.Size = size;
            this.TotalItems = totalItems;
            this.TotalPages = CalcTotalPages(TotalItems, Size);
            IsPrevious = Page > 1;
            IsNext = Page < TotalPages;
        }

        private static int ClipPage(int page, int size, int totalItems)
        {
            int totalPages = CalcTotalPages(totalItems, size);
            if (page < 1)
            {
                return 1;
            }
            if (page > totalPages)
            {
                return totalPages;
            }
            return page;
        }

        public static PagingList<T> Create(Func<int, int, IEnumerable<T>> dataGenerator, int page, int size, int totalItems)
        {
            int validPage = ClipPage(page, size, totalItems);
            return new PagingList<T>(
                dataGenerator.Invoke(validPage, size),
                validPage,
                size,
                totalItems
                );
        }
    }
}
