﻿namespace SapperApplication.Components
{
    public class Cell
    {
        #region  .ctor

        public Cell()
            : this(0,
                   false,
                   false)
        {
        }

        public Cell(byte value)
            : this(value,
                   false,
                   false)
        {
        }

        public Cell(byte value,
                    bool isOpened,
                    bool isSelected)
        {
            Value = value;
            IsOpened = isOpened;
            IsSelected = isSelected;
        }

        #endregion

        #region  Properties

        public bool IsSelected { get; set; }
        public byte Value { get; set; }
        public bool IsOpened { get; set; }

        #endregion

        #region  Public Methods

        public void Open()
        {
            if (!IsSelected)
            {
                IsOpened = true;
            }
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

        #endregion
    }
}