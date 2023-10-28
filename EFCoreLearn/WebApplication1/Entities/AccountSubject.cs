namespace WebApplication1.Entities
{
    public class AccountSubject
    {
        public Guid AccountId { get; set; }

        // 导航属性 添加 virtual  开启懒加载
        public virtual Account Account { get; set;}

       public Guid SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
