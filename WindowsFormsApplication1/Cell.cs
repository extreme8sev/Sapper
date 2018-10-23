namespace WindowsFormsApplication1
{
    public class Cell
    {
        public bool IsSelected { get; set; }
        public byte Value { get; set; }
        public bool IsOpened { get; set; }

        public Cell()
        {
            Value = 0;
            IsOpened = false;
            IsSelected = false;
        }

        public Cell(byte value)
        {
            Value = value;
            IsOpened = false;
            IsSelected = false;
        }

        public Cell(byte value, bool isOpened, bool isSelected)
        {
            Value = value;
            IsOpened = isOpened;
            IsSelected = isSelected;
        }

        public void Open()
        {
            if (!IsSelected) IsOpened = true;
        }

        public void Close()
        {
            IsOpened = false;
        }

        public void Select()
        {
            if (!IsOpened)
            {
                IsSelected = !IsSelected;
            }
        }

        public void SetToZero()
        {
            Value = 0;
            IsOpened = false;
            IsSelected = false;
        }
    }
}