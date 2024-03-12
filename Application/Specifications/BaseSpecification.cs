using System.Linq.Expressions;

namespace Application.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        #region Constructors
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        #endregion

        #region Properties
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginationEnabled { get; private set; }
        #endregion

        #region Methods
        public void AddIncludeExpression(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddOrderByExpression(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public void AddOrderByDescendingExpression(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
        public void ApplyPagination(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPaginationEnabled = true;
        }
        #endregion
    }
}
