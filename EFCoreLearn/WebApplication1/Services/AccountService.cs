using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class AccountService
    {
        private readonly ApplicationContext context;
        private readonly IOptions<JsonSerializerOptions> jsonOptions;

        public AccountService(ApplicationContext context, IOptions<JsonSerializerOptions> jsonOptions)
        {
            this.context = context;
            this.jsonOptions = jsonOptions;
        }
        /*
         * 
         * EFCore 三个部分
         * 属性==》引用其他实体===引用关系===表关联
         * 
         * 导航属性==实体关联的数据==》连表查询
         * 
         * 贪婪记载（明确要求 include，还有theninclude）  显示加载  懒加载(按需加载 安装Proxies)
         * 
         * **/
        public void Run()
        {
            // 不对数据做任何操作客设置AsNoTracking() 
            /*
             * 明确要求 include，还有theninclude Account导航属性 AccountSubjects，AccountSubjects里面又有导航属性 Subject
             * **/
            var accounts = context.Accounts.AsNoTracking().Include(u=>u.AccountSubjects).ThenInclude(s=>s.Subject).Where(a => a.Age > 24).ToList();

            /*
             *  按需加载 安装proxies contex配置   两种方法
             *  1，所有的都得加 导航属性 添加 virtual
             *  2，只需配置的添加 注入ILazyloader
             * **/
        }
    }
}
