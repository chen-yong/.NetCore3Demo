using Microsoft.AspNetCore.Mvc;
using Student.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.ViewComponents
{
    public class CompanySummaryViewComponent:ViewComponent
    {
        /*
         * View Component作用：有局部视图PartialViews的作用 
         * 优点：代码复用性比局部视图好
         * 使用步骤：
         * 1.建立ViewComponts 文件夹，在建立对应的component 类（注意命名规范）
         * 2.在对应的类下编写业务逻辑
         * 3.新建Razor视图页面
         * 4.在需要引用component的页面引用
         * 例如：
         *  方法一：@await Component.InvokeAsync(name:"CompanySummary",arguments:new { title="部门列表页的汇总"}) 
         *  注意异步和同步引用的区别
           方法二：<vc:company-summary  title="部门列表页的汇总2"></vc:company-summary>
           使用第二种方法要在 _ViewImports.cshtml  类页面中声明对应的引用 
         */
        private readonly IDepartmentService _departementServe; //快捷键alt+enter

        public CompanySummaryViewComponent(IDepartmentService departementServe)
        {
            _departementServe = departementServe;
        }

        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary = await _departementServe.GetCompanySummary();
            return View(summary);
        }
    }
}
