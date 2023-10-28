namespace WebApplication1.Entities
{
    public class AccountDetails
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        public string AdditionalInfomation { get; set; }

        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
