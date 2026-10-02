using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagControlUtil.Extensions;
using LagFinanceApplication.Commands.Categories;
using LagFinanceApplication.Queries.Categories;
using LagFinanceDomain.Enums;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Categories
{
    internal class EditCategoryDialog(IAnsiConsole console, IMediator mediator) : DialogBase(console), IEditCategoryDialog
    {
        protected Dictionary<Guid, string> CategoryDic { get; set; } = default!;
        
        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingCategories, async _ =>
            {
                var categories = await mediator.Send(new CategoryListQuery());
 
                CategoryDic = categories.OrderBy(x => x.Type)
                                        .OrderBy(x => x.Description)
                                        .ToDictionary(k => k.Id, v => $"{v.Description} ({v.Type.GetDescription().Color(v.Type == CategoryTypeEnum.Income ? Color.Green : Color.Red)})");
            });
        }

        protected async override Task ExecuteAsync()
        {
            var selected = SelectionPrompt.Ask(Console, Resource.SelectCategoryPrompt, CategoryDic);
            var description = TextPrompt.Ask(Console, Resource.Description);

            var tipoDic = new[] { CategoryTypeEnum.Income, CategoryTypeEnum.Expense }.ToDictionary(k => k, v => Enum.GetName(v));
            var tipo = SelectionPrompt.Ask(Console, Resource.TypeLabel, tipoDic!);

            await mediator.Send(new UpdateCategoryCommand 
            { 
                Id = selected, 
                Description = description, 
                Type = tipo 
            });
        }
    }
}
