using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetworkUtility
{
    public partial class UcGeoLocation : UserControl
    {
        private static UcGeoLocation _sample;
        public static UcGeoLocation Sample
        {
            get
            {
                if (_sample == null)
                {
                    _sample = new UcGeoLocation();
                    Sample.Dock = DockStyle.Fill;
                }
                return _sample;
            }
        }

        public UcGeoLocation()
        {
            InitializeComponent();
        }
    }
}
