using cCoder.Core.Objects.Dtos;
using cCoder.Core.Objects.Workflow.Activities.Api;

namespace B2B.Objects.Workflow.Activities
{
    public abstract class B2BActivity : ApiActivity { }

    public abstract class B2BActivity<T> : ApiActivity<IEnumerable<Result<T>>> { }
}