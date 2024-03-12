using MediatR;
using System.Globalization;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand(string name) : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = name.Trim().ToUpper(CultureInfo.CurrentCulture);
    }
}
