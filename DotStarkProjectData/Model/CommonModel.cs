using DotStarkProjectData.CommonFunction;
using DotStarkProjectData.Context;
using EntityFrameworkCore.Triggered;

namespace DotStarkProjectData.Model
{
    public class CommonModel
    {
        public class ApplicationTransaction
        {
            public bool IsSuccess { get; set; }
            public int StatusCode { get; set; }
            public string? Message { get; set; }
        }
    }

    public class SetUpdatedOnDate : IBeforeSaveTrigger<Products>
    {
        public Task BeforeSave(ITriggerContext<Products> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.CreatedAt = Application.CurrentDateTime;
            }

            return Task.CompletedTask;
        }
    }
}
