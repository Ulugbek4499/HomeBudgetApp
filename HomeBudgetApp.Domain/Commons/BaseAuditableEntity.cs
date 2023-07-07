namespace HomeBudgetApp.Domain.Commons
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
