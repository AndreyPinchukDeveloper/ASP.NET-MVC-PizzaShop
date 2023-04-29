using PizzaShop.Data.Services;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// Implementation especially for EFCore based on ITextFieldRepository
    /// </summary>
    public class EFTextFielsRepository : ITextFieldRepository
    {
        private readonly AppDbContext _context;
        public EFTextFielsRepository(AppDbContext context)
        {
            _context = context;
        }
        public void DeleteTextField(Guid id)
        {
            _context.TextFields.Remove(new TextField() { Id = id });
            _context.SaveChanges();
        }

        public TextField GetTextFieldById(Guid id)
        {
            return _context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextFieldCodeWord(string codeword)
        {
            return _context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);
        }

        public IQueryable<TextField> GetTextFields()
        {
            return _context.TextFields;
        }

        public void SaveTextField(TextField textField)
        {
            if (textField.Id == default) _context.Entry(textField).State = EntityState.Added;
            else _context.Entry(textField).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
