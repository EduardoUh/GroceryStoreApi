using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        private string _name = string.Empty;
        public string Name { get => _name; set => _name = value.Trim().ToUpper(); }
    }
}
