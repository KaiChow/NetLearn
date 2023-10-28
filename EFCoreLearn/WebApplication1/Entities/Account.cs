using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication1.Entities
{
    public class Account
    {
        private readonly ILazyLoader lazyLoader;

        public Account(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public Guid AccountId { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }


        /// <summary>
        /// 这是1对1的导航属性
        /// </summary>
        public  AccountDetails AccountDetails { get; set; }

        /// <summary>
        /// 这是1对多的导航属性
        /// </summary>
        /// 
        // 单个的懒加载配置
        public ICollection<AccountSubject> _accountSubjects;
        public ICollection<AccountSubject> AccountSubjects { get=>lazyLoader?.Load(this,ref _accountSubjects); set=> _accountSubjects = value; }
    }
}
