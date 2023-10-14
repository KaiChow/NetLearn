namespace UserMgr.WebAPI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute:Attribute
    {
        public Type[] DbContextTypes { get; set; }

        public UnitOfWorkAttribute(params Type[] dbContextTypes) {
            this.DbContextTypes = dbContextTypes;
        }

    }
}
