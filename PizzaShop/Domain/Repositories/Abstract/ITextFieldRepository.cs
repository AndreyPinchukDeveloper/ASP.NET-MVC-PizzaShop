using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Repositories.Abstract
{
    public interface ITextFieldRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldCodeWord(string codeword);
        void SaveTextField(TextField textField);
        void DeleteTextField(Guid id);
    }
}
