using CDDA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDDA.Models
{
    public class BuildCache
    {
        public DateTime Date { get; set; }
        public BuildsViewModel Obj { get; set; }

        public BuildCache(BuildsViewModel obj, DateTime date )
        {
            this.Obj = obj;
            this.Date = date;
        }
    }
}
