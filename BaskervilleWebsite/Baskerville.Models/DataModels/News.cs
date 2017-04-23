using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.DataModels
{
    public class News
    {
        public int Id { get; set; }

        public string TitleBg { get; set; }

        public string TitleEn { get; set; }

        public string MessageBg { get; set; }

        public string MessageEn { get; set; }

        public string FromBg { get; set; }

        public string FromEn { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsPublic { get; set; }
    }
}
