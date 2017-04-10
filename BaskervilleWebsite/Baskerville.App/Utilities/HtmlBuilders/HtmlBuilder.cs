using Baskerville.App.Utilities.HtmlBuilders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Baskerville.App.Utilities.HtmlBuilders
{
    public abstract class HtmlBuilder
    {
        public HtmlBuilder()
        {
            this.Builder = new StringBuilder();
        }

        protected StringBuilder Builder { get; set; }

        public abstract HtmlString Render();       
    }
}