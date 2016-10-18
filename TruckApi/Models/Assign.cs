namespace TruckApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Assign
    {
        public int assignid
        {
            get;
            set;
        }
        public string lorryno
        {
            get;
            set;
        }
        public int loadid
        {
            get;
            set;
        }
        public int transpoterid
        {
            get;
            set;
        }

        public string assigndate
        {
            get;
            set;
        }
    }
}