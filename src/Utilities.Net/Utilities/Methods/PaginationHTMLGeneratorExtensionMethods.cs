using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using Utilities.Attributes;

namespace Utilities
{
    public static class PaginationHTMLGeneratorExtensionMethods
    {
        public static string GenerateHtml(int PageSize, int PageNumber)
        {
            string pagerhtml = "";
            pagerhtml += "<input type='hidden' name='pageNumber' id='hdnPageNumber'/>";
            pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", 1, (PageNumber > 1 ? "" : "disabled"), "⟪");
            pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", PageNumber - 1, (PageNumber > 1 ? "" : "disabled"), "⟨");

            var start = 1;
            var end = PageSize;
            var nrOfPagesToDisplay = 3;

            if (PageSize > nrOfPagesToDisplay)
            {
                var middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
                var below = (PageNumber - middle);
                var above = (PageNumber + middle);

                if (below <= 3)
                {
                    //above = nrOfPagesToDisplay;
                    below = 1;
                }
                if (above >= (PageSize - 2))
                {
                    above = PageSize;
                    //below = (PageCount - nrOfPagesToDisplay + 1);
                }

                start = below;
                end = above;
            }

            if (start > 1)
            {
                pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", 1, "", "1");
                //if (start == 2)
                //{
                //    pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", start, "", start);
                //}
                //else 
                if (start > 3)
                {
                    pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", start - 1, "", "...");
                }
            }

            for (var i = start; i <= end; i++)
            {
                if (i == PageNumber || (PageNumber <= 0 && i == 1))
                {
                    pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", i, "active disabled", i);
                }
                else
                {
                    pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", i, "", i);
                }
            }

            if (end < PageSize)
            {
                //if (end == PageCount - 1 )
                //{
                //    pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", end, "", end);
                //}
                //else 
                if (end < PageSize - 2)
                {
                    pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", end + 1, "", "...");
                }
                pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", PageSize, "", PageSize);
            }
            pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", PageNumber + 1, PageNumber < PageSize ? "" : "disabled", "⟩");
            pagerhtml += string.Format(" <li class='{1}' onclick=\"if($(this).hasClass('disabled')) return false; $('#hdnPageNumber').val({0});$(this).parents('form').submit();\"><a pnum='{0}'>{2}</a></li>", PageSize, (PageNumber < PageSize ? "" : "disabled"), "⟫");

            return pagerhtml;
        }

    }
}
