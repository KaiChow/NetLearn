using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace UserMgr.WebAPI
{
    public class UnitOfWordFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();
            // 只有action执行成功，才自动调用savechanges
            if (result.Exception != null)
            {
                return;
            }
            var actionDesc = context.ActionDescriptor as ControllerActionDescriptor;
            if (actionDesc == null)
            {
                return;
            }
            var uowAttr = actionDesc.MethodInfo.GetCustomAttribute<UnitOfWorkAttribute>();
            if (uowAttr == null)
            {
                return;
            }
            foreach (var dbCtxType in uowAttr.DbContextTypes)
            {
                var dbCtx = context.HttpContext.RequestServices.GetService(dbCtxType) as DbContext;
                if (dbCtx != null)
                {
                    await dbCtx.SaveChangesAsync();
                }

            }
        }
    }
}
