using LagControlCLI.Resources;

namespace LagControlCLI.Options
{
    internal static class CategoryDialogOptions
    {
        internal static Dictionary<CategoryDialogOptionEnum, string> Options => new()
        {
            { CategoryDialogOptionEnum.AddCategory, "Adicionar Categoria" },
            { CategoryDialogOptionEnum.Edit, "Editar Categoria" },
            { CategoryDialogOptionEnum.Back, Resource.Back }
        };

        internal enum CategoryDialogOptionEnum
        {
            AddCategory,
            Edit,
            Back
        }
    }
}
