using System;
using System.Collections.Generic;

namespace Ncc.Helper
{
    /// <summary>
    /// ��������� ��� ����������, ������� ����� �������� �� "������� �����"
    /// </summary>
    public class InputFolderInfo
    {
        private int _pureItemsFromDictionaryCount;

        /// <summary>
        /// ����� ���������� ������� ���� � �������
        /// </summary>
        public int PureItemsFromDictionaryCount {
            get { return _pureItemsFromDictionaryCount; }
            set
            {
                _pureItemsFromDictionaryCount = value;
                OnItemsChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// ����������� ��������
        /// </summary>
        public int UnknownItemsCount { get; set; }

        public List<string> DictionaryItems { get; set; }

        public List<string> UnknownItemes { get; set; }

        public int TotalItemsCount
        {
            get
            {
                return PureItemsFromDictionaryCount + UnknownItemsCount;
            }
        }

        protected virtual void OnItemsChanged(EventArgs e)
        {
            EventHandler handler = TotalItemsCountChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler TotalItemsCountChanged;

        public InputFolderInfo()
        {
            PureItemsFromDictionaryCount = 0;
            UnknownItemsCount = 0;

            DictionaryItems = new List<string>();
            UnknownItemes = new List<string>();
        }

        public override string ToString()
        {
            return string.Format("���-�� �������� �� �������: {0};{2}���-�� ����������� ��������: {1}", PureItemsFromDictionaryCount, UnknownItemsCount, Environment.NewLine);
        }
    }
}