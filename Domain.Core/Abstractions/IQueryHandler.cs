namespace Domain.Core.Abstractions
{
    public interface IQueryHandler<in T, out TR> where T : IQuery<TR>
    {
        TR Handle(T query);
    }
}