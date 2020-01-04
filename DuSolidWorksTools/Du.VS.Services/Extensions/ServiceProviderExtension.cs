using Du.VS.Core;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Services.Extensions
{
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// 获取在获得文档中选中的位置和内容
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static Du.VS.Core.TextViewSelection GetSelection(this IServiceProvider serviceProvider)
        {
            var ServiceResult = serviceProvider.GetService(typeof(SVsTextManager));
            // service.Wait();

            var textManager = ServiceResult as IVsTextManager2;
            IVsTextView view;
            int result = textManager.GetActiveView2(1, null, (uint)_VIEWFRAMETYPE.vftCodeWindow, out view);
            //获取缓存视图
            IVsTextLines lines;
            view.GetBuffer(out lines);
            //获取选中位置
            view.GetSelection(out int startLine, out int startColumn, out int endLine, out int endColumn);//end could be before beginning
            lines.GetPositionOfLineIndex(startLine, startColumn, out int StartPostion);
            lines.GetPositionOfLineIndex(endLine, endColumn, out int EndPostion);

            var start = new TextViewPosition(startLine, startColumn, StartPostion);
            var end = new TextViewPosition(endLine, endColumn, EndPostion);

            view.GetSelectedText(out string selectedText);

            TextViewSelection selection = new TextViewSelection(start, end, selectedText);
            return selection;
        }

    }
}
