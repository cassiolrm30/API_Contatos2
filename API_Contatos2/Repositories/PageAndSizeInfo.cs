namespace API_Contatos2.Models
{
    public class PageAndSizeInfo
    {
        private int _page;
        public int Page
        {
            get => _page;
            set => _page = value;
        }

        private int _size = 10;
        public int Size
        {
            get => _size;
            set => _size = value;
        }
    }
}